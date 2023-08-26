# DLGTextCrawler

A small command line program that crawls extracted text files from Apollo Justice, and returns all the lines of dialogue spoken by the requested characters - cleaned of control codes and markup text.

It's intended to be used alongside the existing dlgTool, which extracts the heavily annotated game script from the binary files. DLGTextCrawler is for converting those annotated texts into a more readable format.

## Usage:

Place the executable in the same folder as the extracted TXT files, and run it, providing as many character IDs as you like as the arguments.

To see what the character IDs are, run the program without any arguments to trigger the help page.
