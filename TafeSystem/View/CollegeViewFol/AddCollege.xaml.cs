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
namespace TafeSystemUI.View.CollegeViewFol
{
    /// <summary>
    /// Interaction logic for AddCollege.xaml
    /// </summary>
    public partial class AddCollege : Page
    {
        private CollegeController collegeController = new CollegeController();
        public AddCollege()
        {
            InitializeComponent();
        }


        private void AddCollegeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = collegeController.AddCollege(CollegeName.Text, CollegeLocation.Text);
                if (result == 1)
                {
                    MessageBox.Show("College Added");
                    NavigationService.Navigate(new CollegeView());
                }
                else
                {
                    MessageBox.Show("Could not add College. Check input.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollegeView());
        }
    }
}
