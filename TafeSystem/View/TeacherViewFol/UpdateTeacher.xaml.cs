using Controller;
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
using Domain;
namespace TafeSystemUI.View.TeacherViewFol
{
    /// <summary>
    /// Interaction logic for UpdateTeacher.xaml
    /// </summary>
    public partial class UpdateTeacher : Page
    {
        private TeacherController teacherC = new TeacherController();
        private Teacher t;
        public UpdateTeacher(Teacher teacher)
        {
            
            InitializeComponent();
            try
            {
                CollegeController collegeController = new CollegeController();
                IEnumerable<College> colleges = collegeController.GetColleges();
                int count = 0;
                foreach (College college in colleges)
                {
                    BasedLocCombo.Items.Insert(count, college.Name1);
                    count++;
                }
                count = 0;
                dgTeachers.Items.Add(teacher);
                t = teacher;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void State_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        DateTime _dob;
        private void UpdateTeacherBtn_Click(object sender, RoutedEventArgs e)
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
                if (string.IsNullOrEmpty(PasswordboxOriginal.Password))
                {
                    MessageBox.Show("Please supply original password before updating");
                }
                else if (PasswordboxOriginal.Password != t.Password1)
                {
                    MessageBox.Show("Supplied original Password incorrect");
                }
                else if (Passwordbox1.Password != Passwordbox2.Password)
                {
                    MessageBox.Show("Passwords do not match");
                }
                else if ((PostCode.Text.Length != 4 || PostCode.Text.ToString().All(char.IsDigit) != true) && !string.IsNullOrEmpty(PostCode.Text.ToString()))
                {
                    MessageBox.Show("Postcode has to be four characters and all have to be numbers");
                }
                else
                {
                    
                    int result = teacherC.UpdateTeacher(t.TeacherId1,FirstName.Text, LastName.Text, _dob, StreetAddress.Text, Suburb.Text, State.Text, PostCode.Text, Mobile.Text, Gender.Text, Email.Text, Passwordbox1.Password, BasedLocCombo.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("Teacher Updated");
                        NavigationService.Navigate(new TeacherView());
                    }
                    else if (result == 4)
                    {
                        MessageBox.Show("Nothing Updated all was blank");
                        NavigationService.Navigate(new TeacherView());
                    }
                    else
                    {
                        MessageBox.Show("Could not update Teacher. Check input.");
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
