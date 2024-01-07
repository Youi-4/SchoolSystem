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
using Controller;
namespace TafeSystemUI.View.SemesterViewFol
{
    /// <summary>
    /// Interaction logic for AddSemester.xaml
    /// </summary>
    public partial class AddSemester : Page
    {
        private SemesterController semesterController = new SemesterController();
        public AddSemester()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SemesterView());
        }

        private void AddSemesterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = semesterController.AddSemester(startDate.SelectedDate.Value,endDate.SelectedDate.Value);
                if (result == 1)
                {
                    MessageBox.Show("Semester Added");
                    NavigationService.Navigate(new SemesterView());
                }
                else
                {
                    MessageBox.Show("Could not add Semester. Check input.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void startDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void endDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
