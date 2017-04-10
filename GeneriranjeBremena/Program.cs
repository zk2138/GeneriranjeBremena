using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneriranjeBremena
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneriranjeBremena(1, 100, 1);
        }

        /**
         * Funkcija za generiranje bremena glede na podane argumente
         * fileNum - stevilo datotek, ki jih zelimo generirati
         * fileSize - velikost datotek, ki jih zelimo generirati
         * sizeType - dolocitev velikosti (KB, MB, GB)
         */
        static void GeneriranjeBremena(int fileNum, int fileSize, int sizeType)
        {

            string path = "../../files/poskus.txt"; ;
            string randomS = "";

            int sizeTransform = 0;
            //int upperLimit = 0;
            //upperLimit = 2 * (int)(Math.Pow(10, 6));
            //int loopNum = 1;

            if (sizeType == 1)
                sizeTransform = fileSize * (int)Math.Pow(10, 3);
            else if (sizeType == 2)
                sizeTransform = fileSize * (int)Math.Pow(10, 6);
            else if (sizeType == 3)
                sizeTransform = fileSize * (int)Math.Pow(10, 9);

            //if(sizeTransform >= upperLimit)
            //{
            //    loopNum = 2;
            //}

            try
            {

                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    File.Delete(path);
                }

                // Create the file. 
                //Sprazni vsebino datoteke ce ze obstaja
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("");
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }

                //dodaja posamezne crke v datoteko dokler ni pravilne velikosti
                using (StreamWriter sw = File.AppendText(path))
                {
                    for (int i = 0; i < sizeTransform; i++)
                    {
                        randomS = RandomString(1);
                        //Byte[] info = new UTF8Encoding(true).GetBytes(randomS);
                        // Add some information to the file.
                        sw.Write(randomS);
                    }

                    sw.Close();
                }

                // Open the stream and read it back.
                //using (StreamReader sr = File.OpenText(path))
                //{
                //    string s = "";
                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        Console.WriteLine(s);
                //    }
                //}
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //string randomS = RandomString(fileSize);
            //System.Text.ASCIIEncoding.Unicode.GetByteCount(randomS);
            //System.Text.ASCIIEncoding.ASCII.GetByteCount(randomS);
            //Console.WriteLine(randomS);
        }

        /**
         * Funkcija za generiranje naključnega Stringa
         */
        private static Random random = new Random();
        private static string RandomString(int Size)
        {
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < Size; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
