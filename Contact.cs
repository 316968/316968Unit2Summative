/*
*Quinn parker-joyes
* ics4u
* unit 2 summative
* contact class, saves contact info, reads that info, and shows age of contact
* march 29 2019
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _316968_Unit2Summative
{
    public class Contact
    {
        // global variables
        private string firstName;
        private string lastName;
        private int day;
        private int month;
        private int year;
        private string email;
       
        // temp is used to remove commas from the contact info, so the 
        public string temp;

        public List<string> list = new List<string>();
       
        
        public Contact (string fN, string lN, int d, int m, int y, string eA)
        {
            //constructor
            firstName = fN;
            lastName = lN;           
            day = d;
            month = m;
            year = y;
            email = eA;
        }
        public void getAge()
        {
            //int tempAge;

            try
            {
                DateTime birthDay = new DateTime(year, month, day);
                DateTime current = new DateTime();
                current = DateTime.Today;
                TimeSpan age = current.Subtract(birthDay);
                //int.TryParse(age.ToString(), out tempAge);
                //the 365.25 accounts for leap years?
                double ageRounded = Math.Floor(age.Days / 365.25);
                MessageBox.Show("you are " + ageRounded.ToString() + " years old");
               

            }
            catch
            {
                MessageBox.Show("Please enter valid date");
                
            }
                
                
                
            
        }
        public void SaveToFile()
        {
            
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter("savedFile.txt");
                string tempFirstName = "";
                string tempLastName = "";
                string tempEmail = "";
                //removes commas from input because that breaks the program, because the lines are comma separated
                if (firstName.Contains(',') || lastName.Contains(',') || email.Contains(','))
                {
                    for (int i = 0; i<firstName.Split(',').Length; i++)
                    {
                        tempFirstName += firstName.Split(',')[i];
                    }
                    for(int j = 0; j<lastName.Split(',').Length; j++)
                    {
                        tempLastName += lastName.Split(',')[j];
                    }
                    for(int h = 0; h < email.Split(',').Length; h++)
                    {
                        tempEmail += email.Split(',')[h];
                    }
                    
                    firstName = tempFirstName;
                }
                //makes it so the user can't enter a negative year month or day
                string tempDay, tempMonth, tempYear;
                tempDay = day.ToString();
                tempMonth = month.ToString();
                tempYear = year.ToString();
                int.TryParse((tempDay.Split('-')).ToString(), out day);
                int.TryParse((tempMonth.Split('-').ToString(), out month);
                int.TryParse((tempYear.Split('-').ToString(), out year);
                
                //temp is the line that is going to be written
                temp = (firstName + "," + lastName + "," + day + "," + month + "," + year + "," + email).ToString();
                sw.WriteLine(temp);
                sw.Flush();
                sw.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public string[] ReadFromFile()
        {   
            try
            {
                //reads the file and splits all commas from the line
                System.IO.StreamReader streamReader = new System.IO.StreamReader("savedFile.txt");
                string[] contactArray = streamReader.ReadLine().Split(',');
                return contactArray;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }

    }
}
