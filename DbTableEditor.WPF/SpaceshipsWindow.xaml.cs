﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;

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

                // TODO: set real fleet and shipyard IDs
                spaceship.FleetId = 1;
                spaceship.ShipyardId = 1;
            }

            CommitRowEdit();
            context.SaveChanges();
        }

        private void SetupGrid()
        {
            using var context = new SpaceshipsContext();
            Grid.DataContext = context.Spaceships
                .OrderBy(s => s.Id)
                .ToList();
        }
    }
}
