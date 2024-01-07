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
using Domain;
using TafeSystemUI.View.SemesterViewFol;

namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for SemesterView.xaml
    /// </summary>
    public partial class SemesterView : Page
    {
        private SemesterController semesterController = new SemesterController();
        public SemesterView()
        {
            InitializeComponent();
            try
            {

                dgSemesters.ItemsSource = semesterController.GetSemesters();
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                semesterController.DeleteSemester(((Semester)((Button)e.Source).DataContext).SemesterId1);
                dgSemesters.ItemsSource = semesterController.GetSemesters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddSemester_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSemester());
        }
    }
}
