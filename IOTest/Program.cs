using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //For IO funksjoner

namespace IOTest
{
    /* The program will allow the user to create text files, one line at the time.
     * You can add lines to existing files, and delete them.
     * It keeps track of the files through as "hidden" txt file, and one can therefore not create a
     * a text file with the name "Files.txt".
     */
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        /* Prints the menu to the command line
         */
        static void PrintMenu()
        {
            System.Console.WriteLine("\n\n\n\n");
            System.Console.WriteLine("Welcome to I/O - test, you sexy hunk you");
            System.Console.WriteLine("***************************************************");
            System.Console.WriteLine(" 1 - See files");
            System.Console.WriteLine(" 2 - Select file");
            System.Console.WriteLine(" 3 - Delete file");
            System.Console.WriteLine(" 4 - Make new file");
            System.Console.WriteLine(" 5 - Write to \"TextFile1.txt\"");
            System.Console.WriteLine(" 0 - Exit the best program south of the North Pole (y would u tho?)\n");
        }

         /* Switches input and calls appropriate function
          */
        static void MainMenu()
        {
            string answer = "";
            while (answer != "0")
            {
                PrintMenu();
                answer = System.Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        PrintFiles();
                        break;
                    case "2":
                        System.Console.WriteLine("This part will be available in a future DLC");
                        break;
                    case "3":
                        System.Console.WriteLine("This part will be available in a future DLC");
                        break;
                    case "4":
                        CreateNewTextFile();
                        break;
                    case "5":
                        WriteToTextFile1();
                        break;
                    default:
                        System.Console.WriteLine("Invalid choice, m'person *tips hat*");
                        break;
                }
            }
        }

        /* Prints the content in "Files.txt", in other words the created files
         */
        static void PrintFiles()
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader("Files.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                }
            }
        }

        /* Prints the files from Files.txt using the getInfo() function
         */
        static void PrintFiles2()
        {
            System.Console.WriteLine("\nFiles found:\n");
            string[] Files = FileOverview();
            foreach (string element in Files)
            {
                System.Console.WriteLine(element);
            }
        }

        /* Reads the filenames of "Files.txt" into a list of Strings, if it doesn't exist it throws an
         * exception and returns an empty list
         * @return  a list of strings, either empty or filled with file names
         * 
         * TODO change need to distinguish between empty Files.txt and non-existing
         */
        static string[] GetInfo()
        {
            string[] ReturnList = { "" };
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("Files.txt"))
                {
                    int i = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ReturnList[i++] = line;
                    }
                    return ReturnList;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("e.Message:");
                System.Console.WriteLine(e.Message);
                return ReturnList;
            }
        }

        /* Reads file names from Files.txt and creates the file if it doesn't exist
         * @return  a list of strings, either filled with file names, or empty
         * 
         * TODO change according to function above to see if Files.txt is empty or doesn't exist
         */
        static string[] FileOverview()
        {
            string[] Files = GetInfo();
            if (Files[0] == "")
            {
                //Make Files.txt
                NewFilesTxt();
            }
            return Files;
        }

        /* Creates the Files.txt and places itself inside as the first entry
         */
        static void NewFilesTxt()
        {
            string[] FirstList = { "Files.txt" };
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Files.txt"))
            {
                sw.WriteLine(FirstList[0]);
            }
        }

        /* Appends lines to TextFile1.txt, assums it exists and doesn't update Files.txt
         */
        static void WriteToTextFile1()
        {
            PrintFileContent("TextFile1.txt");
            using (System.IO.StreamWriter sw = System.IO.File.AppendText("TextFile1.txt"))
            {
                string input = "y";
                do
                {
                    if (input != "y")
                    {
                        System.Console.WriteLine("Invalid answer");
                    }
                    else
                    {
                        System.Console.WriteLine("Write your line:");
                        string line = System.Console.ReadLine();
                        sw.WriteLine(line);
                    }
                    System.Console.WriteLine("Write new line? [y/n]");
                    input = System.Console.ReadLine();
                } while (input != "n");
            }
            PrintFileContent("TextFile1.txt");
        }

        /* Prints the content of a text file, catches exception if it doesn't exist
         */
        static void PrintFileContent(string FileName)
        {
            try
            {
                System.Console.WriteLine("File: " + FileName);
                using (System.IO.StreamReader sr = new System.IO.StreamReader(FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        System.Console.WriteLine(line);
                    }
                }
                System.Console.WriteLine("\n\n");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Could not read file" + FileName);
                System.Console.WriteLine("e.Message:");
                System.Console.WriteLine(e.Message);
            }
        }

        /* Creates a new file name, checks for duplicates of already existing files
         */
        static void CreateNewTextFile()
        {
            System.Console.WriteLine("What will be the file name?");
            string fileName = System.Console.ReadLine();
            // Check if file exist, refine to stop iterating if true
            String[] FileList = GetInfo();
            bool exist = false;
            foreach (string element in FileList)
            {
                if (fileName == element)
                {
                    exist = true;
                    break;
                }
            }
            if (exist)
            {
                System.Console.WriteLine("The file allready exist\n");
            }
            else
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName);
                UpDateFiles(fileName);
            }
        }

        //Delete file


        //Prettyfy "Files.txt"


        //FileMenu


        //Oppdater ovesikt, anta "Files.txt" finnes
        /* Appends a file name to Files.txt, assumes Files.txt exists
         */
        static void UpDateFiles(string FileName)
        {
            using (System.IO.StreamWriter sw = System.IO.File.AppendText("Files.txt"))
            {
                sw.WriteLine(FileName);
            }
        }
    }
}
