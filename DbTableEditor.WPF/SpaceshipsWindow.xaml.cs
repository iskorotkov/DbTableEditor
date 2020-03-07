using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DbTableEditor.WPF.Context;
using DbTableEditor.WPF.Model;

namespace DbTableEditor.WPF
{
    public partial class SpaceshipsWindow : Window
    {
        private bool _rowCommiting;

        public SpaceshipsWindow()
        {
            InitializeComponent();
            SetupGrid();

            Grid.RowEditEnding += GridOnRowEditEnding;
        }

        private void GridOnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (_rowCommiting)
            {
                return;
            }

            var spaceship = (Spaceship)e.Row.Item;
            using var context = new SpaceshipsContext();
            context.Attach(spaceship);

            _rowCommiting = true;
            Grid.CommitEdit();
            _rowCommiting = false;

            context.SaveChanges();
        }

        private void SetupGrid()
        {
            using var context = new SpaceshipsContext();
            Grid.DataContext = context.Spaceships.ToList();
        }
    }
}
