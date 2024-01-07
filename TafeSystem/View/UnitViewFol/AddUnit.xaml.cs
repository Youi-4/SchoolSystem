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
namespace TafeSystemUI.View.UnitViewFol
{
    /// <summary>
    /// Interaction logic for AddUnit.xaml
    /// </summary>
    public partial class AddUnit : Page
    {
        private CourseController cc = new CourseController();
        public AddUnit()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UnitView());
        }

        private void AddUnitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = cc.AddUnit(UnitCode.Text,UnitDescription.Text,UnitType.Text);
                if (result == 1)
                {
                    MessageBox.Show("Unit Added");
                    NavigationService.Navigate(new UnitView());
                }
                else
                {
                    MessageBox.Show("Could not add Unit. Check input.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
