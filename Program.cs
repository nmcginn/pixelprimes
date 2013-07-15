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
 *     Note: Crazy hard to follow code, recommend refactoring
 * Written by Nathan McGinn
 *   Last Modified 07/14/2013
 */

namespace PixelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 801;
            int height = 801;
            bool toright = true;
            string path = @"C:\Users\Derek\Desktop\primes.png";

            using (Bitmap bmp = new Bitmap(width, height))
            {
                Console.WriteLine("Starting calculations...");

                // set up our needed variables
                Random r = new Random();
                int pixelY = height / 2;
                int pixelX = (width / 2);
                int pixelNum = 1;
                int movement = 1;

                // make sure 1 is filled in
                bmp.SetPixel(pixelX, pixelY, Color.White);

                // begin the primary loop
                while (movement < width && movement < height)
                {
                    // right and up movement
                    if (toright)
                    {
                        // iterate right
                        for (int i = 1; i <= movement; i++)
                        {
                            pixelNum++;
                            pixelX++;
                            if (IsPrime(pixelNum))
                            {
                                int red = r.Next(0, 225);
                                int green = r.Next(0, 225);
                                int blue = r.Next(0, 225);
                                bmp.SetPixel(pixelX,pixelY,Color.FromArgb(red,green,blue));
                            }
                            else
                            {
                                bmp.SetPixel(pixelX,pixelY,Color.White);
                            }
                        }
                        // iterate up
                        for (int i = 1; i <= movement; i++)
                        {
                            pixelNum++;
                            pixelY--;
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
                    // left and down movement
                    else
                    {
                        // iterate left
                        for (int i = 1; i <= movement; i++)
                        {
                            pixelNum++;
                            pixelX--;
                            if (IsPrime(pixelNum))
                            {
                                int red = r.Next(0, 225);
                                int green = r.Next(0, 225);
                                int blue = r.Next(0, 225);
                                bmp.SetPixel(pixelX,pixelY,Color.FromArgb(red,green,blue));
                            }
                            else
                            {
                                bmp.SetPixel(pixelX,pixelY,Color.White);
                            }
                        }
                        // iterate down
                        for (int i = 1; i <= movement; i++)
                        {
                            pixelNum++;
                            pixelY++;
                            if (IsPrime(pixelNum))
                            {
                                int red = r.Next(0, 225);
                                int green = r.Next(0, 225);
                                int blue = r.Next(0, 225);
                                bmp.SetPixel(pixelX,pixelY,Color.FromArgb(red,green,blue));
                            }
                            else
                            {
                                bmp.SetPixel(pixelX,pixelY,Color.White);
                            }
                        }
                    }
                    movement++;
                    toright = !toright;
                }// end outer loop
                // need to make sure we get the bottom row on completion
                movement--;
                for (int i = 1; i <= movement; i++)
                {
                    pixelNum++;
                    pixelX++;
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
