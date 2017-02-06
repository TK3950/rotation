# Rotation - Caesar Cipher Comparison and Analysis Application
This Command-Line application rotates a word-list according to a user specified Caesar Cipher rotation, then compares the rotated list against the source list to search for any matching entries.

A sample word-list can be downloaded from https://github.com/dwyl/english-words/blob/master/words.txt?raw=true
Alternative word-lists work just as well, as long as each word in the list is separated by a newline.
Otherwise, simple modifications to the code I have provided can allow you to use other delimiters, such as commas, tabs, etc.

The flowchart for this application will be created and uploaded shortly.
This code solves a simple problem with a simple algorithm, there's no real need to protect it with any special licensing. Feel free to copy or modify. If you're a nice guy, leave my name in the project and include a link to this repository.

#Description of algorithm

The program begins by setting up the environment and variables, then prompts the user to 
input the desired rotation key.To function normally, the program expects an input of type 
int between 0 and 25. Once the user has input their desired rotation key, the program 
begins to open a word-list as specified in the program arguments. The first argument 
passed to the application should be the path to your file. If no arguments are specified, 
it defaults to opening "%userprofile\Desktop\words.txt". If the file exists, it opens the 
file and reads every line into a string array called 'lines'. Otherwise, the program will 
exit with status -2. A second array called 'newlines' is declared and initialized to the 
same length as 'lines'.

The program then enters its primary loop. For every line in the array 'lines', two local 
strings called 'line' and 'newline' are declared. Local string 'line' is set to a 
lowercase copy of the current line in array 'lines', and 'newline' is set to an empty 
string. Then the program enters its secondary loop. For every characer in string 'line', a
 local char is declared called 'newchar' which is initialized to the literal '?'. A local 
 integer called 'newint' is declared and initialized to 0. If the current character is 
 within our alphabet, 'newint' is set to the ASCII Decimal integer equivalent of the 
 current character plus the rotation key. If this 'newint' is greater than the ASCII 
 Decimal integer equivalent of the lowercase literal 'z', this indicates the rotation (or 
 shift) has overflowed from our alphabet, and the program subtracts 26 from 'newint' to 
 bring it back within our alphabet. In either case, 'newchar' is set to the the ASCII 
 character equivalent of 'newint'. However, if the current character is not within our 
 alphabet (else to first condition), 'newchar' is set to the current character, 
 effectively passing non-rotatable values through to the second array. Local string 
 'newchar' is then inserted/appended to local string 'newline', finishing they secondary 
 loop. Still within the primary loop, the program calculates how much of the source list 
 has been rotated thus-far, and if the integer-truncated percentage is different than the 
 last time it was calculated, the new percentage is displayed on screen. The primary loop 
 finishes. For a 5 MB word-list containing over 450,000 words, these loops should only 
 last for a few seconds.

The program then calls the 'CompareStrings' method, which will search for strings that 
occur in both lists. At the moment, this is a very "dumb" method which takes a VERY long 
time to execute. It simply searches for every element of the source array within the 
secondary array. I'm not certain what algorithm is used by the 'Contains' method include 
in the framework, but I am fairly certain that it can be improved upon, especially if all 
lists are sorted alphabetically. For the time being, I will be examining how I can perform 
a better search on these two strings.
