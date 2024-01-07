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
using TafeSystemUI.View.UnitViewFol;
using Domain;
namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for UnitView.xaml
    /// </summary>
    public partial class UnitView : Page
    {
        private CourseController cc = new CourseController();
        public UnitView()
        {
            InitializeComponent();
            try
            {

                dgUnits.ItemsSource = cc.GetUnits();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new MenuView());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void AddUnit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new AddUnit());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cc.DeleteUnit(((Unit)((Button)e.Source).DataContext).UnitId1);
                dgUnits.ItemsSource = cc.GetUnits();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UnitsNotCourseSemester_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                dgUnits.ItemsSource = cc.GetUnitsNotInCourseOrSemester();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
