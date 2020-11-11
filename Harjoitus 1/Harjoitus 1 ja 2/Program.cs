using Making_New_Class;
using System;
using System.Threading.Tasks.Dataflow;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            emptyline2("");
            countTogether(3, 5); // H1 Tehtävä 1
            fahrenheights(10); // H1 Tehtävä 2
            calculator(8, 5); // H1 Tehtävä 3
            int remainder = mainder(5, 2); // H1 Tehtävä 4
            greet("firstName"); // H1 Tehtävä 5
            userIsCountingNr(0, 0); //H1 Tehtävä 6
            userIsCountingCel(0); // H1 Tehtävä 7
            userIsCountingFar(0); // H1 Tehtävä 8
            userIsUsingCalc(0, 0); // H1 Tehtävä 9
            userIsChoosingNumbers(0, 0); // H1 Tehtävä 10
            taskEleven(0); // H1 Tehtävä 11
            userAge(0); //H1 Tehtävä 12
            userBiggerThan(10); //H1 Tehtävä 13
            changeFirstandLastletter(""); // H1 Tehtävä 14
            userPosNeg(0, 0); // H1 Tehtävä 15

            emptyline("");
            bool same = isSame(2, 1);
            Console.WriteLine("Counts are the same " + same);

            // next part is excample for bank account, look new file!!!
            Nameofclass book = new Nameofclass();
            Console.WriteLine(book.Name);
            book.Name = "Name of the book is book";
            Console.WriteLine(book.Name);
            Nameofclass csharp = new Nameofclass("C# basics", "R.Klopp", 488);
            Console.WriteLine(csharp.Name + " " + csharp.Writer + " " + csharp.Pages);
            csharp.Pages = 498;
            Console.WriteLine(csharp.Name + " " + csharp.Writer + " " + csharp.Pages);

        }

        public static void emptyline2(string line)
        {
            Console.WriteLine("\n-----------Harjoitus 1-------------\n");
        }

        public static void countTogether(int cun1, int cun2)
        {
            int sum = cun1 + cun2;
            Console.WriteLine("Counts {0} and {1} sum is {2}", cun1, cun2, sum);
        }

        public static void fahrenheights(int celsius)
        {
            double fahrenheit = celsius * 1.8 + 32;
            Console.WriteLine(celsius + " Celsius is " + fahrenheit + " fahrenheights ");
        }

        public static void calculator(double cun1, double cun2)
        {
            double sum = cun1 + cun2;
            double substract = cun1 - cun2;
            double times = cun1 * cun2;
            double divided = cun1 / cun2;
            Console.WriteLine("Numbers {0} + {1} = {2}", cun1, cun2, sum);
            Console.WriteLine("Numbers {0} - {1} = {2}", cun1, cun2, substract);
            Console.WriteLine("Numbers {0} × {1} = {2}", cun1, cun2, times);
            Console.WriteLine("Numbers {0} ÷ {1} = {2}", cun1, cun2, divided);
        }

        public static int mainder(int cun1, int cun2)
        {
            int remain = cun1 % cun2;
            return remain;
            //return cun1 % cun2;
        }

        public static void greet(string name)
        {
            Console.WriteLine("Say your first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Hello " + firstName + "!");
        }

        public static void userIsCountingNr(int cun1, int cun2)
        {
            Console.WriteLine("Choose a number");
            cun1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose a second number");
            cun2 = int.Parse(Console.ReadLine());
            int sum = cun1 + cun2;
            Console.WriteLine("Numbers " + cun1 + " + " + cun2 + " = " + sum, cun1, cun2, sum);
        }

        public static void userIsCountingCel(int celsius)
        {
            Console.WriteLine("Give Celcius degree");
            celsius = int.Parse(Console.ReadLine());
            double fahrenheit = celsius * 1.8 + 32;
            Console.WriteLine("Temperature " + celsius + "°C is as much as " + fahrenheit + "°F");

        }

        public static void userIsCountingFar(int fahrenheit)
        {
            Console.WriteLine("Give Fahrenheit degree");
            fahrenheit = int.Parse(Console.ReadLine());
            double celsius = (fahrenheit - 32) * 0.5559;
            Console.WriteLine("Temperature " + fahrenheit + "°F is as much as " + celsius + "°C");
        }

        public static void userIsUsingCalc(double cun1, double cun2)
        {
            Console.WriteLine("Quick calculating from your choosen numbers. \n Give first number");
            cun1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Give second number");
            cun2 = int.Parse(Console.ReadLine());
            double sum = cun1 + cun2;
            double substract = cun1 - cun2;
            double times = cun1 * cun2;
            double divided = cun1 / cun2;
            Console.WriteLine("Numbers " + cun1 + " + " + cun2 + " = " + sum, cun1, cun2, sum);
            Console.WriteLine("Numbers " + cun1 + " - " + cun2 + " = " + substract, cun1, cun2, substract);
            Console.WriteLine("Numbers " + cun1 + " × " + cun2 + " = " + times, cun1, cun2, times);
            Console.WriteLine("Numbers " + cun1 + " ÷ " + cun2 + " = " + divided, cun1, cun2, divided);
        }

        public static void userIsChoosingNumbers(int cun1, int cun2)
        {
            Console.WriteLine("Choose a number higher then 1");
            cun1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose a number smaller than previous but higher than 0");
            cun2 = int.Parse(Console.ReadLine());
            double remainder = cun1 % cun2;
            Console.WriteLine("Numbers " + cun1 + " remainder from " + cun2 + " is " + remainder, cun1, cun2, remainder);
        }

        public static void taskEleven(int num)
        {
            int table;
            Console.WriteLine("Give a number from 1-10.");
            num = int.Parse(Console.ReadLine());
            for(table=1; table<=10; table++)
            {
                Console.WriteLine("{0} × {1} = {2}", num, table, num * table);
            }
        }

        public static void userAge(int age)
        {
            Console.WriteLine("What is your age?");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("\n" + age + " really? You don't look that old!");
        }

        public static void userBiggerThan(int num)
        {
            int numbers;
            Console.WriteLine("Write a number higher then 10 and i will multiply it as many times");
            num = int.Parse(Console.ReadLine());
            for(numbers=1; numbers <= num; numbers++)
            {
                Console.Write("" + num, num);
            }
        }

        public static void changeFirstandLastletter(string word)
        {
            Console.WriteLine("Write a word of your choice, use Capital letter beginning and end of the word");
            word = (Console.ReadLine());
            Console.WriteLine(word.Substring(word.Length - 1) + word.Trim(word[0], word[word.Length - 1]) + word[0]);
        }

        public static void userPosNeg(int cun1, int cun2)
        {
            Console.WriteLine("Give your first number from two numbers if they are positive or negative");
            cun1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Give your second number for checking");
            cun2 = int.Parse(Console.ReadLine());
            if(cun1 < 0 && cun2 < 0)
            {
                Console.WriteLine("Both are negative");
            }
            else if(cun1 >= 0 && cun2 >= 0)
            {
                Console.WriteLine("Both are positive");
            }
            else
            {
                Console.WriteLine("One of numbers is positive and another is negative");
            }
        }
        public static void emptyline(string line)
            {
            Console.WriteLine("\n-----------Harjoitus 2-------------\n");
}
        public static bool isSame(int cun1, int cun2)
        {
            if (cun1 == cun2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
