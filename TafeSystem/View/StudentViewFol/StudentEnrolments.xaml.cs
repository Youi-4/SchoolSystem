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
namespace TafeSystemUI.View.StudentViewFol
{
    /// <summary>
    /// Interaction logic for StudentEnrolments.xaml
    /// </summary>
    public partial class StudentEnrolments : Page
    {
        private StudentController sc = new StudentController();
        public StudentEnrolments(Student student)
        {
            InitializeComponent();
            try
            {
                dgStudent.Items.Add(student);
                dgStudentEnrolments.ItemsSource = sc.GetStudentEnrolments(student).Enrolments;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentView());
        }
    }
}
