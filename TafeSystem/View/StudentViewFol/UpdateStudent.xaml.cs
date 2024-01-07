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
namespace TafeSystemUI.View.StudentViewFol
{
    /// <summary>
    /// Interaction logic for UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : Page
    {
        private StudentController sc = new StudentController();
        private Student S;
        public UpdateStudent(Student s )
        {

            InitializeComponent();
            try
            {
                dgStudents.Items.Add(s);
                S = s;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void State_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        DateTime _dob;
        private void UpdateStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (!DOB.SelectedDate.HasValue)
                {
                    _dob = DateTime.Parse("9999-11-11");
                }
                else
                {
                    _dob = DOB.SelectedDate.Value;
                }
                if ((PostCode.Text.Length != 4 || PostCode.Text.ToString().All(char.IsDigit) != true) && !string.IsNullOrEmpty(PostCode.Text.ToString()))
                {
                    MessageBox.Show("Postcode has to be four characters and all have to be numbers");
                }
                else
                {
                    int result = sc.UpdateStudent(S.StudentId1, FirstName.Text, LastName.Text, _dob, StreetAddress.Text, Suburb.Text, State.Text, PostCode.Text, Mobile.Text, Gender.Text, Email.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("Student Updated");
                        NavigationService.Navigate(new StudentView());
                    }
                    else if (result == 4)
                    {
                        MessageBox.Show("Nothing Updated all was blank");
                        NavigationService.Navigate(new StudentView());
                    }
                    else
                    {
                        MessageBox.Show("Could not update Student. Check input.");
                    }
                }


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

        private void Gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DOB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
