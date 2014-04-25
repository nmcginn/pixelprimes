using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelprimes
{
    partial class Program
    {
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
                    pixelY = height / 2;
                    pixelX = (int)Math.Ceiling(width / 2.0) - 1;
                    break;
                // case 2 assumes width/height and path
                case 2:
                    width = Int32.Parse(args[0]);
                    height = width;
                    pixelY = height / 2;
                    pixelX = (int)Math.Ceiling(width / 2.0) - 1;
                    // full path provided
                    if (Path.IsPathRooted(args[1])) path = Path.GetFullPath(args[1]);
                    // partial path provided, assume C: as root
                    else path = Path.GetFullPath(@"C:\" + args[1]);
                    // add the filename if the user didn't provide it
                    if (!path.EndsWith(".png")) path += @"\primes.png";
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
            if (width % 2 == 1) MovePixels(Dir.Right, ref bmp);
            else MovePixels(Dir.Left, ref bmp);

            Console.WriteLine("Calculations complete...");

            // the bitmap has been created, save & dispose of it
            bmp.Save(path, ImageFormat.Png);
            bmp.Dispose();

            Console.WriteLine("Image saved, press enter key to close...");
            Console.ReadKey();
        }
    }
}
