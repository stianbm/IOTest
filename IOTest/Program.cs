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
         * A blacklist of file names not to create or alter files used administratively
         */
        private static string[] blackList = {"Files.txt", "File1.txt"};

        /* 
         * The main loop of the program, prints a menu, takes input, calls the appropriate functions and terminate
         */
        private static void menuSwitcher()
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
                    case 4:
                        System.Console.WriteLine("Option 4 chosen\n");
                        writeToFile();
                        break;
                    case 5:
                        System.Console.WriteLine("Option 4 chosen\n");
                        printChosenFile();
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
        private static void printMenu()
        {
            System.Console.WriteLine(
                "\n\n" +
                "Welcome to I/O test!\n" +
                "***************************************************\n" +
                "1 - Print content and append lines to \"File1\"\n" +
                "2 - Print content of \"File1\"\n" +
                "3 - Print names of tracked files\n" +
                "4 - Write to existing file, or create new and write\n" +
                "5 - Print content of arbitrary file\n" +
                "0 - exit \n \n");

        }

        /*
         * A function to get input from user and check that it's OK
         * 
         * @return  an int for the switch in menu
         */
        private static int getIntInput()
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
        private static void startFile(string fileName)
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
        private static void printFiles()
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
        private static void printFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
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
                else
                {
                    System.Console.WriteLine("Could not find the file: " + fileName);
                }
            }catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
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
        private static void appendLineToFile(string fileName)
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
         * Assumes "Files.txt" exist.
         * 
         * @param fileName  The fileName to be appended to "Files.txt"
         */
        private static void catalogFile(string fileName)
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
        private static void createFile(string fileName)
        {
            using (StreamWriter sw = File.CreateText(fileName)) { }
            System.Console.WriteLine("Created file: " + fileName);
            catalogFile(fileName);
        }

        /*
         * Gets user input, see if fileName is legal and exist, if not legal deny
         * if legal and exist write, if not exist ask to create
         */
        private static void writeToFile()
        {
            string choice = "";
            System.Console.WriteLine("Press n to exit or anything else to continue and choose file");
            choice = System.Console.ReadLine();
            if(choice != "n")
            {
                System.Console.WriteLine("Choose file name:");
                string fileName = System.Console.ReadLine() + ".txt";
                if (nameAllowed(fileName))
                {
                    if (!isInCatalog(fileName))
                    {
                        createFile(fileName);
                    }
                    appendLineToFile(fileName);
                }
            }
        }

        /*
         * Checks if a fileName is in the blaclist
         * 
         * @param fileName  The file to be checked
         */
        private static bool nameAllowed(string fileName)
        {
            for(uint i = 0; i < blackList.Length; i++)
            {
                if(fileName == blackList[i])
                {
                    System.Console.WriteLine(fileName + " is in blackList");
                    return false;
                }
            }
            System.Console.WriteLine(fileName + " is not in blackList");
            return true;
        }

        /*
         * Checks if a file is in the Files.txt catalog
         */
        private static bool isInCatalog(string fileName)
        {
            try
            {
                if (File.Exists("Files.txt"))
                {
                    using (StreamReader sr = File.OpenText("Files.txt"))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            if(line == fileName)
                            {
                                System.Console.WriteLine(fileName + " is in catalog");
                                return true;
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return false;
            }
        }


        private static void printChosenFile()
        {
            System.Console.WriteLine("Enter the name of the file:");
            string fileName = System.Console.ReadLine() + ".txt";
            printFile(fileName);
        }
    }
}