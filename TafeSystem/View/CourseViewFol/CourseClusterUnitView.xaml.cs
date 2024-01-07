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
using Domain;
namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for CourseClusterUnitView.xaml
    /// </summary>
    public partial class CourseClusterUnitView : Page
    {
        public Course c;
        public CourseClusterUnitView(Course c,Cluster cluster)
        {
            InitializeComponent();
            try
            {
                this.c = c;
                dgUnits.ItemsSource = cluster.Units;
                DataContext = cluster.Units;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new CourseClusterView(c));
        }
    }
}
