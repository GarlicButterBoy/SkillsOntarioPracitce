using System;
using System.IO;

namespace VaccinesOntario
{
    class Program
    {
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

        public static Vaccine[] ReadFile() //should be string of path to resources file
        {
            const int NUM_OF_COLUMNS = 6;
            //return the number of rows
            string[] lineCount = Properties.Resources.Vaccines.Split('\n');
            int numberLines = lineCount.Length;

            int lineCounter = 0;
            string line;
            StreamReader csvFile = new StreamReader(@"D:\Computer Programmer DC\Skills Ontario Stuff\vaccines.csv");
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
            
            return vaccines; 
        }

        public static void Option1()
        {
            Vaccine[] vaccines = ReadFile();
            string tempString;
            tempString = "\nRow |  SKU  | Vaccine Name | Unit Cost | QTY | Expiry | Special Instructions\n";
            tempString += "--------------------------------------------------------------------------\n";

            for (int i = 0; i < vaccines.Length; i++)
            {
                tempString += " " + (i + 1).ToString() + "  |";
                tempString += vaccines[i].getSKU().ToString() + "|";
                tempString += vaccines[i].getName() + "       |  ";
                tempString += vaccines[i].getCost().ToString() + "      |  ";
                tempString += vaccines[i].getQuantity().ToString() + " | ";
                tempString += vaccines[i].getDate().ToString() + " | ";
                tempString += vaccines[i].getInstructions() + "\n";
            }

            Console.WriteLine(tempString);
        }

        public static void Option2()
        {
            Vaccine[] vaccines = ReadFile();
            Vaccine vaccine = new Vaccine();
            string tempSKU;
            
            bool flag = false;

            while (!flag)
            {
                Console.WriteLine("Please Search for a Vaccine using a SKU Number (7 Digit Whole Number):");
                tempSKU = Console.ReadLine();
                int SKU;
                if (int.TryParse(tempSKU, out SKU))
                {

                    vaccine = Array.Find(vaccines, Vaccine => Vaccine.getSKU() == SKU);
                    vaccine.ToString();
                    flag = true;
                }
                else
                {
                    Console.WriteLine("No Match.");
                }
            }

            

            

        }
        
        public static void Option3()
        {
            Console.WriteLine("Option 3 Selected");
            Vaccine[] vaccines = ReadFile();
            //Console.WriteLine(vaccines.Length.ToString());
            Vaccine newVaccine = new Vaccine();

            //Create a StreamWriter
            StreamWriter file = new StreamWriter(@"D:\Computer Programmer DC\Skills Ontario Stuff\newVaccines.csv");

            //Add SKU
            Console.Write("Please enter a 7 digit number for the SKU: ");
            int SKU = int.Parse(Console.ReadLine());
            newVaccine.setSKU(SKU);

            //Add Name
            Console.Write("Please enter a name: ");
            string name = Console.ReadLine();
            newVaccine.setName(name);

            //Add Cost
            Console.Write("Please enter a cost for the vaccine: ");
            float cost = float.Parse(Console.ReadLine());
            newVaccine.setCost(cost);

            //Add Quantity
            Console.Write("Please enter how many vaccines are on hand: ");
            int quantity = int.Parse(Console.ReadLine());
            newVaccine.setQuantity(quantity);

            //Add Expiration Date
            Console.Write("Please enter a date for expiration: ");
            DateTime expiry = DateTime.Parse(Console.ReadLine());
            newVaccine.setDate(expiry);

            //Add Instructions
            Console.Write("Please enter any additional instructions: ");
            string instructions = Console.ReadLine();
            newVaccine.setInstructions(instructions);

            //Create the new Vaccine
            //Vaccine newVaccine = new Vaccine(SKU, name, cost, quantity, expiry, instructions);

            //Console.WriteLine(newVaccine.ToString());
            vaccines[vaccines.Length - 1] = newVaccine; //Add the new vaccine to the array

            //Write to the new CSV
            for (int i = 0; i < vaccines.Length; i++)
            {
                file.Write(vaccines[i].FileString());
            }
            
            

        }

        public static void Option4()
        {
            Console.WriteLine("Update Vaccine's Selected");
        }

        public static void Option5()
        {
            Console.WriteLine("Delete Vaccine Selected");
        }

        public static void Option6()
        {
            Console.WriteLine("Sort Products Selected");

        }

    }//End of Main
}//End of Namespace
