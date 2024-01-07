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
namespace TafeSystemUI.View.StudentViewFol
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        private StudentController sc = new StudentController();
        public AddStudent()
        {
            InitializeComponent();
        }

        private void State_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = sc.AddStudent(FirstName.Text, LastName.Text, DOB.SelectedDate.Value, StreetAddress.Text, Suburb.Text, State.Text, PostCode.Text, Mobile.Text, Gender.Text, Email.Text);
                if (PostCode.Text.Length != 4 || PostCode.Text.ToString().All(char.IsDigit) != true)
                {
                    MessageBox.Show("Postcode has to be four characters and all have to be numbers");
                }
                else if (Mobile.Text.Length != 10 || Mobile.Text.ToString().All(char.IsDigit) != true)
                {
                    MessageBox.Show("Mobile has to be ten characters and all have to be numbers");
                }
                else if (result == 1)
                {
                    MessageBox.Show("Student Added");
                    NavigationService.Navigate(new StudentView());
                }
                else
                {
                    MessageBox.Show("Could not add Student. Check input.");
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
