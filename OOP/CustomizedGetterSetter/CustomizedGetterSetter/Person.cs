using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizedGetterSetter
{
    public class Person
    {
        // private properties cannot be accessed directly (encapsulation)
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name 
        {
            // customized setter and getter
            get { return _name; } 
            set
            {
                if (value != null && value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Name cannot be null or empty.");
                }
            } 
        }
        public int Age
        {
            // customized setter and getter
            get { return _age; }
            set
            {
                if (value >= 0)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Age cannot be negative.");
                }
            }
        }
    }
}
