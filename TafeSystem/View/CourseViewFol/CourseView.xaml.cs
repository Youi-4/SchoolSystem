using System;
using System.Collections.Generic;
using System.Linq;
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
using TafeSystemUI.View.CourseViewFol;

namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for CourseView.xaml
    /// </summary>
    public partial class CourseView : Page
    {
        private CourseController cc = new CourseController();
        public CourseView()
        {
            InitializeComponent();
            try
            {

                dgCourses.ItemsSource = cc.GetCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CourseClusterView((Course)((Button)e.Source).DataContext));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuView());
        }

        private void CoursesNotInSemester_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                dgCourses.ItemsSource = cc.GetCoursesNotInAnySemester();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCourse());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int result = cc.DeleteCourse(((Course)((Button)e.Source).DataContext).CourseId1);
                if (result >= 1)
                {
                    MessageBox.Show("Course deleted");
                }
                else
                {
                    MessageBox.Show("Unable to delete Course");
                }
                dgCourses.ItemsSource = cc.GetCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
