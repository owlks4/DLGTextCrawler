# DLGScalpel

A small command line program that crawls extracted text files from Apollo Justice, and returns the lines for a specified character fully cleaned of control codes and markup text.

It's intended to be used alongside the existing dlgTool, which extracts the heavily annotated game script from the binary files. DLGScalpel is for converting those annotated texts into a more readable format.

## Usage:

Place the executable in the same folder as the extracted TXT files, and run it, providing as many character IDs as you like as the arguments.

To see what the character IDs are, run the program without any arguments to trigger the help page.