using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_1_Scitala_
{
    public class ScytaleCipher
    {
        static public string Encrypt(string text, int d)
        {
            var k = text.Length % d;
            if (k > 0)
            {
                //дополняем строку пробелами
                text += new string(' ', d - k);
            }

            var column = text.Length / d;
            var result = "";

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    result += text[i + column * j].ToString();
                }
            }

            return result;
        }

        static public string Decrypt(string text, int d)
        {
            var column = text.Length / d;
            var symbols = new char[text.Length];
            int index = 0;
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    symbols[i + column * j] = text[index];
                    index++;
                }
            }

            return string.Join("", symbols);
        }

        static public string Breaking(string text)
        {
            int d = 1;
            bool stop = false;
            string result = string.Empty;
            while (!stop)
            {
                result = Decrypt(text, d);
                Console.WriteLine("Диаметр " + d + "; \nРасшифрованный текст:\n" + result);
                Console.WriteLine("Расшифровка правильная? (true - да, false - нет)");
                stop = Convert.ToBoolean(Console.ReadLine());
                d++;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var scytale = new ScytaleCipher();
            //Console.Write("Введите текст сообщения: ");
            //var message = Console.ReadLine();
            //Console.Write("Введите диаметр цилиндра: ");
            //var diameter = Convert.ToInt32(Console.ReadLine());
            //var encText = scytale.Encrypt(message, diameter);
            //Console.WriteLine("Зашифрованный текст: {0}", encText);
            //Console.WriteLine("Расшифрованный текст: {0}", scytale.Decrypt(encText, diameter));
            //Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\n----------------\n1 - Шифровка\n2 - Расшифровка\n3 - Взлом без ключа");
                int key = int.Parse(Console.ReadLine());
                switch(key)
                {
                    case 1:
                        Console.Write("Введите сообщение: ");
                        string message1 = Console.ReadLine();
                        Console.Write("Введите диаметр циллиндра: ");
                        int diameter1 = int.Parse(Console.ReadLine());
                        string encText = ScytaleCipher.Encrypt(message1, diameter1);
                        Console.WriteLine("Зашифрованный текст: \n|" + encText + "|");
                        Console.WriteLine("Расшифровать данный текст? (true - да, false - нет)");
                        bool go = Convert.ToBoolean(Console.ReadLine());
                        if (go)
                            Console.WriteLine("Расшифрованный текст: \n" + ScytaleCipher.Decrypt(encText, diameter1));
                        break;

                    case 2:
                        Console.Write("Введите зашифрованный текст: ");
                        string message2 = Console.ReadLine();
                        Console.Write("Введите диметр циллиндра: ");
                        int diameter2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Расшифрованный текс: \n" + ScytaleCipher.Decrypt(message2, diameter2));
                        break;

                    case 3:
                        Console.Write("Введите зашифрованный текст (обратите внимание на пробелы): ");
                        string message3 = Console.ReadLine();
                        ScytaleCipher.Breaking(message3);
                        break;
                }
            }
        }
    }
}
