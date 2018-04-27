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
         * The main loop of the program, prints a menu, takes input, calls the appropriate functions and terminate
         */
        static void menuSwitcher()
        {
            int choice = -1;
            printMenu();
            choice = getIntInput();


            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        System.Console.WriteLine("Option 1 chosen\n");
                        startFile("File1.txt");
                        break;
                    case 2:
                        System.Console.WriteLine("Option 2 chosen\n");
                        printFile("File1.txt");
                        break;
                    case 3:
                        System.Console.WriteLine("Option 3 chosen\n");
                        printFiles();
                        break;
                    default:
                        System.Console.WriteLine("Not a valid option\n");
                        break;
                }

                printMenu();
                choice = getIntInput();
            }
        }

        /* 
         * A function that prints the menu
         */
        static void printMenu()
        {
            System.Console.WriteLine(
                "\n\n" +
                "Welcome to I/O test!\n" +
                "***************************************************\n" +
                "1 - Print content and append lines to \"File1\"\n" +
                "2 - Print content of \"File1\"\n" +
                "3 - Print names of tracked files\n" +
                "0 - exit \n \n");

        }

        /*
         * A function to get input from user and check that it's OK
         * 
         * @return  an int for the switch in menu
         */
        static int getIntInput()
        {
            int choice = -1;
            try
            {
                choice = Convert.ToInt16(System.Console.ReadLine());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                choice = -1;
            }
            return choice;
        }

        /* 
         * A function that checks if a file exists, creates it if it doesn't,
         * prints its content and appends as many lines as desired.
         * 
         * @param   the file to be created and/or written to
         */
        static void startFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    printFile(fileName);
                }
                else
                {
                    System.Console.WriteLine(fileName + " doesn't exist");
                    createFile(fileName);
                }
                appendLineToFile(fileName);
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
        }

        /*
         * Prints available files to be written to or read, keeps track via
         * "Files.txt" and creates one if it can't find it
         */
        static void printFiles()
        {
            try
            {
                if (File.Exists("Files.txt"))
                {
                    printFile("Files.txt");
                }
                else
                {
                    System.Console.WriteLine("Files.txt does not exist");
                    createFile("Files.txt");
                    catalogFile("Files.txt");
                }
            }
            catch(Exception e)
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
            using (StreamReader sr = File.OpenText(fileName))
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
         * file exist and doesn't catch exceptions
         * 
         * NOTE: Currently open and close connection for each line to append,
         * assume this to be safer than having loop "inside" connection, but
         * probably slower.
         * 
         * @param fileName  The name of the file to have lines appended
         */
        static void appendLineToFile(string fileName)
        {
            string choice = "";
            string input = "";
            while(choice != "n")
            {
                System.Console.WriteLine("Append a new line to the file " + fileName + "? enter 'n' to stop \n");
                choice = System.Console.ReadLine();
                if(choice != "n")
                {
                    System.Console.WriteLine("Enter desired line:");
                    input = System.Console.ReadLine();
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine(input);
                    }
                }
            }
        }

        /*
         * Appends a filename to the "Files.txt" used for keeping track of files.
         * 
         * @param fileName  The fileName to be appended to "Files.txt"
         */
        static void catalogFile(string fileName)
        {
            try
            {
                using (StreamWriter sw = File.AppendText("Files.txt"))
                {
                    sw.WriteLine(fileName);
                }
                System.Console.WriteLine(fileName + " appended to catalog");
            }catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
        }

        /*
         * Creates a new .txt file with the chosen name
         * 
         * @param fileName  The desired name of the new file
         */
        static void createFile(string fileName)
        {
            using (StreamWriter sw = File.CreateText(fileName)) { }
            System.Console.WriteLine("Created file: " + fileName);
        }
    }
}