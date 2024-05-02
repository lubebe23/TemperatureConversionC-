using System;

* Name:        temperatureConversion
 * 
 * Author:      Lewis Ubebe
 * 
 * Version:     1 — This program asks the user to choose a temperature conversion
 *              calculator, either Celcius to Fahrenheit or Fahrenheit to Celcius,
 *              then asks the user to enter a whole number to convert. The calculator
 *              performs the conversion using the appropriate formula and outputs
 *              the result to the console as a decimal rounded to one place. 
 *              Any invalid inputs result in an error message including entering a decimal 
 *              and a non number error too.
 *              Error catching nis also present for invalid menu entry.
 *              
*/
     
namespace TemperatureConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            do
            {
                RunTemperatureConversion();

                Console.WriteLine("\nDo you want to convert another temperature? (yes/no)");
                string continueChoice = Console.ReadLine().ToLower();

                continueProgram = continueChoice == "yes";

            } while (continueProgram);

            Console.WriteLine("\nThank you for using the temperature conversion program. Goodbye!");
        }

        static void RunTemperatureConversion()
        {
            Console.Clear();
            Console.SetWindowSize(130, 50);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.Title = "Welcome to MULTICALC! TCE";

            DisplayWelcomeScreen();

            try
            {
                Console.WriteLine("Please enter 'CF' to convert from Celsius to Fahrenheit or 'FC' to convert from Fahrenheit to Celsius:");
                string menuChoice = Console.ReadLine().ToUpper();

                Console.Clear();

                if (menuChoice == "CF")
                {
                    ConvertCelsiusToFahrenheit();
                }
                else if (menuChoice == "FC")
                {
                    ConvertFahrenheitToCelsius();
                }
                else
                {
                    DisplayErrorMessage("Invalid menu choice. Please enter 'CF' or 'FC'.");
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage("An unexpected error occurred: " + ex.Message);
            }
        }

        static void DisplayWelcomeScreen()
        {
            Console.WriteLine("\n\n\n\n\n\n                    WELCOME TO . . .\n");
            System.Threading.Thread.Sleep(1500); // Wait 1.5 secs

            string[] menuTitle = {
                "       /01      /01 /01   /01 /01    /01010101 /010101  /010101   /010101  /01        /010101  /01",
                "      | 010    /101| 01  | 01| 01   |__  01__/|_  01_/ /01__  01 /01__  01| 01       /01__  01| 01",
                "      | 0101  /0101| 01  | 01| 01      | 01     | 01  | 01  \\__/| 01  \\ 01| 01      | 01  \\__/| 01",
                "      | 01 01/01 01| 01  | 01| 01      | 01     | 01  | 01      | 01010101| 01      | 01      | 01",
                "      | 01  010| 10| 10  | 10| 10      | 10     | 10  | 10      | 10__  10| 10      | 10      |__/",
                "      | 10\\  1 | 01| 01  | 01| 01      | 01     | 01  | 01    01| 01  | 01| 01      | 01    01    ",
                "      | 01 \\/  | 01|  010101/| 01010101| 01    /010101|  010101/| 01  | 01| 01010101|  010101/ /01",
                "      |__/     |__/ \\______/ |________/|__/   |______/ \\______/ |__/  |__/|________/ \\______/ |__/"
            };

            foreach (string line in menuTitle)
            {
                Console.WriteLine(line);
                System.Threading.Thread.Sleep(175); // Wait 0.175 secs
            }

            Console.WriteLine("\n\n\n\n\n\n");

            Console.Beep(1000, 250);
            Console.Beep(800, 250);
            Console.Beep(1600, 500);
        }

        static void ConvertCelsiusToFahrenheit()
        {
            Console.WriteLine("\n\nPlease enter a temperature in degrees Celsius as a whole number:");
            double celsius = GetValidNumberInput();

            double fahrenheit = (celsius * 9 / 5) + 32;

            Console.WriteLine($"\n{celsius} degrees Celsius is equal to {Math.Round(fahrenheit, 1)} degrees Fahrenheit");
        }

        static void ConvertFahrenheitToCelsius()
        {
            Console.WriteLine("\n\nPlease enter a temperature in degrees Fahrenheit as a whole number:");
            double fahrenheit = GetValidNumberInput();

            double celsius = (fahrenheit - 32) * 5 / 9;

            Console.WriteLine($"\n{fahrenheit} degrees Fahrenheit is equal to {Math.Round(celsius, 1)} degrees Celsius");
        }

        static double GetValidNumberInput()
        {
            double userInput;
            while (!double.TryParse(Console.ReadLine(), out userInput))
            {
                DisplayErrorMessage("Invalid input. Please enter a valid number:");
            }
            return userInput;
        }

        static void DisplayErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Beep(250, 250);
            Console.Beep(200, 500);
            Console.WriteLine("\n\n" + message);
        }
    }
}
