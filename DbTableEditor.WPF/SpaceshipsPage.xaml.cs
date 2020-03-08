using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace DbTableEditor.WPF
{
    /// <summary>
    /// Interaction logic for SpaceshipsPage.xaml
    /// </summary>
    public partial class SpaceshipsPage : Page
    {
        private bool _rowCommiting;

        public SpaceshipsPage()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupGrid()
        {
            var c = new Context();
            using var context = new SpaceshipsContext();
            c.Spaceships = context.Spaceships
                .Include(e => e.Fleet)
                .Include(e => e.Shipyard)
                .OrderBy(s => s.Id)
                .ToList();
            c.Fleets = context.Fleets
                .OrderBy(f => f.Id)
                .ToList();
            c.Shipyards = context.Shipyards
                .OrderBy(s => s.Id)
                .ToList();
            DataContext = c;
        }

        private void CommitRowEdit()
        {
            _rowCommiting = true;
            Grid.CommitEdit();
            _rowCommiting = false;
        }

        private void GridOnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (_rowCommiting)
            {
                return;
            }

            var spaceship = (Spaceship)e.Row.Item;
            using var context = new SpaceshipsContext();

            if (context.Spaceships.Any(s => s.Id == spaceship.Id))
            {
                // Updating
                context.Attach(spaceship);
            }
            else
            {
                // Creating new
                context.Spaceships.Add(spaceship);
            }

            CommitRowEdit();
            context.SaveChanges();
        }

        private void GridOnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete)
            {
                return;
            }

            var grid = (DataGrid)sender;
            if (grid.SelectedItems.Count <= 0)
            {
                return;
            }

            var selected = grid.SelectedItems.Cast<Spaceship>();
            using var context = new SpaceshipsContext();
            context.RemoveRange(selected);
            context.SaveChanges();
        }

        private class Context
        {
            public List<Spaceship> Spaceships { get; set; }
            public List<Fleet> Fleets { get; set; }
            public List<Shipyard> Shipyards { get; set; }
        }
    }
}
