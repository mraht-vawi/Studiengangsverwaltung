﻿using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace Universitätsverwaltung.controller
{
    public class ListViewSorter
    {
        private GridViewColumnHeader lastHeaderClicked = null;
        private ListSortDirection lastDirection = ListSortDirection.Ascending;

        public void SortHeader(GridViewColumnHeader headerClicked, string attrName, ListView listView)
        {
            ListSortDirection direction;

            if (headerClicked != null && listView.Items.Count > 0)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    if (attrName == null 
                        || attrName.Equals(""))
                    {
                        attrName = headerClicked.Column.Header as string;
                    }

                    switch(attrName)
                    {
                        case "X":
                            return;
                    }

                    Sort(attrName, direction, listView);

                    lastHeaderClicked = headerClicked;
                    lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction, ListView listView)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(listView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }
    }
}
