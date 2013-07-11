using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

/* PixelTest
 *   Fun little program to play with pixels
 *   Writes black pixel if prime, white if composite
 * Written by Nathan McGinn
 *   Last Modified 07/10/2013
 */

namespace PixelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 1600;
            int height = 1600;
            string path = @"C:\Users\Derek\Desktop\primes.png";

            using (Bitmap bmp = new Bitmap(width, height))
            {
                Console.WriteLine("Starting calculations...");

                int verify = 0;
                // for every pixel in the new bitmap
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        // set primes to black, composite numbers to white
                        if (IsPrime(i*width + j))
                        {
                            bmp.SetPixel(j, i, Color.Black);
                            if (verify < 10) { Console.WriteLine(i * width + j); verify++; }
                        }
                        else
                        {
                            bmp.SetPixel(j, i, Color.White);
                        }
                    }
                }

                Console.WriteLine("Calculations complete...");

                // the bitmap has been created, save it
                bmp.Save(path, ImageFormat.Png);

                Console.WriteLine("Image saved, press enter key to close...");
                Console.ReadLine();
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
}
