using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //For IO funksjoner

//Ka e best, fil med oversikt, elle oversikt i begynne av alle filer?

// 

namespace IOTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //FilOversikt: If fil med info !finnes {Lag den}
            //FileOverview();

            //Switch variabel
            MainMenu();

            //Save progress
        }

        //Print meny
        static void PrintMenu()
        {
            System.Console.WriteLine("Welcome to I/O - test, you sexy hunk you");
            System.Console.WriteLine("***************************************************");
            System.Console.WriteLine(" 1 - See files");
            System.Console.WriteLine(" 2 - Select file");
            System.Console.WriteLine(" 3 - Delete file");
            System.Console.WriteLine(" 4 - Make new file");
            System.Console.WriteLine(" 5 - Write to \"TextFile1.txt\"");
            System.Console.WriteLine(" 0 - Exit the best program south of the North Pole (y would u tho?)\n");
        }

        //Switch input
        static void MainMenu()
        {
            string answer = "";
            while (answer != "0")
            {
                //HovedMeny, hva vil du gjøre?
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

        //Print FilVektor
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

        //Print FilVektor med resirkulert funksjon
        static void PrintFiles2()
        {
            System.Console.WriteLine("\nFiles found:\n");
            string[] Files = FileOverview();
            foreach (string element in Files)
            {
                System.Console.WriteLine(element);
            }
        }

        //Les lagret info, returner string array med [0]="" hvis Files.txt ikke eksisterer/first startup
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

        //Returnerer string[] med filnavn, [0] = "" hvis lista er tom.
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

        //Lag en Files.txt fil
        static void NewFilesTxt()
        {
            string[] FirstList = { "Files.txt" };
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Files.txt"))
            {
                sw.WriteLine(FirstList[0]);
            }
        }

        //Legger til text til "TextFile1.txt" uten å oppdatere "Files.txt" med info om "TextFile1.txt", blir overskrevet hver gang.
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

        //Create new file
        static void CreateNewTextFile()
        {
            System.Console.WriteLine("What will be the file name?");
            string FileName = System.Console.ReadLine();
            //Check if file exist, refine to stop iterating if true
            String[] FileList = GetInfo();
            bool exist = false;
            foreach (string element in FileList)
            {
                if (FileName == element)
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
                System.IO.StreamWriter sw = new System.IO.StreamWriter(FileName);
                UpDateFiles(FileName);
            }
        }

        //Delete file


        //Prettyfy "Files.txt"


        //FileMenu


        //Oppdater ovesikt, anta "Files.txt" finnes
        static void UpDateFiles(string FileName)
        {
            using (System.IO.StreamWriter sw = System.IO.File.AppendText("Files.txt"))
            {
                sw.WriteLine(FileName);
            }
        }
    }
}
