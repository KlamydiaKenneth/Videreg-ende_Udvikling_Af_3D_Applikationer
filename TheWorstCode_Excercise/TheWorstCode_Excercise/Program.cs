﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorstCode_Excercise
{
    class Program
    {
        static int Main(string[] args)
        {
            bool quit = false;

            while (quit == false)
            {
                Console.OutputEncoding = Encoding.UTF8;

                Console.WriteLine("------------------------\n");
                Console.WriteLine("Some weird number excercise in C#\r");
                Console.WriteLine("------------------------\n");

                Console.WriteLine("Type two numbers, press enter after each number =|:^)");
                Console.WriteLine("------------------------\n");
                Console.WriteLine("Let's start with the first number (>▀¯▀)>");
                string higgerMajigger = Console.ReadLine();
                int hoggerMajogger = Convert.ToInt32(higgerMajigger);
                Console.WriteLine("And now the second number ( •_•)>⌐■-■");
                string moggerHajogger = Console.ReadLine();
                int miggerHajigger = Convert.ToInt32(moggerHajogger);
                if (higgerMajigger == moggerHajogger)
                {
                    Console.WriteLine("You just triggered the part of this assignment that makes absolutely no sense! (σ^ω^)σ");
                    Console.WriteLine((hoggerMajogger + miggerHajigger) * 3);
                }
                else
                {
                    Console.WriteLine("Hooray, guess what, the numbers were added together!");
                    Console.WriteLine(hoggerMajogger + miggerHajigger);
                }
                Console.WriteLine("Choose an option:");
                Console.WriteLine("\ta - Try again");
                Console.WriteLine("\ts - Quit");
                Console.Write("Your option? ");
                switch (Console.ReadLine())
                {
                    case "a":
                        break;
                    case "s":
                        quit = true;
                        break;
                }
            }
            return - 1;
        }
    }
}
