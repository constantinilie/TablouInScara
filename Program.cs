using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablouInScara
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[][] Cuvant = new string[26][];

        
            using (StreamReader sr = new StreamReader("date.txt")) 
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    string[] words = linie.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (word.Length > 0)
                        {
                            char primulCaracter = char.ToUpper(word[0]); 
                            if (char.IsLetter(primulCaracter))
                            {
                                
                                int index = primulCaracter - 'A';
                                if (Cuvant[index] == null)
                                {
                                    Cuvant[index] = new string[] { word };
                                }
                                else
                                {
                                    Array.Resize(ref Cuvant[index], Cuvant[index].Length + 1);
                                    Cuvant[index][Cuvant[index].Length - 1] = word;
                                }
                            }
                        }
                    }
                }
            }

            //Afisare
            for (int i = 0; i < Cuvant.Length; i++)
            {
                char letter = (char)('A' + i);
                Console.WriteLine($"Cuvinte care încep cu '{letter}':");
                if (Cuvant[i] != null)
                {
                    foreach (string word in Cuvant[i])
                    {
                        Console.WriteLine(word);
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
    

