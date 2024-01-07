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
    /// Interaction logic for CourseClusterView.xaml
    /// </summary>
    public partial class CourseClusterView : Page
    {
        public Course c;
        public CourseClusterView(Course course)
        {
            InitializeComponent();
            try
            {
                c = course;
                Label.Content = Label.Content + course.Name1;
                dgClusters.ItemsSource = course.Clusters;
                DataContext = course.Clusters;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CourseClusterUnitView(c,(Cluster)((Button)e.Source).DataContext));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CourseView());
        }
    }
}
