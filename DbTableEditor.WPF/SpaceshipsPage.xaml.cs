using DbTableEditor.Data.Context;
using DbTableEditor.Data.Exceptions;
using DbTableEditor.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DbTableEditor.WPF
{
    /// <summary>
    /// Interaction logic for SpaceshipsPage.xaml
    /// </summary>
    public partial class SpaceshipsPage : Page
    {
        public SpaceshipsPage()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupGrid()
        {
            var ctx = new Context();
            using (var context = new SpaceshipsContext())
            {
                ctx.Spaceships = context.Spaceships
                    .Include(e => e.Fleet)
                    .Include(e => e.Shipyard)
                    .OrderBy(s => s.Id)
                    .ToList();
                ctx.Fleets = context.Fleets
                    .OrderBy(f => f.Id)
                    .ToList();
                ctx.Shipyards = context.Shipyards
                    .OrderBy(s => s.Id)
                    .ToList();
            }
            DataContext = ctx;
        }

        private void GridOnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var spaceship = (Spaceship)e.Row.Item;

            var (fleet, shipyard) = (spaceship.Fleet, spaceship.Shipyard);
            (spaceship.Shipyard, spaceship.Fleet) = (null, null);
            (spaceship.FleetId, spaceship.ShipyardId) = (fleet.Id, shipyard.Id);

            using (var context = new SpaceshipsContext())
            {
                if (context.Spaceships.Any(s => s.Id == spaceship.Id))
                {
                    context.Attach(spaceship); // Updating
                }
                else
                {
                    context.Add(spaceship); // Creating new
                }

                try
                {
                    context.SaveChanges();
                    (spaceship.Fleet, spaceship.Shipyard) = (fleet, shipyard);
                }
                catch (ValidationException ex)
                {
                    e.Cancel = true;
                    var builder = new StringBuilder();
                    foreach (var m in ex.Errors.Select(e => e.ErrorMessage))
                    {
                        builder.Append("\n- ");
                        builder.Append(m);
                    }
                    MessageBox.Show(builder.ToString(), ex.Message, MessageBoxButton.OKCancel,
                        MessageBoxImage.Error, MessageBoxResult.OK);
                }
            }
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
            using (var context = new SpaceshipsContext())
            {
                context.RemoveRange(selected);
                context.SaveChanges();
            }
        }

        private class Context
        {
            public List<Spaceship> Spaceships { get; set; }
            public List<Fleet> Fleets { get; set; }
            public List<Shipyard> Shipyards { get; set; }
        }
    }
}
