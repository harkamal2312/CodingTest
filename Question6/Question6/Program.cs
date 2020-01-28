using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question6
{
    class Program
    {
        private static void Main(string[] args)
        {
            var myHouse = new Building()
                        .AddKitchen()
                        .AddBedroom("master")
                        .AddBedroom("guest")
                        .AddBalcony();

            var normalHouse = myHouse.Build();

            //kitchen, master room, guest room, balcony
            Console.WriteLine(normalHouse.Describe());

            myHouse.AddKitchen().AddBedroom("another");

            var luxuryHouse = myHouse.Build();

            //it only shows the kitchen after build
            //kitchen, master room, guest room, balcony, kitchen, another room
            Console.WriteLine(luxuryHouse.Describe());

        }
    }
    public class Building
    {
        private Building commitedInstance;
        private StringBuilder roomDetails = new StringBuilder();
        public Building AddKitchen()
        {
            this.roomDetails.Append(" kitchen,");
            return this;
        }
        public Building AddBedroom(string bedroomName = "")
        {
            roomDetails.Append(" ");
            if (!string.IsNullOrWhiteSpace(bedroomName))
            {
                roomDetails.Append(bedroomName);
            }
            roomDetails.Append(" room,");
            return this;
        }
        public Building AddBalcony()
        {
            roomDetails.Append(" balcony,");
            return this;
        }
        public Building Build()
        {
            commitedInstance = new Building
            {
                roomDetails = new StringBuilder(this.roomDetails.ToString())
            };
            return this;
        }

        public string Describe()
        {

            var details = commitedInstance == null ? string.Empty : commitedInstance.roomDetails.ToString();
            if (details.Length > 1)
            {
                details = details.Remove(details.Length - 1);
            }
            return details;
        }

    }
}
