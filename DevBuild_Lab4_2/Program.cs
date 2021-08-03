using System;

namespace DevBuild_Lab4_2
{

    // Rectangle comparison:

    // When we have: Rectangle r1 = new Rectangle() 
    //               Rectangle r2 = new Rectangle()
    // r1 and r2 are each holding a reference/address to an object in memory.
    // The objects are separate instances they're at different addresses in memory.
    //               So (r1 == r2) is false;
    //
    // Even if we set both r1 and r2 to {Length = 5, Width = 5}
    // so that their values are equal,
    // the references are still pointing to two different objects in memory.
    //               So (r1 == r2) is still false.
    //
    // But if we set r2 = r1, there are now two references to the same object/address in memory.
    // We have let go of the reference to the object that r2 previously pointed to, 
    // so it is no longer reachable in this code and it will be garbage collected. 
    // r2 now holds the same reference to an object that r1 does.
    //               So (r1 == r2) has become true.
    //
    // Additionally - With our variables pointing to the same object we can use either to reference it or manipluate it.


    class MenuItem
    {
        private int _id;
        private string _name;
        private string _desc;
        private decimal _price;
        public void SetID(int id)
        {
            _id = id;
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _name = "EMPTY";
            }
            else
            {
                _name = name;
            }
        }
        public void SetDesc(string desc)
        {
            if (string.IsNullOrEmpty(desc))
            {
                _desc = "EMPTY";
            }
            else
            {
                _desc = desc;
            }
        }
        public void SetPrice(decimal price)
        {
            if (price < .5m)
            {
                _price = 0.50m;
            }
            else if (price > 10)
            {
                _price = 10;
            }
            else
            {
                _price = price;
            }
        }
        public int GetID()
        {
            return _id;
        }
        public string GetName()
        {
            return _name;
        }
        public string GetDesc()
        {
            return _desc;
        }
        public decimal GetPrice()
        {
            return _price;
        }

        public MenuItem(int id, string name, string desc, decimal price)
        {
            _id = id;
            _name = name;
            _desc = desc;
            _price = price;
        }
        public MenuItem(int id, string name, decimal price)
        {
            _id = id;
            _name = name;
            _price = price;
            _desc = "EMPTY";
        }
        public override string ToString()
        {
            return $"\nID: {_id}\nName: {_name}\nDescription: {_desc}\nPrice: {_price}";
        }
    }

    class Rectangle
    {
        public int Length;
        public int Width;
    }



    class Program
    {
        static void CheckEqual(Rectangle rectangle1, Rectangle rectangle2)
        {
            Console.WriteLine($"Rectangle1: {rectangle1.Length} x {rectangle1.Width}");
            Console.WriteLine($"Rectangle2: {rectangle2.Length} x {rectangle2.Width}");
            if (rectangle1 == rectangle2)
            {
                Console.WriteLine("Same");
            }
            else
            {
                Console.WriteLine("Different");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            ////MenuItem menuItem = new MenuItem();
            ////menuItem.SetID(101);
            ////menuItem.SetName("");                         //used to test the EMPTY defaults
            ////menuItem.SetDesc("");                         //
            ////menuItem.SetPrice(25.00m);                    //used to test the constraints of the setter method

            ////Console.WriteLine(menuItem.GetID());
            ////Console.WriteLine(menuItem.GetName());
            ////Console.WriteLine(menuItem.GetDesc());
            ////Console.WriteLine(menuItem.GetPrice());

            MenuItem item1 = new MenuItem(101, "Hamburger", "1 mostly beef 1/8 lb patty", 0.99m);
            MenuItem item2 = new MenuItem(102, "Fries", "Shoestring fries with extra salt", 1.25m);
            MenuItem item3 = new MenuItem(103, "Cola", "Liter of Cola", 0.99m);
            MenuItem item4 = new MenuItem(104, "Cookie", .50m);
            MenuItem item5 = new MenuItem(105, "Family Deal", "10 Burgers & 10 Fries", 15.00m);

            Console.WriteLine(item1);
            Console.WriteLine(item2);
            Console.WriteLine(item3);
            Console.WriteLine(item4);
            Console.WriteLine(item5);
            Console.WriteLine("\n=======================================================\n");

            
            Rectangle r1 = new Rectangle() { Length = 5, Width = 5 };
            Rectangle r2 = new Rectangle() { Length = 10, Width = 10 };

            CheckEqual(r1, r2);  // result "Different"  - Different object rectangles with different dimensions = Different

            r2.Length = 5;
            r2.Width = 5;
            CheckEqual(r1, r2);  // result "Different" - Different object rectangles with same dimensions = Different

            r2 = r1;
            CheckEqual(r1, r2);  // result "Same"

            r2.Length = 5;
            r2.Width = 50;
            CheckEqual(r1, r2);  //r1.Width changes along with r2.Width.

            r1.Length = 100;
            CheckEqual(r1, r2);  //and r2.Length changes along with r1.Length.
            
            // We're now dealing with a single object via r1 and r2. 

        }
    }
}
