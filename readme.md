# WordParser
 Problem Description
 
 Write a program that parses a sentence and replaces each word with the following:
 first letter, number of distinct characters between first and last character, and last letter. For example, Smooth would become S3h.
 Words are separated by spaces or non-alphabetic characters and these separators should be maintained in their original form and location in the answer.

## Instructions to Run
### Method 1
Run the .exe and follow the text prompts in the console window.

### Method 2
Compile the project in Visual Studio 2019, set the input argument in project properties, and run the program.

## Special cases
### Apostrophes
This program deliberately removes single quote marks from abbreviated words such as "isn't" and "I've".
Since the apostrophe is not a letter or number, it is not counted when calculating the number of distinct characters in a word.
This program will not consider apostrophes to be the first or last character of a word. For example, "Class of '01" or "ol' reliable."
Another example would be a single quoted phrase within a sentence. For example, "This 'is quoted' inside."

### Numbers
By design, this program will treat numbers like words when parsing them. For example, "2021" becomes "221", and "12:34:567" becomes "102:304:517"