using System;
using System.Collections.Generic;
using System.IO;

namespace VaccinesOntario
{
    class Program
    {

        //declare a global list that will be used to store the vaccines
        private static List<Vaccine> vaccines = new List<Vaccine>();

        static void Main(string[] args)
        {

            bool showMenu = true;

            while (showMenu)
            {

                Console.WriteLine("Welcome to the Vaccine Manager, Please Select an Option!");
                showMenu = MainMenu();
            }


        }

        /// <summary>
        /// Method to show the Main Menu and allow for a user choice
        /// </summary>
        /// <returns>bool</returns>
        public static bool MainMenu()
        {
            Console.Clear();

            if (vaccines.Count < 1)
            {
                Read();
            }

            //Display Main Menu
            Console.Write("\n--------------------------------------------------------\n");
            Console.WriteLine("1) List Vaccines\n");
            Console.WriteLine("2) Display a Vaccine\n");
            Console.WriteLine("3) Add Vaccine\n");
            Console.WriteLine("4) Update Vaccine\n");
            Console.WriteLine("5) Delete Product\n");
            Console.WriteLine("6) Sort Products\n");
            Console.WriteLine("0) Exit Program\n");
            //Allow User Choice
            switch (Console.ReadLine())
            {
                case "1":
                    Option1();
                    Console.ReadKey();
                    return true;
                case "2":
                    Option2();
                    Console.ReadKey();
                    return true;
                case "3":
                    Option3();
                    Console.ReadKey();
                    return true;
                case "4":
                    Option4();
                    Console.ReadKey();
                    return true;
                case "5":
                    Option5();
                    Console.ReadKey();
                    return true;
                case "6":
                    Option6();
                    Console.ReadKey();
                    return true;
                case "0": //User Wants to close the program
                    QuitMenu();
                    return false;
                default:
                    Console.WriteLine("Please Select a Valid Option. 1 thru 6, or 0 to quit.");
                    Console.ReadKey();
                    return true;
            }
        }
        /// <summary>
        /// Closes the Application
        /// </summary>
        public static void QuitMenu()
        {
            Console.WriteLine("See you again! Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void Read()
        {
            //Read the file
            StreamReader inFile = new StreamReader(@"../../../Resources/Vaccines.csv");
            string line;

            //reads each line of the csv
            while ((line = inFile.ReadLine()) != null)
            {
                //splits the individual lines by the delimeter
                string[] columns = line.Split(',');

                try
                {
                    //Temp variables to hold the now seperated data
                    int SKU = int.Parse(columns[0]);
                    string name = columns[1];
                    float cost = float.Parse(columns[2]);
                    int quantity = int.Parse(columns[3]);
                    Date expiry = new Date(columns[4]);
                    string instructions = columns[5];

                    //add the data to the vaccines list
                    vaccines.Add(new Vaccine(SKU, name, cost, quantity, expiry, instructions));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            inFile.Close();
        }

        public static Vaccine[] ReadFile() //should be string of path to resources file
        {
            const int NUM_OF_COLUMNS = 6;
            //return the number of rows
            string[] lineCount = Properties.Resources.Vaccines.Split('\n');
            int numberLines = lineCount.Length;

            int lineCounter = 0;
            string line;
            StreamReader csvFile = new StreamReader(@"../../../Resources/Vaccines.csv");
            Vaccine[] vaccines = new Vaccine[numberLines]; //Array to store the vaccines

            while ((line = csvFile.ReadLine()) != null)
            {
                // Console.WriteLine(line);
                int columnCounter = 0;
                string[] columns = line.Split(',');//Take each line and break it into the relevant data
                Vaccine tempVaccine = new Vaccine(); //tempVaccine used to store all the data before adding to the array of vaccines

                while (columnCounter <= NUM_OF_COLUMNS)
                {
                    if (columnCounter == 0)
                    {
                        tempVaccine.setSKU(int.Parse(columns[columnCounter])); //Add SKU Number
                    }
                    else if (columnCounter == 1)
                    {
                        tempVaccine.setName(columns[columnCounter]);//Add Vaccine Name
                    }
                    else if (columnCounter == 2)
                    {
                        tempVaccine.setCost(float.Parse(columns[columnCounter])); //Add Unit Cost
                    }
                    else if (columnCounter == 3)
                    {
                        tempVaccine.setQuantity(int.Parse(columns[columnCounter])); //Add Quantity
                    }
                    else if (columnCounter == 4)
                    {
                        //Add Expiry
                        DateTime tempDate = new DateTime();
                        if (DateTime.TryParseExact(columns[columnCounter], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out tempDate))
                        {
                            // tempVaccine.setDate(tempDate);
                        }
                    }
                    else if (columnCounter == 5)
                    {
                        tempVaccine.setInstructions(columns[columnCounter]); //Add Instructions
                    }
                    columnCounter++;
                }
                vaccines[lineCounter] = tempVaccine;
                lineCounter++;
            }

            return vaccines;
        }

        public static void Option1()
        {
            Console.Write("\nRow |  SKU  | Vaccine Name | Unit Cost | QTY | Expiry  | Special Instructions\n" +
                            "----|-------|--------------|-----------|-----|---------|---------------------\n");

            int counter = 0;
            foreach (Vaccine vaccine in vaccines)
            {
                counter++;
                Console.WriteLine(String.Format("{0, -4} ", counter) + vaccine.TableString());
            }


        }

        public static void Option2()
        {
            Vaccine tempVaccine = new Vaccine();
            string tempSKU;

            bool flag = true;

            //Get user input SKU\
            do
            {
                //if there are any errors
                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong, please start again...");
                    flag = true;
                }

                Console.WriteLine("Please Search for a Vaccine using a SKU Number (7 Digit Whole Number):");
                tempSKU = Console.ReadLine();

                if (tempSKU.ToString().Length != 7)
                {
                    flag = false;
                }
            } while (!flag);


            //Search the List for the requested SKU
            foreach (Vaccine vaccine in vaccines)
            {
                if (vaccine.getSKU() == int.Parse(tempSKU))
                {
                    tempVaccine = vaccine;
                }
            }

            if (tempVaccine != new Vaccine())
            {
                Console.WriteLine("Vaccine with SKU# " + tempSKU + " found!\n" + tempVaccine.ToString());
            }
            else
            {
                Console.WriteLine("Vaccine with SKU# " + tempSKU + " not found!\n");
            }
        }

        public static void Option3()
        {
            Console.WriteLine("Option 3 Selected");

            // string userInput;
            bool flag = true;
            string errors = "Something went wrong, please start again...\n";

            int SKU = 0;
            string name = "";
            float cost = 0;
            int quantity = 0;
            int day = 0, month = 0, year = 0;
            string instructions = "";


            do
            {
                //if there are any errors
                if (!flag)
                {
                    Console.Clear();

                    Console.WriteLine(errors);
                    flag = true;
                }

                //Add SKU
                Console.Write("Please enter a 7 digit number for the SKU: ");
                try
                {
                    SKU = int.Parse(Console.ReadLine());

                    if (SKU.ToString().Length != 7)
                    {
                        flag = false;
                        errors += "The SKU number must be all numbers and 7 digits long\n";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //Add Name
                Console.Write("Please enter a name: ");
                try
                {
                    name = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //Add Cost
                Console.Write("Please enter a cost for the vaccine: ");
                try
                {
                    cost = float.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //Add Quantity
                Console.Write("Please enter how many vaccines are on hand: ");
                try
                {
                    quantity = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //Add Expiration Date
                Console.Write("Please enter a date for expiration starting with DD: ");
                try
                {
                    day = int.Parse(Console.ReadLine());
                    if (day < 1 || day > 30)
                    {
                        flag = false;
                        errors += "The day must be between 1 and 30";
                    }
                    Console.Write("\nNow the MM: ");
                    month = int.Parse(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        flag = false;
                        errors += "The month must be between 1 and 12";
                    }
                    Console.Write("\nNow the YYYY: ");
                    year = int.Parse(Console.ReadLine());
                    if (year < 2000 || day > 2021)
                    {
                        flag = false;
                        errors += "The year must be between 2000 and 2021";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //Add Instructions
                Console.Write("Please enter any additional instructions: ");
                try
                {
                    instructions = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!flag);

            if (flag)
            {
                Date expiry = new Date(day, month, year);
                vaccines.Add(new Vaccine(SKU, name, cost, quantity, expiry, instructions));
            }

            WriteToFile();

        }

        public static void Option4()
        {
            Console.WriteLine("Update Vaccine's Selected");

            Vaccine tempVaccine = new Vaccine();
            string tempSKU;
            string input = "";
            bool flag = true;

            //Get user input SKU\
            do
            {
                //if there are any errors
                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong, please start again...");
                    flag = true;
                }

                Console.WriteLine("Please Search for a Vaccine using a SKU Number (7 Digit Whole Number):");
                tempSKU = Console.ReadLine();

                if (tempSKU.ToString().Length != 7)
                {
                    flag = false;
                }
            } while (!flag);


            //Search the List for the requested SKU
            foreach (Vaccine vaccine in vaccines)
            {
                if (vaccine.getSKU() == int.Parse(tempSKU))
                {
                    tempVaccine = vaccine;
                }
            }

            //Vaccine is found
            if (tempVaccine != new Vaccine())
            {
                Console.Clear();
                Console.WriteLine("Vaccine with SKU# " + tempSKU + " found!\n");

                while ((input != "i") && (input != "d"))
                {
                    Console.WriteLine("Increase or Decrease Quantity? Please press i key for Increase or d key for Decrease");

                    input = Console.ReadLine();
                }

                bool increase = true;

                switch (input)
                {
                    case "i":
                        increase = true;
                        break;
                    case "d":
                        increase = false;
                        break;
                }

                flag = false;
                int changeAmount = 0;

                if (!increase)
                {
                    while (!flag)
                    {
                        flag = true;
                        Console.Write("Decrease quantity by: ");
                        input = Console.ReadLine();

                        try
                        {
                            changeAmount = int.Parse(input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            flag = false;
                        }
                    }

                    tempVaccine.setQuantity(tempVaccine.getQuantity() - changeAmount);

                }
                else if (increase)
                {
                    while (!flag)
                    {
                        flag = true;
                        Console.Write("Increase quantity by: ");
                        input = Console.ReadLine();

                        try
                        {
                            changeAmount = int.Parse(input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            flag = false;
                        }
                    }

                    tempVaccine.setQuantity(tempVaccine.getQuantity() + changeAmount);
                }

                WriteToFile();
            }
            else
            {
                Console.WriteLine("Vaccine with SKU# " + tempSKU + " not found!\n");
            }
        }

        public static void Option5()
        {
            Console.WriteLine("Delete Vaccine Selected");

            Vaccine tempVaccine = new Vaccine();
            string tempSKU;
            string input = "";
            bool flag = true;

            //Get user input SKU\
            do
            {
                //if there are any errors
                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong, please start again...");
                    flag = true;
                }

                Console.WriteLine("Please Search for a Vaccine using a SKU Number (7 Digit Whole Number):");
                tempSKU = Console.ReadLine();

                if (tempSKU.ToString().Length != 7)
                {
                    flag = false;
                }
            } while (!flag);


            //Search the List for the requested SKU
            foreach (Vaccine vaccine in vaccines)
            {
                if (vaccine.getSKU() == int.Parse(tempSKU))
                {
                    tempVaccine = vaccine;
                }
            }

            //Vaccine is found
            if (tempVaccine != new Vaccine())
            {
                Console.Clear();
                Console.WriteLine("Vaccine with SKU# " + tempSKU + " found!\n");
                Console.WriteLine(tempVaccine.ToString());
                

                while ((input != "y") && (input != "n"))
                {
                    Console.Write("\n\nAre you sure you want to delete this? Press Y/N: ");
                    input = Console.ReadLine();
                }


                switch (input)
                {
                    case "y":
                        Console.WriteLine("Vaccine with SKU# " + tempSKU + " has been deleted.");
                        vaccines.Remove(tempVaccine);
                        break;
                    case "n":
                        Console.WriteLine("No Vaccine Deleted, returning to main menu");
                        break;
                }

            }

        }

        public static void Option6()
        {
            Console.WriteLine("Sort Products Selected");

            string input = "";

            while ((input != "1") && (input != "2") && (input != "3"))
            {
                Console.Clear();

                Console.Write("Sorting Options:\n1. Quantity\n2. Cost\n 3. Date\n\nYour Selection: ");
                input = Console.ReadLine();
            }

            switch(input)
            {
                case "1":
                    Vaccine.sortBy = SortBy.Quantity;
                    break;
                case "2":
                    Vaccine.sortBy = SortBy.Cost;
                    break;
                case "3":
                    Vaccine.sortBy = SortBy.Date;
                    break;
            }

            vaccines.Sort();
            WriteToFile();
        }

        public static void WriteToFile()
        {
            using (StreamWriter outFile = new StreamWriter(@"../../../Resources/Vaccines.csv", false))
            {
                foreach (Vaccine vaccine in vaccines)
                {
                    outFile.WriteLine(vaccine.FileString());
                }
            }
        }

        public static void SearchBySKU()
        {

        }

        public static void AreYouSure()
        {

        }

    }//End of Main
}//End of Namespace
