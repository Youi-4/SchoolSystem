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
using Controller;
using System.Linq;
using MoreLinq;

namespace TafeSystemUI.View.TeacherViewFol
{
    /// <summary>
    /// Interaction logic for TeacherCourse.xaml
    /// </summary>
    public partial class TeacherCourse : Page
    {
        Teacher t;
        TeacherController Tcontroller = new TeacherController();
        private SemesterController semesterController = new SemesterController();
        public TeacherCourse(Teacher teacher)
        {
            
            InitializeComponent();
            t = teacher;
            try
            {
                IEnumerable<Semester> semesters = semesterController.GetSemesters();
                int count = 0;
                foreach (Semester s in semesters)
                {
                    TeacherSemester.Items.Insert(count, s.StartDate1.ToString("yyyy-MM-dd") + "/" + s.EndDate1.ToString("yyyy-MM-dd"));
                    count++;
                }
                count = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AllCourses_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgCourses.ItemsSource = Tcontroller.GetTeacherCourses(t.TeacherId1).DistinctBy(c => c.CourseId1);
                dgColleges.ItemsSource = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherView());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] semDates = TeacherSemester.Text.Split("/");
                dgColleges.ItemsSource = Tcontroller.GetTeacherCollegeBySemester(t.TeacherId1, semDates[0], semDates[1]).DistinctBy(c => c.CollegeId1);
                dgCourses.ItemsSource = Tcontroller.GetTeacherCourseBySemester(t.TeacherId1, semDates[0], semDates[1]).DistinctBy(c => c.CourseId1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void TeacherSemester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
