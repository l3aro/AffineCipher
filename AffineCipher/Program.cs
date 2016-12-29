using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            AffineCipher ac = new AffineCipher();

            Console.ReadKey();

            byte temp;
            temp = ac.Get_a();
            temp = ac.Get_a1();
            temp = ac.Get_b();


            Console.ReadKey();
        }
    }
}
