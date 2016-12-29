using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineCipher
{
    class AffineCipher
    {
        private Dictionary<byte, byte> inverseTable;
        private byte a;
        private byte a1;
        private byte b;

        public AffineCipher()
        {
            // import inverse data table
            inverseTable = new Dictionary<byte, byte>();
            inverseTable.Add(1, 1);
            inverseTable.Add(3, 9);
            inverseTable.Add(5, 21);
            inverseTable.Add(7, 15);
            inverseTable.Add(9, 3);            
            inverseTable.Add(11, 19);
            inverseTable.Add(15, 7);
            inverseTable.Add(19, 11);
            inverseTable.Add(21, 5);
            inverseTable.Add(23, 17);
            inverseTable.Add(25, 25);

            Random rnd = new Random();

            bool isContinueRandom = true;
            
            while(isContinueRandom)
            {
                a = (byte)rnd.Next(1, 25);
                if (inverseTable.ContainsKey(a))
                    isContinueRandom = false;
            }
            a1 = inverseTable[a];

            b = (byte)rnd.Next(1, 26);   
        }
        
        public byte Get_a()
        {
            return a;
        }            
        
        public byte Get_a1()
        {
            return a1;
        }            

        public byte Get_b()
        {
            return b;
        }
    }
}
