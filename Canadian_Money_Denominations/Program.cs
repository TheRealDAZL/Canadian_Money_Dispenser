namespace Canadian_Money_Denominations
{
    internal class Program
    {
        static void Main()
        {
            bool quit = false;

            while (!quit)
            {
                double totalAmount;

                ValidateThenSet(out totalAmount);

                CalculateThenGet(totalAmount);

                quit = QuitOrNot();

                Console.Write("\n");
            }





            void ValidateThenSet(out double totalAmount)
            {
                while (true)
                {
                    Console.WriteLine("Enter the amount of money to be dispensed in denominations:");

                    if (double.TryParse(Console.ReadLine(), out totalAmount) && totalAmount >= 0)
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("\nError: invalid value.\n");
                    }
                }
            }

            void CalculateThenGet(double totalAmount)
            {
                int[] DENOMINATIONS_IN_CENTS = { 10000, 5000, 2000, 1000, 500, 200, 100, 25, 10, 5 };
                string[] DENOMINATION_NAMES = { "100$", "50$", "20$", "10$", "5$", "2$", "1$", "0.25$", "0.10$", "0.05$" };
                int amountInCents = (int) (Math.Round(totalAmount * 20) / 20 * 100);

                if (amountInCents == 0)
                {
                    Console.WriteLine("\nThe given amount of money rounds to 0$.");

                    return;
                }

                Console.WriteLine($"\nThe given amount of money can be decomposed as follows:");

                for (int counter = 0; counter < DENOMINATIONS_IN_CENTS.Length; counter++)
                {
                    int denominationsCount = (int) (amountInCents / DENOMINATIONS_IN_CENTS[counter]);

                    if (denominationsCount > 0)
                    {
                        Console.WriteLine($"{denominationsCount} X {DENOMINATION_NAMES[counter]}");

                        amountInCents -= denominationsCount * DENOMINATIONS_IN_CENTS[counter];
                    }
                }
            }

            bool QuitOrNot()
            {
                Console.WriteLine("\nDo you want to continue? Hit Enter to continue, or write \"q\" and then press Enter to quit:");

                return ((Console.ReadLine() == "q") ? true : false);
            }
        }
    }
}
