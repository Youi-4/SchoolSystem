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
using MoreLinq;
using TafeSystemUI.View.StudentViewFol;

namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Page
    {
        private StudentController sc = new StudentController();
        public StudentView()
        {
            InitializeComponent();
            try
            {
                SemesterController semesterController = new SemesterController();
                CollegeController collegeController = new CollegeController();
                IEnumerable<Semester> semesters = semesterController.GetSemesters();
                IEnumerable<College> colleges = collegeController.GetColleges();
                int count = 0;
                foreach (Semester s in semesters)
                {
                    Semester.Items.Insert(count, s.StartDate1.ToString("yyyy-MM-dd") + "/" + s.EndDate1.ToString("yyyy-MM-dd"));
                    count++;
                }
                count = 0;
                foreach (College college in colleges)
                {
                    Location.Items.Insert(count, college.Name1);
                    count++;
                }
                count = 0;
                dgStudents.ItemsSource = sc.GetStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuView());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sc.DeleteStudent(((Student)((Button)e.Source).DataContext).StudentId1);
                dgStudents.ItemsSource = sc.GetStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStudent());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdateStudent((Student)((Button)e.Source).DataContext));
        }

        private void StudyStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            string[] semDates;
            dgStudents.ItemsSource = null;
            if (string.IsNullOrEmpty(Location.Text) && string.IsNullOrEmpty(Semester.Text) && string.IsNullOrEmpty(StudyStatus.Text))
            {
                MessageBox.Show("Nothing selected");
            }
            else if (!string.IsNullOrEmpty(Location.Text) && string.IsNullOrEmpty(Semester.Text) && string.IsNullOrEmpty(StudyStatus.Text))
            {
                dgStudents.ItemsSource = sc.GetStudentsByLocation(Location.Text).DistinctBy(s => s.StudentId1);
            }
            else if (string.IsNullOrEmpty(Location.Text) && !string.IsNullOrEmpty(Semester.Text) && string.IsNullOrEmpty(StudyStatus.Text))
            {
                semDates = Semester.Text.Split("/");
                dgStudents.ItemsSource = sc.GetStudentsBySemester(semDates[0], semDates[1]).DistinctBy(s => s.StudentId1);
            }
            else if (string.IsNullOrEmpty(Location.Text) && string.IsNullOrEmpty(Semester.Text) && !string.IsNullOrEmpty(StudyStatus.Text))
            {
                dgStudents.ItemsSource = sc.GetStudentsByStudyStatus(StudyStatus.Text).DistinctBy(s => s.StudentId1);

            }
            else if (!string.IsNullOrEmpty(Location.Text) && !string.IsNullOrEmpty(Semester.Text) && string.IsNullOrEmpty(StudyStatus.Text))
            {
                semDates = Semester.Text.Split("/");
                dgStudents.ItemsSource = sc.GetStudentsBySemesterAndLocation(Location.Text, semDates[0], semDates[1]).DistinctBy(s => s.StudentId1);

            }
            else if (string.IsNullOrEmpty(Location.Text) && !string.IsNullOrEmpty(Semester.Text) && !string.IsNullOrEmpty(StudyStatus.Text))
            {
                semDates = Semester.Text.Split("/");
                dgStudents.ItemsSource = sc.GetStudentsBySemesterAndStudyStatus(StudyStatus.Text, semDates[0], semDates[1]).DistinctBy(s => s.StudentId1);
            }
            else if (!string.IsNullOrEmpty(Location.Text) && string.IsNullOrEmpty(Semester.Text) && !string.IsNullOrEmpty(StudyStatus.Text))
            {
                dgStudents.ItemsSource = sc.GetStudentsByStudyStatusAndLocation(Location.Text,StudyStatus.Text).DistinctBy(s => s.StudentId1);
            }
            else
            {
                semDates = Semester.Text.Split("/");
                dgStudents.ItemsSource = sc.GetStudentsBySemesterAndLocationAndStudyStatus(StudyStatus.Text, Location.Text, semDates[0], semDates[1]).DistinctBy(s => s.StudentId1);
            }

        }

        private void NotPaid_Click(object sender, RoutedEventArgs e)
        {
            dgStudents.ItemsSource = sc.GetStudentsEnrolledNotPaid().DistinctBy(s => s.StudentId1);
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentEnrolments((Student)((Button)e.Source).DataContext));
        }
    }
}
