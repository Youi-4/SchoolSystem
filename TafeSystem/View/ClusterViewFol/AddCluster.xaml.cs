using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
using Domain;
namespace TafeSystemUI.View.ClusterViewFol
{
    /// <summary>
    /// Interaction logic for AddCluster.xaml
    /// </summary>
    public partial class AddCluster : Page
    {
        CourseController cc = new CourseController();
        Cluster cluster = new Cluster();
        IEnumerable<Unit> units;
        public AddCluster()
        {
            InitializeComponent();
            try
            {
                units = cc.GetUnits();
                dgUnits.ItemsSource = units;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddClusterBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(ClusterName.Text) || string.IsNullOrEmpty(Description.Text))
            {
                MessageBox.Show("Cannot leave name or description empty");
            }
            else if (cluster.Units.Count != 3)
            {
                MessageBox.Show("A cluster must have only and at least 3 units with in it");
            }
            else
            {
                cc.AddCluster(ClusterName.Text, Description.Text, cluster.Units[0].UnitId1, cluster.Units[1].UnitId1, cluster.Units[2].UnitId1);
                NavigationService.Navigate(new ClusterView());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClusterView());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cluster.Units.Count >= 3)
            {
                MessageBox.Show("the max amount of units that can be allocated to a clust is 3");
            }
            else
            {
                cluster.AddUnit((Unit)((Button)e.Source).DataContext);
                dgSelectedUnits.Items.Clear();
                foreach(Unit u in cluster.Units)
                {
                    dgSelectedUnits.Items.Add(u);
                }
                units = units.Where(u => u.UnitId1 != ((Unit)((Button)e.Source).DataContext).UnitId1).ToList();
                
                dgUnits.ItemsSource = units;
            }
            
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            units = units.Concat(new[] { (Unit)((Button)e.Source).DataContext });
            cluster.Units.Remove((Unit)((Button)e.Source).DataContext);
            dgSelectedUnits.Items.Clear();
            foreach (Unit u in cluster.Units)
            {
                dgSelectedUnits.Items.Add(u);
            }
            dgUnits.ItemsSource = units.OrderBy(u => u.UnitId1);
        }
    }
}
