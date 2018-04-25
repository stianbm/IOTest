using System;

/* A simple program to test some simple file I/O
 */
class Program
{

    static void Main(string[] args)
    {
        menuSwitcher();
    }

    /* A function that prints a menu, takes input and calls the appropriate function
     */
    static void menuSwitcher()
    {
        int choice = -1;
        printMenu();
        try
        {
            choice = Convert.ToInt16(System.Console.ReadLine());
        }catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
        

        while (choice != 0)
        {
            switch (choice)
            {
                case 1:
                    System.Console.WriteLine("Case 1");
                    break;
                default:
                    System.Console.WriteLine("Not a valid option");
                    break;
            }

            printMenu();
            try
            {
                choice = Convert.ToInt16(System.Console.ReadLine());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                choice = -1;
            }
        }
    }

    /* A function that prints the menu
     */
    static void printMenu()
    {
        System.Console.WriteLine(
            "Welcome to I/O test! \n" +
            "*********************\n" +
            "0 - exit \n \n");

    }
}