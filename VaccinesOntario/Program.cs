using System;
using System.IO;

namespace VaccinesOntario
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Vaccine[] vaccines = ReadFile();

          Console.WriteLine(vaccines[0].ToString());
           Console.WriteLine(vaccines[1].ToString());
            /*

            bool showMenu = true;

            while (showMenu)
            { 
            
            Console.WriteLine("Welcome to the Vaccine Manager, Please Select an Option!");
             showMenu = MainMenu();
            }
            
            */
        }

        /// <summary>
        /// Method to show the Main Menu and allow for a user choice
        /// </summary>
        /// <returns>bool</returns>
        public static bool MainMenu()
        {
            Console.Clear();
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
                    Console.WriteLine("Option 1 Selected");
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.WriteLine("Option 2 Selected");
                    Console.ReadKey();
                    return true;
                case "3":
                    Console.WriteLine("Option 3 Selected");
                    Console.ReadKey();
                    return true;
                case "4":
                    Console.WriteLine("Option 4 Selected");
                    Console.ReadKey();
                    return true;
                case "5":
                    Console.WriteLine("Option 5 Selected");
                    Console.ReadKey();
                    return true;
                case "6":
                    Console.WriteLine("Option 6 Selected");
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

        public static Vaccine[] ReadFile() //should be string of path to resources file
        {
            const int NUM_OF_COLUMNS = 6;
            int lineCounter = 0;
            string line;
            StreamReader csvFile = new StreamReader(@"D:\Computer Programmer DC\Skills Ontario Stuff\vaccines.csv");
            Vaccine[] vaccines = new Vaccine[2]; //Array to store the vaccines

            while ((line = csvFile.ReadLine()) != null)
            {
                Console.WriteLine(line);
                int columnCounter = 0;
                string[] columns = line.Split(',');//Take each line and break it into the relevant data
                Vaccine tempVaccine = new Vaccine(); //tempVaccine used to store all the data before adding to the array of vaccines
                //Vaccine[] vaccines = new Vaccine[2]; //Array to store the vaccines

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
                            tempVaccine.setDate(tempDate);
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
            /*
             //Read the lines from the file, seperated by newline
            string[] lines = Properties.Resources.Vaccines.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(i.ToString() + " " + lines[i]);
            }
            Vaccine[] vaccines = new Vaccine[lines.Length]; //Array to store the vaccines
            Vaccine tempVaccine = new Vaccine(); //tempVaccine used to store all the data before adding to the array of vaccines
            //iterate through the file
            int vacCount; //counter to keep track of the number of vaccines in the array
            for (vacCount = 0; vacCount < lines.Length; vacCount++)
            {
                foreach (string line in lines)
                {
                    string[] columns = line.Split(','); //Take each line and break it into the relevant data
                    int count;
                    for (count = 0; count < columns.Length; count++)
                    {
                        foreach (string column in columns)
                        {
                            if (columns[count] == "")
                            {
                                break;
                            }
                            if (count == 0)
                            {
                                tempVaccine.setSKU(int.Parse(columns[count])); //Add SKU Number
                            }
                            else if (count == 1)
                            {
                                tempVaccine.setName(columns[count]);//Add Vaccine Name
                            }
                            else if (count == 2)
                            {
                                tempVaccine.setCost(float.Parse(columns[count])); //Add Unit Cost
                            }
                            else if (count == 3)
                            {
                                tempVaccine.setQuantity(int.Parse(columns[count])); //Add Quantity
                            }
                            else if (count == 4)
                            {
                                //Add Expiry
                                DateTime tempDate = new DateTime();
                                if (DateTime.TryParseExact(columns[count], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None, out tempDate))
                                {
                                    tempVaccine.setDate(tempDate);
                                }
                            }
                            else if (count == 5)
                            {
                                tempVaccine.setInstructions(columns[count]); //Add Instructions
                            }

                        }
                        
                    }
                    vaccines[vacCount] = tempVaccine;
                }
                
            }
        */
            return vaccines; 
        }



    }//End of Main
}//End of Namespace
