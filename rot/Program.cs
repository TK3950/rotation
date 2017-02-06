﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * TODO: examine for error-cases
 */
namespace rot
{
    class Program
    {       
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

            for (int c = 0; c < args.Length; c++) // if there's one or more args
            {
                fpath = args[0]; // first arg is our new file path
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
                string line = lines[i].ToLower();
                string newline = "";
                for (int j = 0; j < line.Length; j++) // for each letter in line
                {   
                    char newchar ='?';
                    int newint = Convert.ToInt32(Convert.ToChar(line[j]) + rotation);
                    //
                    if (newint > Convert.ToInt32('z')) // if rotated int overflows our acceptable range, move it back inside
                    {
                        newint -= 26;
                    }
                    newchar = Convert.ToChar(newint);
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