using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinesOntario
{
    class Vaccine : IComparable
    {

        public static SortBy sortBy = SortBy.Quantity;

        //Private Variables
        private int SKU;
        private string name;
        private float cost;
        private int quantity;
        private Date expiration;
        private string instructions;

        //Constructors
        //Default Constructor
        public Vaccine()
        {

        }
        //Parameterized Constructor
        public Vaccine(int SKU, string name, float cost, int quantity, Date expiration, string instructions)
        {
            setSKU(SKU);
            setName(name);
            setCost(cost);
            setQuantity(quantity);
            setDate(expiration);
            setInstructions(instructions);
        }

        //Getters and Setters
        public int getSKU()
        {
            return SKU;
        }

        public void setSKU(int SKU)
        {
            this.SKU = SKU;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public float getCost()
        {
            return cost;
        }

        public void setCost(float cost)
        {
            this.cost = cost;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public Date getDate()
        {
            return expiration;
        }

        public void setDate(Date date)
        {
            expiration = date;
        }

        public string getInstructions()
        {
            return instructions;
        }

        public void setInstructions(string instruction)
        {
            this.instructions = instruction;
        }

        //Methods
        public override string ToString()
        {
            string tempString = "";

            tempString += "SKU: " + getSKU().ToString() + Environment.NewLine;
            tempString += "Vaccine Name: " + getName() + Environment.NewLine;
            tempString += "Unit Cost: " + getCost().ToString() + Environment.NewLine;
            tempString += "Quantity on hand: " + getQuantity().ToString() + Environment.NewLine;
            tempString += "Expiry Date: " + getDate().ToString() + Environment.NewLine;
            tempString += "Special Instructions: " + getInstructions() + Environment.NewLine;

            return tempString;
        }

        public string TableString()
        {
            return String.Format("{0, -7} {1, -14} {2, -11:C2} {3, -5} {4, -10} {5}", SKU, name, cost, quantity, expiration, instructions);
        }

        public string FileString()
        {
            string tempString = "";

            tempString += getSKU().ToString() + "," + getName() + "," + getCost().ToString() + "," + getQuantity().ToString() + "," + getDate().ToString() + "," + getInstructions();

            return tempString;
        }

        public virtual int CompareTo(object obj)
        {
            //is the argument null?
            if (obj == null)
            {
                //throw exception
                throw new ArgumentNullException("Unable to compare, object is null");
            }

            Vaccine tempVaccine = obj as Vaccine; //Convert obj to Vaccine

            if (tempVaccine != null) //if the conversion worked
            {
                if (sortBy == SortBy.Quantity)
                {
                    int thisSort = this.quantity;
                    int compare = tempVaccine.quantity;
                    return (thisSort.CompareTo(compare));
                }
                else if (sortBy == SortBy.Cost)
                {
                    float thisSort = this.cost;
                    float compare = tempVaccine.cost;
                    return (thisSort.CompareTo(compare));
                }
                else
                {

                    DateTime thisSort = new DateTime(expiration.getDay(), expiration.getMonth(), expiration.getYear());
                    DateTime compare = new DateTime(tempVaccine.expiration.getDay(), tempVaccine.expiration.getMonth(), tempVaccine.expiration.getYear());
                    return (thisSort.CompareTo(compare));
                }
            }
            else //conversion failed
            {
                throw new ArgumentException("Object being compared cannot be converted to a Vaccine");
            }
        }

    }
}
