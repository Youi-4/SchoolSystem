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

namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : Page
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void Teachers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherView());
        }

        private void Students_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentView());
        }

        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CourseView());
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UnitView());
        }

        private void Colleges_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollegeView());
        }

        private void Semesters_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SemesterView());
        }

        private void ClustersBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClusterView());
        }
    }
}
