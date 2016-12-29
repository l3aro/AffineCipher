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

            string raw = "HOai";

            string result;

            result = ac.Encrypt(raw);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
