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
using System.Linq;
using Controller;
using Domain;
namespace TafeSystemUI.View.CourseViewFol
{
    /// <summary>
    /// Interaction logic for AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Page
    {
        private CourseController courseCon = new CourseController();
        Course newCourse = new Course();
        IEnumerable<Cluster> clusters;
        public AddCourse()
        {
            InitializeComponent();
            try
            {
                clusters = courseCon.GetClusters();
                dgClusters.ItemsSource = clusters;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (newCourse.Clusters.Count >= 3)
            {
                MessageBox.Show("the max amount of clusters that can be allocated to a course is 3");
            }
            else
            {
                newCourse.addCluster((Cluster)((Button)e.Source).DataContext);
                dgSelectedClusters.Items.Clear();
                foreach (Cluster c in newCourse.Clusters)
                {
                    dgSelectedClusters.Items.Add(c);
                }
                clusters = clusters.Where(c => c.ClusterId1 != ((Cluster)((Button)e.Source).DataContext).ClusterId1).ToList();

                dgClusters.ItemsSource = clusters;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CourseView());
        }

        private void AddCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Description.Text))
            {
                MessageBox.Show("Cannot leave name or description empty");
            }
            else if (HoursPerWeek.Text.ToString().All(char.IsDigit) != true || Cost.Text.ToString().All(char.IsDigit) != true)
            {
                MessageBox.Show("Hours per week and cost must be numbers");
            }
            else if (newCourse.Clusters.Count != 3)
            {
                MessageBox.Show("A Course must have only and at least 3 clusters with in it");
            }
            else
            {
                courseCon.AddCourse(Name.Text, Description.Text,int.Parse(Cost.Text), int.Parse(HoursPerWeek.Text), newCourse.Clusters[0].ClusterId1, newCourse.Clusters[1].ClusterId1, newCourse.Clusters[2].ClusterId1);
                NavigationService.Navigate(new CourseView());
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            clusters = clusters.Concat(new[] { (Cluster)((Button)e.Source).DataContext });
            newCourse.Clusters.Remove((Cluster)((Button)e.Source).DataContext);
            dgSelectedClusters.Items.Clear();
            foreach (Cluster c in newCourse.Clusters)
            {
                dgSelectedClusters.Items.Add(c);
            }
            dgClusters.ItemsSource = clusters.OrderBy(c => c.ClusterId1);
        }
    }
}
