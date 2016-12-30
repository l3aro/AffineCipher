using System;

namespace AffineCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            AffineCipher AffineCipher = new AffineCipher();

            Console.Write("Nhap chuoi can ma hoa: ");

            string data;

            data = Console.ReadLine();

            string encrypt = AffineCipher.Encrypt(data);

            Console.WriteLine("Chuoi da ma hoa: {0}", encrypt);

            string decrypt = AffineCipher.Decrypt(encrypt);

            Console.WriteLine("Chuoi da giai ma: {0}", decrypt);

            Console.ReadKey();
        }
    }
}
