using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfBez_2_Vigenère_
{
    class Program
    {
        static char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                                                'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 
                                                'V', 'W', 'X', 'Y', 'Z', ',', '.', '?', '-', '!', ':', ';', '(', ')'};

        static int N = characters.Length;

        static private string Decode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[p];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        static public string Encode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[c];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Зашифровать сообщение\n2 - Расшифровать сообщение");
                string num = Console.ReadLine();
                switch (num)
                {
                    case "1":
                        Console.Write("Введите ключ:  ");
                        string key1 = Console.ReadLine();
                        Console.Write("Введите сообщение:  ");
                        string message = Console.ReadLine();
                        string encryptMessage1 = Encode(message, key1);
                        Console.WriteLine($"Зашифрованное сообщение: \n|{encryptMessage1}|");
                        Console.Write("Расшифровать данное сообщение?(да/нет):  ");
                        string go = Console.ReadLine();
                        if (go.ToUpper() == "ДА")
                            Console.WriteLine($"Расшифрованное сообщение: \n{Decode(encryptMessage1, key1)}");
                        break;

                    case "2":
                        Console.Write("Введите ключ:  ");
                        string key2 = Console.ReadLine();
                        Console.Write("Введите зашифрованное сообщение:  ");
                        string encryptMessage2 = Console.ReadLine();
                        Console.WriteLine($"Расшифрованное сообщение: \n{Decode(encryptMessage2, key2)}");
                        break;

                    default:
                        break;
                }
                Console.Write("\nНажмите любую клавишу...");
                Console.ReadKey();
            }

        }
    }
}
