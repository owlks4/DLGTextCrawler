using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DLGScalpel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                showHelp();
            }
            else
            {
                for (int arg = 0; arg < args.Length; arg++)
                {
                    try
                    {
                        int.Parse(args[arg].Trim());
                        Console.WriteLine(args[arg]);
                    }
                    catch
                    {
                        showHelp();
                        return;
                    }

                    FileInfo[] files = new DirectoryInfo(Directory.GetCurrentDirectory()).GetFiles();

                    foreach (FileInfo f in files)
                    {

                        if (f.Extension != ".txt")
                            continue;

                        string s = File.ReadAllText(f.FullName).Replace("<b>", " ").Replace("<p>", "\n");
                        List<string> output = new List<string>();

                        string searchPattern = "<name: " + (int.Parse(args[arg]) << 8) + ">";

                        int lastIndex = s.LastIndexOf(searchPattern);
                        int curPosition = 0;

                        do
                        {
                            curPosition = s.IndexOf(searchPattern, curPosition);
                            if (curPosition == -1)
                            {
                                break;
                            }
                            int nextNameTagPosition = s.IndexOf("<name:", curPosition + 1);
                            if (nextNameTagPosition == -1)
                            {
                                nextNameTagPosition = s.Length - 1;
                            }

                            int scope = 0;

                            StringBuilder sb = new StringBuilder();

                            for (int i = curPosition; i < nextNameTagPosition; i++)
                            {
                                if (s[i] == '<')
                                {
                                    scope++;
                                }
                                else if (s[i] == '>')
                                {
                                    scope--;
                                }
                                else if (scope == 0)
                                {
                                    sb.Append(s[i]);
                                }
                            }
                            string line = sb.ToString();
                            if (s.Trim().Length > 0)
                            {
                                output.Add(line);
                            }

                            curPosition = nextNameTagPosition;
                        } while (curPosition != s.Length - 1);

                        if (output.Count > 0)
                        {
                            File.WriteAllLines(f.FullName.Replace(".txt", "_CHARACTER_" + args[arg] + ".txt"), output.ToArray());
                        }
                    }
                }
            }
        }

        static void showHelp()
        {
            Console.WriteLine("Error: incorrect arguments provided!");
            Console.WriteLine("The only argument provided should be the ID number(s) of the character name associated with the lines you would like extracted.");
            Console.WriteLine("This program will check all .txt files in its directory for said lines,\nso make sure you have placed it in the same folder as  txt files you extracted from the DLG with dlgTool.");
            Console.WriteLine("Character IDs that may be of interest:");

            Console.WriteLine("0: System text");
            Console.WriteLine("1: Generic");
            Console.WriteLine("2: Generic male");
            Console.WriteLine("3: Generic female");
            Console.WriteLine("4: Apollo Justice");
            Console.WriteLine("5: Trucy Wright");
            Console.WriteLine("6: Kristoph Gavin (disbarred)");
            Console.WriteLine("7: Phoenix Wright");
            Console.WriteLine("8: Kristoph Gavin (co-counsel)");
            Console.WriteLine("9: Ema Skye");
            Console.WriteLine("10: Judge");
            Console.WriteLine("11: Winston Payne");
            Console.WriteLine("12: Olga Orly");
            Console.WriteLine("13: Alita Tiala");
            Console.WriteLine("14: Wocky Kitaki");
            Console.WriteLine("15: Eldoon");
            Console.WriteLine("16: Plum Kitaki");
            Console.WriteLine("17: Winfred Kitaki");
            Console.WriteLine("19: Vera Misham");
            Console.WriteLine("20: Spark Brushel");
            Console.WriteLine("22: Dick Gumshoe");
            Console.WriteLine("26: Drew Misham");
            Console.WriteLine("30: Stickler");
            Console.WriteLine("31: Zak Gramarye");
            Console.WriteLine("33: Valant Gramarye");
            Console.WriteLine("34: Lamiroir");
            Console.WriteLine("35: Machi Tobaye");
            Console.WriteLine("36: Romein LeTouse");
            Console.WriteLine("37: Daryan Crescend");
            Console.WriteLine("43: Bailiff");
            Console.WriteLine("44: Officer");
            Console.WriteLine("45: Announcer");
            Console.WriteLine("46: Mr. Hat");
            Console.WriteLine("47: Dr. Meratkis");
            Console.WriteLine("48: Zak Gramarye (2)");
            Console.WriteLine("50: Magnifi Gramarye");
            Console.WriteLine("51: Jurist No. 6");
            Console.WriteLine("52: Guard");
            Console.WriteLine("53: Klavier Gavin");
            Console.WriteLine("55: Staff");
        }
    }
}
