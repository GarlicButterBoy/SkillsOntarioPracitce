using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinesOntario
{
    class Vaccine
    {
        //Private Variables
        private int SKU;
        private string name;
        private float cost;
        private int quantity;
        private DateTime expiration;
        private string instructions;

        //Constructors
        //Default Constructor
        public Vaccine()
        {

        }
        //Parameterized Constructor
        public Vaccine(int SKU, string name, float cost, int quantity, DateTime expiration, string instructions)
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

        public DateTime getDate()
        {
            return expiration.Date;
        }

        public void setDate(DateTime date)
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

        //Overrides
       // public static Vaccine operator =(Vaccine a)
     //   {
      //      Vaccine temp = new Vaccine(a.getSKU, a.getName, a.getCost, a.getQuantity, a.getDate, a.getInstructions);
       //     return temp;
      //  }
    }
}
