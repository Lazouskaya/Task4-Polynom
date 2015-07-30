using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polynomial;

namespace ApplicPolynom
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynom a=new Polynom(1,2,3,4,5);
            Polynom b = new Polynom(1, 2, 3);
            Polynom c = a - b;
         
                Console.WriteLine(c.ToString());
                Console.WriteLine(a.ToString());
                Console.WriteLine(b.ToString());
            Console.ReadKey();
            
        }
    }
}
