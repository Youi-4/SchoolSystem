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
using TafeSystemUI.View.TeacherViewFol;

namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for Teachers.xaml
    /// </summary>
    public partial class TeacherView : Page
    {
        private TeacherController teacherC = new TeacherController();
        private Teacher teacher;
        public TeacherView()
        {
            InitializeComponent();
            try
            {
                SemesterController semesterController = new SemesterController();
                CollegeController collegeController = new CollegeController();
                IEnumerable<Semester> semesters = semesterController.GetSemesters();
                IEnumerable<College> colleges = collegeController.GetColleges();
                int count = 0;
                foreach(Semester s in semesters)
                {
                    Semester.Items.Insert(count, s.StartDate1.ToString("yyyy-MM-dd") + "/" + s.EndDate1.ToString("yyyy-MM-dd"));
                    count++;
                }
                count = 0;
                foreach (College college in colleges)
                {
                    Location.Items.Insert(count,college.Name1);
                    count++;
                }
                count = 0;
                dgTeachers.ItemsSource = teacherC.GetTeachers();
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

        private void AddTeacher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeacher());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdateTeacher((Teacher)((Button)e.Source).DataContext));
        }

        private void Location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            dgTeachers.ItemsSource = null;
            if (string.IsNullOrEmpty(Location.Text) && string.IsNullOrEmpty(Semester.Text) && string.IsNullOrEmpty(EmploymentStatus.Text))
            {
                MessageBox.Show("Nothing selected");
            }
            else if (!string.IsNullOrEmpty(Location.Text) && string.IsNullOrEmpty(Semester.Text) && string.IsNullOrEmpty(EmploymentStatus.Text))
            {
                dgTeachers.ItemsSource = teacherC.GetTeachersByLocation(Location.Text).DistinctBy(t => t.TeacherId1);
            }
            else if (string.IsNullOrEmpty(Location.Text) && !string.IsNullOrEmpty(Semester.Text) && string.IsNullOrEmpty(EmploymentStatus.Text))
            {
                string[] semDates = Semester.Text.Split("/");
                dgTeachers.ItemsSource = teacherC.GetTeachersBySemester(semDates[0], semDates[1]).DistinctBy(t => t.TeacherId1);
            }
            else if (string.IsNullOrEmpty(Location.Text) && string.IsNullOrEmpty(Semester.Text) && !string.IsNullOrEmpty(EmploymentStatus.Text))
            {
                dgTeachers.ItemsSource = teacherC.GetTeachersByEmployment(EmploymentStatus.Text).DistinctBy(t => t.TeacherId1);

            }
            else if (!string.IsNullOrEmpty(Location.Text) && !string.IsNullOrEmpty(Semester.Text) && string.IsNullOrEmpty(EmploymentStatus.Text))
            {
                string[] semDates = Semester.Text.Split("/");
                dgTeachers.ItemsSource = teacherC.GetTeachersBySemesterAndLocation(Location.Text, semDates[0], semDates[1]).DistinctBy(t => t.TeacherId1);

            }
            else if (string.IsNullOrEmpty(Location.Text) && !string.IsNullOrEmpty(Semester.Text) && !string.IsNullOrEmpty(EmploymentStatus.Text))
            {
                string[] semDates = Semester.Text.Split("/");
                dgTeachers.ItemsSource = teacherC.GetTeachersBySemesterAndEmployment(EmploymentStatus.Text, semDates[0], semDates[1]).DistinctBy(s => s.TeacherId1);
            }
            else if (!string.IsNullOrEmpty(Location.Text) && string.IsNullOrEmpty(Semester.Text) && !string.IsNullOrEmpty(EmploymentStatus.Text))
            {
                dgTeachers.ItemsSource = teacherC.GetTeachersByLocationAndEmploymentStatus(EmploymentStatus.Text, Location.Text).DistinctBy(t => t.TeacherId1);
            }
            else
            {
                string[] semDates = Semester.Text.Split("/");
                dgTeachers.ItemsSource = teacherC.GetTeachersBySemesterAndLocationAndEmploymentStatus(EmploymentStatus.Text,Location.Text, semDates[0], semDates[1]).DistinctBy(t => t.TeacherId1);
            }
        }

        private void Semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EmploymentStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherCourse((Teacher)((Button)e.Source).DataContext));
        }

        private void btnEnterName_Click(object sender, RoutedEventArgs e)
        {

        }


        private void EnterDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Passwordbox1.Password == teacher.Password1)
                {
                    PasswordInput.Visibility = System.Windows.Visibility.Collapsed;
                    teacherC.DeleteTeacher(teacher.TeacherId1);
                    teacher = null;
                    dgTeachers.ItemsSource = teacherC.GetTeachers();
                }
                else
                {
                    MessageBox.Show("Incorrect password");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            PasswordInput.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void DeleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                teacher = (Teacher)((Button)e.Source).DataContext;
                PasswordInput.Visibility = System.Windows.Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OtherThanBaseLoc_Click(object sender, RoutedEventArgs e)
        {
            dgTeachers.ItemsSource = teacherC.GetTeachersByNotInBasedLocation(DateTime.Now.ToString()).DistinctBy(t => t.TeacherId1);
        }

    }
}
