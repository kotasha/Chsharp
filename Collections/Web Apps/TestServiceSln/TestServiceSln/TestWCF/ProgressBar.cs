using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestWCF
{
    public delegate void MyProgressBarDelegate();

    public class ProgressBar
    {
        public static void OverwriteConsoleMessage(string message)
        {
            Console.CursorLeft = 0;
            int maxCharacterWidth = Console.WindowWidth - 1;
            if (message.Length > maxCharacterWidth)
            {
                message = message.Substring(0, maxCharacterWidth - 3) + "...";
            }
            message = message + new string(' ', maxCharacterWidth - message.Length);
            Console.Write(message);
        }

        public static void RenderConsoleProgress(int percentage)
        {
            RenderConsoleProgress(percentage, '\u2590', Console.ForegroundColor, "");
        }

        public static void RenderConsoleProgress(int percentage, char progressBarCharacter,
                  ConsoleColor color, string message)
        {
            Console.CursorVisible = false;
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.CursorLeft = 0;
            int width = Console.WindowWidth - 1;
            int newWidth = (int)((width * percentage) / 100d);
            string progBar = new string(progressBarCharacter, newWidth) +
                  new string(' ', width - newWidth);
            Console.Write(progBar);
            if (string.IsNullOrEmpty(message)) message = "";
            Console.CursorTop++;
            OverwriteConsoleMessage(message);
            Console.CursorTop--;
            Console.ForegroundColor = originalColor;
            Console.CursorVisible = true;
        }
        public void MyProgressBar()
        {
            Console.Write("Working... \n");
            //Console.Write("{0,3:##0}%", 0);
            for (int i = 0; i < 100; i=i+2)
            {
                //Console.Write(new String('c', 4));//'Backspace x 4  
                System.Threading.Thread.Sleep(100);
                //Console.Write("{0,3:##0}%", i);
                Console.Write("| ");
                //i++;
            }
            Console.WriteLine();
            //Console.WriteLine("Done, press Enter to exit.");
        }
        public void MyProgressBar(bool stopThread)
        {
            Console.Write("Working... ");
            Console.Write("{0,3:##0}%", 0);
            for (int i = 0; i < 100; i++)
            {
                //Console.Write(new String('c', 4));//'Backspace x 4  
                System.Threading.Thread.Sleep(100);
                //Console.Write("{0,3:##0}%", i);
                Console.Write("| ");
            }
            Console.WriteLine();
            //Console.WriteLine("Done, press Enter to exit.");
        }
    }
}
