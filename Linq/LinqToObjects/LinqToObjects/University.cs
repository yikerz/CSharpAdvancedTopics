using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Print()
        {
            Console.WriteLine("{0} is the university with Id: {1}", Name, Id);
        }
    }

}
