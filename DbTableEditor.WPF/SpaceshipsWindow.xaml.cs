using System.Linq;
using System.Windows;
using DbTableEditor.WPF.Context;

namespace DbTableEditor.WPF
{
    public partial class SpaceshipsWindow : Window
    {
        public SpaceshipsWindow()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupGrid()
        {
            using var context = new SpaceshipsContext();
            Grid.DataContext = context.Spaceships.ToList();
        }
    }
}
