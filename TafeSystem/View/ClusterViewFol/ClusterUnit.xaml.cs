using System;
using System.Collections.Generic;
using System.Text;
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
using MoreLinq;

namespace TafeSystemUI.View.ClusterViewFol
{
    /// <summary>
    /// Interaction logic for ClusterUnit.xaml
    /// </summary>
    public partial class ClusterUnit : Page
    {
        public ClusterUnit(Cluster cluster)
        {
            InitializeComponent();
            try
            {
                dgUnits.ItemsSource = cluster.Units.DistinctBy(c => c.UnitId1); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClusterView());
        }
    }
}
