using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelprimes
{
    partial class Program
    {
        // Class variables (to make less argument-intensive method calls)
        static int width = 400, height = 400;
        // For even width/height, X needs to be 1 less than half
        // For odd width/height, integer division is sufficient (half floored)
        static int pixelY = 200, pixelX = 199;
        static int pixelNum = 1, movement = 1;
        static string path = Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEPATH%"), "Desktop", "primes.png");
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
