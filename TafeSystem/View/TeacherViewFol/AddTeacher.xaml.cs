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
namespace TafeSystemUI.View.TeacherViewFol
{
    /// <summary>
    /// Interaction logic for AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Page
    {
        private TeacherController teacherC = new TeacherController();
        public AddTeacher()
        {
            InitializeComponent();
            CollegeController collegeController = new CollegeController();
            IEnumerable<College> colleges = collegeController.GetColleges();
            int count = 0;
            foreach (College college in colleges)
            {
                BasedLocCombo.Items.Insert(count, college.Name1);
                count++;
            }
            count = 0;
        }
        private void State_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddTeacherBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Passwordbox1.Password != Passwordbox2.Password)
                {
                    MessageBox.Show("Passwords do not match");
                }
                else if(PostCode.Text.Length != 4 || PostCode.Text.ToString().All(char.IsDigit) != true)
                {
                    MessageBox.Show("Postcode has to be four characters and all have to be numbers");
                }
                else if (Mobile.Text.Length != 10 || Mobile.Text.ToString().All(char.IsDigit) != true)
                {
                    MessageBox.Show("Mobile has to be ten characters and all have to be numbers");
                }
                else
                {
                    int result = teacherC.AddTeacher(FirstName.Text, LastName.Text, DOB.SelectedDate.Value, StreetAddress.Text, Suburb.Text, State.Text, PostCode.Text, Mobile.Text, Gender.Text, Email.Text, Passwordbox1.Password, BasedLocCombo.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("Teacher Added");
                        NavigationService.Navigate(new TeacherView());
                    }
                    else
                    {
                        MessageBox.Show("Could not add Teacher. Check input.");
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
            NavigationService.Navigate(new TeacherView());
        }

        private void Gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DOB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BasedLocCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
