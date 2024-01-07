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
using TafeSystemUI.View.ClusterViewFol;

namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for ClusterView.xaml
    /// </summary>
    public partial class ClusterView : Page
    {
        private CourseController courseCon = new CourseController();
        private SemesterController semesterController = new SemesterController();
        public ClusterView()
        {
            InitializeComponent();
            try
            {
                IEnumerable<Semester> semesters = semesterController.GetSemesters();
                int count = 0;
                foreach (Semester s in semesters)
                {
                    Semester.Items.Insert(count, s.StartDate1.ToString("yyyy-MM-dd") + "/" + s.EndDate1.ToString("yyyy-MM-dd"));
                    count++;
                }
                count = 0;
                dgClusters.ItemsSource = courseCon.GetClusters().DistinctBy(c =>c.ClusterId1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new MenuView());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int result = courseCon.DeleteCluster(((Cluster)((Button)e.Source).DataContext).ClusterId1);
                if (result >= 1)
                {
                    MessageBox.Show("Cluster deleted");
                }
                else
                {
                    MessageBox.Show("Unable to delete Cluster");
                }
                dgClusters.ItemsSource = courseCon.GetClusters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddCluster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new AddCluster());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new ClusterUnit((Cluster)((Button)e.Source).DataContext));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] semDates = Semester.Text.Split("/");
                dgClusters.ItemsSource = courseCon.GetClustersBySemester(semDates[0], semDates[1]).DistinctBy(c => c.ClusterId1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
