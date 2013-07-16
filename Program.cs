using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.IO;

/* PixelTest
 *   Fun little program to play with pixels
 *   Creates an Ulam's Spiral with randomly colored primes
 *     Note: Code is still somewhat sloppy but it's an improvement dammit
 * Written by Nathan McGinn
 *   Last Modified 07/16/2013
 */

namespace PixelTest
{
    partial class Program
    {
        // Main - Program Entry Point
        static void Main(string[] args)
        {
            // check to see if arguments have been passed in
            switch (args.Length)
            {
                case 0:
                    break;
                // case 1 assumes width/height was the variable passed in
                case 1:
                    width = Int32.Parse(args[0]);
                    height = width;
                    pixelX = width / 2;
                    pixelY = height / 2;
                    break;
                // case 2 assumes width/height and path
                case 2:
                    width = Int32.Parse(args[0]);
                    height = width;
                    pixelX = width / 2;
                    pixelY = height / 2;
                    path = Path.GetFullPath(args[1]);
                    break;
                default:
                    break;
            }

            // set up the required variables
            bool toright = true;
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
    }
}
