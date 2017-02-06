using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * TODO: Fine-tune operations and clean up
 *       Cleanly reduce all strings to lowercase
 */
namespace rot
{


    class Program
    {
        

        /// <summary>
        /// Retrieves lowercase letter of type char at the specified position in the alphabet.
        /// </summary>
        /// <param name="number">Integer value 1-26 representing position in the alphabet</param>
        /// <returns>Lowercase letter a-z</returns>
        static char IntToChar(int number)
        {

            switch (number)
            {
                case 1:
                    return 'a';
                case 2:
                    return 'b';
                case 3:
                    return 'c';
                case 4:
                    return 'd';
                case 5:
                    return 'e';
                case 6:
                    return 'f';
                case 7:
                    return 'g';
                case 8:
                    return 'h';
                case 9:
                    return 'i';
                case 10:
                    return 'j';
                case 11:
                    return 'k';
                case 12:
                    return 'l';
                case 13:
                    return 'm';
                case 14:
                    return 'n';
                case 15:
                    return 'o';
                case 16:
                    return 'p';
                case 17:
                    return 'q';
                case 18:
                    return 'r';
                case 19:
                    return 's';
                case 20:
                    return 't';
                case 21:
                    return 'u';
                case 22:
                    return 'v';
                case 23:
                    return 'w';
                case 24:
                    return 'x';
                case 25:
                    return 'y';
                case 26:
                    return 'z';
            }
#if debug
            Console.WriteLine("Failed on " + Convert.ToString(number));
#endif
            return '?';
        }


        /// <summary>
        /// Converts element of type char to an integer representing its position in the alphabet.
        /// </summary>
        /// <param name="letter">Upper or lower case letter A-Z</param>
        /// <returns>Integer representing letter's position in alphabet.</returns>
        static int CharToInt(char letter)
        {

            switch (letter)
            {
                case 'a':
                case 'A':
                    return 1;
                case 'b':
                case 'B':
                    return 2;
                case 'c':
                case 'C':
                    return 3;
                case 'd':
                case 'D':
                    return 4;
                case 'e':
                case 'E':
                    return 5;
                case 'f':
                case 'F':
                    return 6;
                case 'g':
                case 'G':
                    return 7;
                case 'h':
                case 'H':
                    return 8;
                case 'i':
                case 'I':
                    return 9;
                case 'j':
                case 'J':
                    return 10;
                case 'k':
                case 'K':
                    return 11;
                case 'l':
                case 'L':
                    return 12;
                case 'm':
                case 'M':
                    return 13;
                case 'n':
                case 'N':
                    return 14;
                case 'o':
                case 'O':
                    return 15;
                case 'p':
                case 'P':
                    return 16;
                case 'q':
                case 'Q':
                    return 17;
                case 'r':
                case 'R':
                    return 18;
                case 's':
                case 'S':
                    return 19;
                case 't':
                case 'T':
                    return 20;
                case 'u':
                case 'U':
                    return 21;
                case 'v':
                case 'V':
                    return 22;
                case 'w':
                case 'W':
                    return 23;
                case 'x':
                case 'X':
                    return 24;
                case 'y':
                case 'Y':
                    return 25;
                case 'z':
                case 'Z':
                    return 26;
            }
#if debug
            Console.WriteLine("Failed on " + Convert.ToString(letter));
#endif
            return 0;
        }

        /// <summary>
        /// Searches for every element of source array within a secondary array and prints matched elements to the Console
        /// </summary>
        /// <param name="source">Source array of strings to search for</param>
        /// <param name="secondary">Secondary array of strings to search within</param>
        static void CompareStrings(string[] source, string[] secondary)
        {
            Console.WriteLine("Searching for matching entries...");
            Console.WriteLine("Matches: ");
            {
            for (int i = 0; i < source.Length; i++)
                if (secondary.Contains(source[i]))
                {
                    Console.WriteLine(source[i] + " == " + secondary[i]);

                }
                Console.WriteLine("[[DONE!]]");
            }
        }



        /// <summary>
        /// Main entry point for this application. It controls the input file, rotation, and output. Returns exit status of program.
        /// </summary>
        /// <param name="args">args[0]: path to source array file</param>
        /// <returns>Exit status of program</returns>
        static int Main(string[] args)
        {
            Console.Title = "Caesar Cipher Comparison and Analysis Application   (C) Timothy Kersten - 2017";
            Console.WriteLine(Console.Title);
            Console.WriteLine("Source available on GitHub (https://github.com/TK3950/rotation)");
            int lastpercent = 10;
            int newpercent = 0;
            int rotation = 0;
            string fpath = Environment.ExpandEnvironmentVariables(@"%userprofile%\Desktop\words.txt");
            string[] lines = { "", "" };

            for (int c = 0; c < args.Length; c++)
            {
                fpath = args[0];
            }
            

            Console.Write("Enter the rotation you would like to analyze (0-25): ");
            rotation = Convert.ToInt32(Console.ReadLine());

            #region Heavy lifting
            Console.Write("Opening wordlist... ");
            if (System.IO.File.Exists(fpath))
            {
                lines = System.IO.File.ReadAllLines(fpath);
            }
            else
            {
                Console.WriteLine("Error opening file: " + fpath + "\nPress any key to quit...");
                Console.ReadKey();
                return -2;
            }
            Console.WriteLine("done!");
            string[] newlines = new string[lines.Length]; // the string array for our rotated list.
            Console.WriteLine("Rotating words... ");
            for (int i = 0; i < lines.Length; i++) // for each line in file array
            {
                string line = lines[i];
                string newline = "";
                for (int j = 0; j < line.Length; j++) // for each letter in line
                {   
                    char newchar ='?';
                    int newint = CharToInt(Convert.ToChar(line[j])) + rotation;
                    
                    if (newint < 27 && newint > 0)
                    {
                        newchar = IntToChar(newint);
                    }
                    if (newint >= 27)
                    {
                        newint -= 26;
                        newchar = IntToChar(newint);
                    }
                    if (newint < 0)
                    {
                        Console.WriteLine("Error occured. Attempted to convert to invalid character.\nPress any key to quit\nError: " + Convert.ToString(newint));
                        Console.ReadKey();
                        return -1; // newwint failed check.
                    }
                    if (newint == 0)
                    {
                        newchar = line[j]; // characters not in the alphabet are simply passed through to the new word
                                           // this includes numbers and symbols (0-9, ',`,*, etc.)
                    }
#if debug
                    Console.Write(Convert.ToString(newchar));
#endif
                    newline = newline.Insert(newline.Length,Convert.ToString(newchar));
                }
                
                newpercent = Convert.ToInt32((Convert.ToDouble(i) / Convert.ToDouble(newlines.Length)) * 100);
                if (newpercent != lastpercent)
                {
                    Console.SetCursorPosition(18, 4);
                    Console.Write(Convert.ToString(newpercent) + "% complete... ");
                    lastpercent = newpercent; // show percentage of rotation completed
                }
                // finish the work here
                newlines[i] = newline; // make new line in array newlines

            } // when this execution finishes, we have two full arrays.
              // one normal, one rotated. the next portion of code should pass control
              // to comparisons methods
            Console.WriteLine("done!");
            CompareStrings(lines, newlines);

            Console.WriteLine("Execution finished successfully.\nPress any key to quit\n");
            Console.ReadKey();
#endregion
            return 0; // program executed desired path, normal return
        }
    }
}
