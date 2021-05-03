using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinesOntario
{
    class Date
    {
        //private variables
        private int day;
        private int month;
        private int year;

        //Constructors
        //Default Constructor
        public Date()
        {

        }

        //Parameterized Constructor
        //This constructor will take a string that is written like DD/MM/YYYY
        //and will seperate the data using the / as a delimeter
        public Date(string date)
        {
            string[] dates = date.Split('/');

            try
            {
                int day = int.Parse(dates[0]);
                int month = int.Parse(dates[1]);
                int year = int.Parse(dates[2]);

                //construct the date
                setDay(day);
                setMonth(month);
                setYear(year);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Date(int day, int month, int year)
        {
            setDay(day);
            setMonth(month);
            setYear(year);
        }

        //Getters and Setters
        public int getDay()
        {
            return day;
        }

        public void setDay(int day)
        {
            this.day = day;
        }

        public int getMonth()
        {
            return month;
        }

        public void setMonth(int month)
        {
            this.month = month;
        }

        public int getYear()
        {
            return year;
        }

        public void setYear(int year)
        {
            this.year = year;
        }


        //Methods
        public override string ToString()
        {
            return day.ToString() + "/" + month.ToString() + "/" + year.ToString();
        }
    }
}
