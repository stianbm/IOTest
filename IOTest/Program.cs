using System;
using System.IO;

/* 
 * A simple program to test some simple file I/O
 * 
 * @author stianbm
 */
 namespace Program {
    class Program
    {

        static void Main(string[] args)
        {
            menuSwitcher();
        }

        /* 
         * A function that prints a menu, takes input and calls the appropriate function
         */
        static void menuSwitcher()
        {
            int choice = -1;
            printMenu();
            try
            {
                choice = Convert.ToInt16(System.Console.ReadLine());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }


            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        System.Console.WriteLine("Option 1 chosen");
                        File1();
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

        /* 
         * A function that prints the menu
         */
        static void printMenu()
        {
            System.Console.WriteLine(
                "Welcome to I/O test!\n" +
                "***************************************************\n" +
                "1 - Print content and append lines to \"File1\"\n" +
                "0 - exit \n \n");

        }

        /* 
         * A function that checks if "File1.txt" exists, creates it if it doesn't,
         * prints its content and appends as many lines as desired.
         */
        static void File1()
        {
            try
            {
                if (File.Exists("File1"))
                {
                    printFile("File1");
                    appendLineToFile("File1");
                }
            }catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
            
        }

        /* 
         * Prints the lines in the given file, assumes it exist.
         * Does not catch exceptions
         * 
         * @param fileName  The name of the file to be printed
         */
        static void printFile(string fileName)
        {
            using (StreamReader sr = File.OpenText(fileName + ".txt"))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                }
            }
        }

        /* 
         * Appends lines to a .txt file as long as the user wants, assumes
         * file exist and doesn't catch exceptions.
         * 
         * @paran fileName  The name of the file to have lines appended
         */
        static void appendLineToFile(string fileName)
        {

        }
    }
}