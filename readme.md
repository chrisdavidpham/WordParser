# WordParser

### Summary
This program parses alphnumeric words in a sentence by counting the distinct characters between the first and last character of a word, and replacing those characters with that count.
A word is any character, string of consecutive alphanumeric characters, or string of special characters. Alphanumeric words are delimited by special characters.

### How to run

##### Command line arguments
Run the program using command line arguments as the input to parse.

##### Interactive menu
Run the program with the command line argument `-i` to start interactive mode. Follow the prompts in the console.

### Problem Description
Write a program that parses a sentence and replaces each word with the following: first letter, number of distinct characters between first and last character, and last letter.
Words are separated by spaces or non-alphabetic characters and these separators should be maintained in their original form and location in the answer.

##### Example input
Input 1:    It was many and many a year ago
Output 1:   I0t w1s m2y a1d m2y a y2r a1o
Input 2:    Copyright,Microsoft:Corporation
Output 2:   C7t,M6t:C6n

##### User interface requirements
Input: Command Line Interface: One should be able to pass the argument (input) on command line
Output: Should print the output on command line
 
##### Rules
 
* Code variables must be in English.
* Use the main function arguments.
* The function should not be static nor main.
* The function should not use hardcoded values.
* The function must be reusable.
* Include test cases.
* Document your code.

### Unruled parsing scenarios

##### Numbers
The word parser treates numeric characters identically to alphabetical characters. For example, "2021" becomes "221", and "r0b07" becomes "r27"

##### Case sensitivity
The word parser is case sensitive, so `a` and `A` are considered distinct characters. For example, "gOoD" is parsed as "g2D"