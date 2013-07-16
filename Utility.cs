using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* PixelTest Helper Methods
 *   Called from the main program
 * Written by Nathan McGinn
 *   Last Modified 07/16/2013
 */

namespace PixelTest
{
    partial class Program
    {
        // Class variables (to make less argument-intensive method calls)
        static int width = 801, height = 801;
        static int pixelY = 400, pixelX = 400; // half of width,height; should be truncated to lower value
        static int pixelNum = 1, movement = 1;
        static string path = @"C:\Users\Derek\Desktop\primes.png";
        static Random r = new Random();

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
    }

    // Enum to control MovePixels direction
    enum Dir
    {
        Up, Down, Left, Right
    }
}
