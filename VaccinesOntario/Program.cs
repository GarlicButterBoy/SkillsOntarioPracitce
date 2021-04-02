using System;
using System.IO;

namespace VaccinesOntario
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read the lines from the file, seperated by newline
            string[] lines = Properties.Resources.Vaccines.Split('\n');
            Vaccine[] vaccines = new Vaccine[lines.Length];
            //iterate through the file
            foreach (string line in lines)
            {
                //initialize a counter and array of vaccines
                int vacCounter = 0;
                

                Console.WriteLine(line);
                  string[] columns = line.Split(',');
                int counter = 0;
               // Vaccine tempVaccine = new Vaccine();
                 foreach (string column in columns)
                 {
                    if (column == "")
                    {
                        break;
                    }
                     Console.WriteLine(column);

                    if (counter == 0)
                    {
                        //Add SKU Number
                        vaccines[vacCounter].setSKU(int.Parse(column));
                    }
                    else if (counter == 1)
                    {
                        //Add Vaccine Name
                        vaccines[vacCounter].setName(column);
                    }
                    else if (counter == 2)
                    {
                        //Add Unit Cost
                        vaccines[vacCounter].setCost(float.Parse(column));
                    }
                    else if (counter == 3)
                    {
                        //Add Quantity
                        vaccines[vacCounter].setQuantity(int.Parse(column));
                    }
                    else if (counter == 4)
                    {
                        //Add Expiry
                        DateTime tempDate = new DateTime();
                        if (DateTime.TryParseExact(column, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, 
                            System.Globalization.DateTimeStyles.None, out tempDate))
                        {
                            vaccines[vacCounter].setDate(tempDate);
                        }
                    }
                    else if (counter == 5)
                    {
                        //Add Instructions
                        vaccines[vacCounter].setInstructions(column);
                    }
                    counter++;
                 }
                
                vacCounter++;
            }

            vaccines[0].ToString();
            vaccines[1].ToString();
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

     //   public Vaccine ReadFile(string path) //should be string of path to resources file
     //   {
            
      //  }

    }//End of Main
}//End of Namespace
