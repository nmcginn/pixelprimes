using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

/* PixelTest
 *   Fun little program to play with pixels
 *   Writes randomly colored pixel if prime, white if composite
 * Written by Nathan McGinn
 *   Last Modified 07/12/2013
 */

namespace PixelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 800;
            int height = 800;
            string path = @"C:\Users\Derek\Desktop\primes.png";
#if DEBUG
            int verify = 0;
#endif

            using (Bitmap bmp = new Bitmap(width, height))
            {
                Console.WriteLine("Starting calculations...");
                Random r = new Random();

                // for every pixel in the new bitmap
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        // set primes to black, composite numbers to white
                        if (IsPrime(i*width + j))
                        {
                            // 225 instead of 255 to avoid colors too close to white
                            int red = r.Next(0,225);
                            int green = r.Next(0,225);
                            int blue = r.Next(0,225);
                            bmp.SetPixel(j, i, Color.FromArgb(red,green,blue));
#if DEBUG
                            if (verify < 10) { Console.WriteLine(i * width + j); verify++; }
#endif
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
