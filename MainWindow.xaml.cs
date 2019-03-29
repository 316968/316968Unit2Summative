/*
 * quinn parker-joyes
 * march 28 2019
 * unit 2 summative
 * stores contact info, shows age of user in years, and saved contact info and shows saved contact info on re opening of program
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _316968_Unit2Summative
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Contact contactPlaceholder = new Contact("temp", "temp", 0, 0, 0, "temp");
                string[] contactinfo = contactPlaceholder.ReadFromFile();
                txtFirstName.Text = contactinfo[0];
                txtLastName.Text = contactinfo[1];
                int.TryParse(contactinfo[2], out int day);
                txtDay.Text = day.ToString();
                int.TryParse(contactinfo[3], out int month);
                txtMonth.Text = month.ToString();
                int.TryParse(contactinfo[4], out int year);
                txtYear.Text = year.ToString();
                txtEmail.Text = contactinfo[5];
            }
            catch
            {
                MessageBox.Show("Sorry! NO INFORMATION FOUND, file missing >:(");
            }
        }

        public void btnContact_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                
                int Day, Month, Year;
                int.TryParse(txtDay.Text, out Day);
                int.TryParse(txtMonth.Text, out Month);
                int.TryParse(txtYear.Text, out Year);
                
                Contact contactCurrent = new Contact(txtFirstName.Text, txtLastName.Text, Day, Month, Year, txtEmail.Text);
                
                contactCurrent.getAge();
                
                //contact.sw.WriteLine(contact.temp);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int Day, Month, Year;
            int.TryParse(txtDay.Text, out Day);
            int.TryParse(txtMonth.Text, out Month);
            int.TryParse(txtYear.Text, out Year);
            Contact contactClosed = new Contact(txtFirstName.Text, txtLastName.Text, Day, Month, Year, txtEmail.Text);
            contactClosed.SaveToFile();
        }


        /*private void btnAge_Click(object sender, RoutedEventArgs e)
{

}*/

        /// do a thing where when the user enters info it checks if its already been added, and in the catch statement it runs the show age thing
    }
}
