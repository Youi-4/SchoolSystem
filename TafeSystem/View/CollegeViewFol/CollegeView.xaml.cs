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
using TafeSystemUI.View.CollegeViewFol;
using Domain;
namespace TafeSystemUI.View
{
    /// <summary>
    /// Interaction logic for CollegeView.xaml
    /// </summary>
    public partial class CollegeView : Page
    {
        private CollegeController collegeController = new CollegeController();
        public CollegeView()
        {
            InitializeComponent();
            try
            {

                dgColleges.ItemsSource = collegeController.GetColleges();
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

        private void AddCollege_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCollege());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                collegeController.DeleteCollege(((College)((Button)e.Source).DataContext).CollegeId1);
                dgColleges.ItemsSource = collegeController.GetColleges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
