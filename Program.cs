using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

/* PixelTest
 *   Fun little program to play with pixels
 *   Creates an Ulam's Spiral with randomly colored primes
 *     Note: Code is still somewhat sloppy but it's an improvement dammit
 * Written by Nathan McGinn
 *   Last Modified 07/15/2013
 */

namespace PixelTest
{
    class Program
    {
        // Class variables (to make less argument-intensive method calls)
        static int width = 801, height = 801;
        static int pixelY = 400, pixelX = 400; // half of width,height; should be truncated to lower value
        static int pixelNum = 1, movement = 1;
        static Random r = new Random();

        // Main - Program Entry Point
        static void Main(string[] args)
        {
            bool toright = true;
            string path = @"C:\Users\Derek\Desktop\primes.png";

            Bitmap bmp = new Bitmap(width, height);
            Console.WriteLine("Starting calculations...");

            // make sure 1 is filled in
            bmp.SetPixel(pixelX, pixelY, Color.White);

            // begin the primary loop
            while (movement < width && movement < height)
            {
                // right and up movement
                if (toright)
                {
                    MovePixels(Dir.Right, ref bmp);
                    MovePixels(Dir.Up, ref bmp);
                }
                // left and down movement
                else
                {
                    MovePixels(Dir.Left, ref bmp);
                    MovePixels(Dir.Down, ref bmp);
                }
                movement++;
                toright = !toright;
            }

            // need to make sure we get the bottom row on completion
            movement--;
            MovePixels(Dir.Right, ref bmp);

            Console.WriteLine("Calculations complete...");

            // the bitmap has been created, save & dispose of it
            bmp.Save(path, ImageFormat.Png);
            bmp.Dispose();

            Console.WriteLine("Image saved, press enter key to close...");
            Console.ReadLine();
        }

        // MovePixels draws in prime pixels in 1 direction
        static void MovePixels(Dir direction, ref Bitmap bmp)
        {
            for (int i = 1; i <= movement; i++)
            {
                // handle direction-specific tasks (movement)
                switch (direction)
                {
                    case Dir.Down:
                        pixelNum++;
                        pixelY++;
                        break;
                    case Dir.Up:
                        pixelNum++;
                        pixelY--;
                        break;
                    case Dir.Left:
                        pixelNum++;
                        pixelX--;
                        break;
                    case Dir.Right:
                        pixelNum++;
                        pixelX++;
                        break;
                    default:
                        break;
                }
                // handle universal tasks (pixel coloration)
                if (IsPrime(pixelNum))
                {
                    int red = r.Next(0, 225);
                    int green = r.Next(0, 225);
                    int blue = r.Next(0, 225);
                    bmp.SetPixel(pixelX, pixelY, Color.FromArgb(red, green, blue));
                }
                else
                {
                    bmp.SetPixel(pixelX, pixelY, Color.White);
                }
            }
        }

        // returns true if prime, false if composite
        static bool IsPrime(int x)
        {
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }
            if (x > 1) return true;
            return false;
        }

        // Enum to control MovePixels direction
        enum Dir
        {
            Up, Down, Left, Right
        }
    }
}
