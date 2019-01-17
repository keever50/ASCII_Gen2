using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ASCII_Gen2
{

    class ImageGenerator
    {
        static string ColorToText( Color color )
        {
            int B = (int)((color.GetBrightness())*4);
            switch (B)
            {
                case 0:
                    return ".";
                case 1:
                    return ":";
                case 2:
                    return "3";
                case 3:
                    return "8";
                case 4:
                    return "#";
                default:
                    return "X";
            }   
        }

        static ConsoleColor ConsoleColorDecoder( Color color )
        {
            //Turns rgb into something between 0 and 2. Black, Grey, White
            int R = (int)Math.Floor(color.R / 127.5d);//127.5d
            int G = (int)Math.Floor(color.G / 127.5d);
            int B = (int)Math.Floor(color.B / 127.5d);

            //Red
            if (R == 2 & G == 0 & B == 0)
            {
                return ConsoleColor.Red;
            }
            else
            //Darkred
            if (R == 1 & G == 0 & B == 0)
            {
                return ConsoleColor.DarkRed;
            }
            else
            //Green
            if (R == 0 & G == 2 & B == 0)
            {
                return ConsoleColor.Green;
            }
            else
            //Dark green
            if (R == 0 & G == 1 & B == 0)
            {
                return ConsoleColor.DarkGreen;
            }
            else
            //Blue
            if (R == 0 & G == 0 & B == 2)
            {
                return ConsoleColor.Blue;
            }
            else
            //Dark blue
            if (R == 0 & G == 0 & B == 1)
            {
                return ConsoleColor.DarkBlue;
            }
            else

            //Yellow
            if (R == 2 & G == 2 & B == 0)
            {
                return ConsoleColor.Yellow;
            }
            else
            //DarkYellow
            if (R == 1 & G == 1 & B == 0)
            {
                return ConsoleColor.Yellow;
            }
            else
            //Magenta
            if (R == 2 & G == 0 & B == 2)
            {
                return ConsoleColor.Magenta;
            }
            else
            //Dark magenta
            if (R == 1 & G == 0 & B == 1)
            {
                return ConsoleColor.DarkMagenta;
            }
            else
            //Cyan
            if (R == 0 & G == 2 & B == 2)
            {
                return ConsoleColor.Cyan;
            }
            else
            //Dark cyan
            if (R == 2 & G == 0 & B == 0)
            {
                return ConsoleColor.DarkCyan;
            }
            else
            //Other combinations that arent possible.
            //Orange
            if (R == 2 & G == 1 & B == 0)
            {
                return ConsoleColor.DarkYellow;
            }
            else
            //Pink
            if (R == 2 & G == 0 & B == 1)
            {
                return ConsoleColor.DarkMagenta;
            }
            else
            //Lime
            if (R == 1 & G == 2 & B == 0)
            {
                return ConsoleColor.Green;
            }
            else
            //Toxic green ?
            if (R == 0 & G == 2 & B == 1)
            {
                return ConsoleColor.Green;
            }
            else
            //Purple
            if (R == 1 & G == 0 & B == 2)
            {
                return ConsoleColor.DarkMagenta;
            }
            else
            //Light blue - ish 
            if (R == 0 & G == 1 & B == 2)
            {
                return ConsoleColor.Cyan;
            }
            else

            //White
            if (R == 2 & G == 2 & B == 2)
            {
                return ConsoleColor.White;
            }
            else
            //Gray
            if (R == 1 & G == 1 & B == 1)
            {
                return ConsoleColor.Gray;
            }
            else
                return ConsoleColor.Black;
            
        }

        static void Put( int x, int y, string str)
        {
            if (x < Console.BufferWidth & y < Console.BufferHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(str);
            } 
        }

        public static int w = Console.LargestWindowWidth;
        public static int h = Console.LargestWindowHeight;
        
        static void Main(string[] args)
        {
            Console.SetBufferSize(w,h);
            Console.SetWindowSize(w,h);
            
            Console.WriteLine("Loading image...");
            Bitmap BM = new Bitmap(args[0]);

            Console.WriteLine("Dims: " + BM.Width + "x" + BM.Height);
            Console.WriteLine("Console: " + w + "x" + h);

            Console.WriteLine("Rendering");
            int Cx;
            int Cy;
            for (decimal y = 1; y < BM.Height; y=y+BM.Height/h)
            {
                Cy = (int)Math.Round((y / BM.Height) * h);
                for (decimal x = 1; x < BM.Width; x = x + BM.Width / w)
                {
                    Cx = (int)Math.Round((x / BM.Width) * w);
                    
                    Color color = BM.GetPixel((int)x, (int)y);
                    Console.BackgroundColor = ConsoleColorDecoder(color);//ConsoleColorDecoder(color);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Put(Cx, Cy, ColorToText(color));

                }
            }
            Console.Read();
        }
    }
}
