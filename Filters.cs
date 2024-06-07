using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computer_graphics_lab1
{
    public class Inversion 
    {
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage);
            for (int x = 0; x < sourceImage.Width; x++)
            {
                for( int y = 0; y < sourceImage.Height; y++)
                {
                    Color colorPixel = filteredImage.GetPixel(x, y);
                    colorPixel = Color.FromArgb(255 - colorPixel.R, 255 - colorPixel.G, 255 - colorPixel.B);
                    filteredImage.SetPixel(x, y, colorPixel);
                }
            }
        return filteredImage;
        }
    }

    public class Grayscale 
    { 
        public static Bitmap Execute(Bitmap sourceImage) 
        {
            Bitmap filteredImage = new Bitmap(sourceImage);
            for (int x = 0; x < sourceImage.Width; x++)
            {
                for( int y = 0; y < sourceImage.Height; y++)
                {
                    Color colorPixel = filteredImage.GetPixel(x, y);
                    byte grayscale = (byte)(0.299 * colorPixel.R + 0.587 * colorPixel.G + 0.114 * colorPixel.B);
                    filteredImage.SetPixel(x, y, Color.FromArgb(grayscale, grayscale, grayscale));
                }
            }
        return filteredImage;
        }
    }

    public class Sepia
    {
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color pixelColor = filteredImage.GetPixel(i, j);
                    byte intensity = (byte)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                    int scale = 20;
                    int sepiaR = intensity + 2 * scale;
                    int sepiaG = intensity + (int)(0.5 * scale);
                    int sepiaB = intensity - scale;
                    sepiaR = Math.Min(sepiaR, 255);
                    sepiaG = Math.Min(sepiaG, 255);
                    sepiaB = Math.Min(sepiaB, 255);
                    sepiaR = Math.Max(sepiaR, 0);
                    sepiaG = Math.Max(sepiaG, 0);
                    sepiaB = Math.Max(sepiaB, 0);
                    Color sepiaPixel = Color.FromArgb(sepiaR, sepiaG, sepiaB);
                    filteredImage.SetPixel(i, j, sepiaPixel);
                }
            }
            return filteredImage;
        }
    }

    public class BrightnessUp
    {
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage);
            for (int x = 0; x < sourceImage.Width; x++)
            {
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color pixelColor = sourceImage.GetPixel(x, y);
                    int newRed = pixelColor.R + 20;
                    int newGreen = pixelColor.G + 20;
                    int newBlue = pixelColor.B + 20;
                    newRed = Math.Min(newRed, 255);
                    newGreen = Math.Min(newGreen, 255);
                    newBlue = Math.Min(newBlue, 255);
                    Color newPixel = Color.FromArgb(newRed, newGreen, newBlue);
                    filteredImage.SetPixel(x, y, newPixel);
                }
            }
            return filteredImage;
        }
    }

    public class Shift
    {
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int x = 0; x < sourceImage.Width; x++)
            {
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    int newX = x + 50;
                    if (newX < sourceImage.Width)
                    {
                        Color pixel = sourceImage.GetPixel(x, y);
                        filteredImage.SetPixel(newX, y, pixel);
                    }
                }
            }
            return filteredImage;
        }
    }

    public class Embossing
    {
        public static int[,] kernel = { 
            { 0, 1, 0 }, 
            { -1, 0, 1 }, 
            { 0, -1, 0 } 
        };
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap sv = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int radiusX = kernel.GetLength(0) / 2;
                    int radiusY = kernel.GetLength(1) / 2;
                    float resultR = 0; float resultG = 0; float resultB = 0;
                    for (int l = -radiusY; l <= radiusY; l++)
                    {
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idx = Math.Min(Math.Max(i + k, 0), sourceImage.Width - 1);
                            int idy = Math.Min(Math.Max(j + l, 0), sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idx, idy);
                            resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                            resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                            resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                        }
                    }
                    sv.SetPixel(i, j, Color.FromArgb(Math.Min(Math.Max((int)resultR, 0), 255), Math.Min(Math.Max((int)resultG, 0), 255), Math.Min(Math.Max((int)resultB, 0), 255)));
                }
            }
            for (int i = 0; i < sv.Width; i++)
            {
                for (int j = 0; j < sv.Height; j++)
                {
                    Color c = sv.GetPixel(i, j);
                    byte gray = (byte)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
                    sv.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            for (int i = 0; i < sv.Width; i++)
            {
                for (int j = 0; j < sv.Height; j++)
                {
                    Color c = sv.GetPixel(i, j);
                    filteredImage.SetPixel(i, j, Color.FromArgb(Math.Min(Math.Max(c.R + 100, 0), 255), Math.Min(Math.Max(c.G + 100, 0), 255), Math.Min(Math.Max(c.B + 100, 0), 255)));
                }
            }
            return filteredImage;
        }
    }

    public class MotionBlur
    {
        public static float[,] kernel =
        {
                { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1 }
            };
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            int kernelSize = 9;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int radiusX = kernel.GetLength(0) / 2;
                    int radiusY = kernel.GetLength(1) / 2;
                    float resultR = 0; float resultG = 0; float resultB = 0;
                    for (int l = -radiusY; l <= radiusY; l++)
                    {
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idx = Math.Min(Math.Max(i + k, 0), sourceImage.Width - 1);
                            int idy = Math.Min(Math.Max(j + l, 0), sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idx, idy);
                            resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                            resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                            resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                        }
                    }
                    filteredImage.SetPixel(i, j, Color.FromArgb(Math.Min(Math.Max((int)(resultR/(float)kernelSize), 0), 255), Math.Min(Math.Max((int)(resultG/(float)kernelSize), 0), 255), Math.Min(Math.Max((int)(resultB/(float)kernelSize), 0), 255)));
                }
            }

            return filteredImage;
        }
    }

    public class GrayWorld
    {
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            double avgR = 0;
            double avgG = 0;
            double avgB = 0;
            int N = sourceImage.Height * sourceImage.Width;
            Color color;
            for (int x = 0; x < sourceImage.Width; x++)
            {
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    color = sourceImage.GetPixel(x, y);
                    avgR += color.R;
                    avgG += color.G;
                    avgB += color.B;
                }
            }
            avgR = avgR / N;
            avgG = avgG / N;
            avgB = avgB / N;
            double AVG = (avgR + avgG + avgB) / 3;
            int resultR;
            int resultG;
            int resultB;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultR = (int)(sourceImage.GetPixel(i, j).R * (AVG / avgR));
                    resultG = (int)(sourceImage.GetPixel(i, j).G * (AVG / avgG));
                    resultB = (int)(sourceImage.GetPixel(i, j).B * (AVG / avgB));
                    resultR = Math.Min(resultR, 255);
                    resultG = Math.Min(resultG, 255);
                    resultB = Math.Min(resultB, 255);
                    filteredImage.SetPixel(i, j, Color.FromArgb(resultR, resultG, resultB));
                }
            }

            return filteredImage;
        }
    }

    public class Autolevels 
    {
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            int Rmin = 255, Gmin = 255, Bmin = 255;
            int Rmax = 0, Gmax = 0, Bmax = 0;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color pixel = sourceImage.GetPixel(i, j);
                    Rmin = Math.Min(Rmin, pixel.R);
                    Gmin = Math.Min(Gmin, pixel.G);
                    Bmin = Math.Min(Bmin, pixel.B);
                    Rmax = Math.Max(Rmax, pixel.R);
                    Gmax = Math.Max(Gmax, pixel.G);
                    Bmax = Math.Max(Bmax, pixel.B);
                }
            }

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color pixel = sourceImage.GetPixel(i, j);
                    int newR = (pixel.R - Rmin) * 255 / (Rmax - Rmin);
                    int newG = (pixel.G - Gmin) * 255 / (Gmax - Gmin);
                    int newB = (pixel.B - Bmin) * 255 / (Bmax - Bmin);
                    newR = Math.Max(0, Math.Min(255, newR));
                    newG = Math.Max(0, Math.Min(255, newG));
                    newB = Math.Max(0, Math.Min(255, newB));
                    Color newPixel = Color.FromArgb(newR, newG, newB);
                    filteredImage.SetPixel(i, j, newPixel);
                }
            }

            return filteredImage;
        }
    }

    public class PerfectReflector
    {
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            int maxR = 0;
            int maxG = 0;
            int maxB = 0;

            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color pixel = sourceImage.GetPixel(x, y);
                    if (pixel.R > maxR)
                    {
                        maxR = pixel.R;
                    }
                    if (pixel.G > maxG)
                    {
                        maxG = pixel.G;
                    }
                    if (pixel.B > maxB)
                    {
                        maxB = pixel.B;
                    }
                }
            }

            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color pixel = sourceImage.GetPixel(x, y);
                    int newR = (int)((pixel.R * 255) / maxR);
                    int newG = (int)((pixel.G * 255) / maxG);
                    int newB = (int)((pixel.B * 255) / maxB);
                    Color newPixel = Color.FromArgb(newR, newG, newB);
                    filteredImage.SetPixel(x, y, newPixel);
                }
            }

            return filteredImage;
        }
    }

    public class Dilation 
    {
        public static bool[,] mask = {
            { false, true, false },
            { true, true, true },
            { false, true, false }
        };
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int x = 0; x < sourceImage.Width; x++)
            {
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    int max = 0;
                    Color pixelColor = sourceImage.GetPixel(x, y);
                    int radiusX = mask.GetLength(0) / 2;
                    int radiusY = mask.GetLength(1) / 2;
                    for (int i = -radiusX; i <= radiusX; i++)
                    {
                        for (int j = -radiusY; j <= radiusY; j++)
                        {
                            int idx = Math.Min(Math.Max(x + i, 0), sourceImage.Width - 1);
                            int idy = Math.Min(Math.Max(y + j, 0), sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idx, idy);
                            int intensity = (int)(0.299 * neighborColor.R + 0.587 * neighborColor.G + 0.114 * neighborColor.B);
                            if ((mask[i + radiusX, j + radiusY]) && intensity > max)
                            {
                                max = intensity;
                                pixelColor = neighborColor;
                            }
                        }
                    }
                    filteredImage.SetPixel(x, y, pixelColor);
                }
            }

            return filteredImage;
        }
    }

    public class Erosion
    {
        public static bool[,] mask = {
            { false, true, false },
            { true, true, true },
            { false, true, false }
        };
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for(int x = 0; x < sourceImage.Width; x++)
            {
                for(int y = 0; y < sourceImage.Height; y++)
                {
                    int min = 255;
                    Color pixelColor = sourceImage.GetPixel(x,y);
                    int radiusX = mask.GetLength(0) / 2;
                    int radiusY = mask.GetLength(1) / 2;
                    for(int i = -radiusX; i<= radiusX; i++)
                    {
                        for(int j = -radiusY;j <= radiusY; j++)
                        {
                            int idx = Math.Min(Math.Max(x + i, 0), sourceImage.Width - 1);
                            int idy = Math.Min(Math.Max(y + j, 0), sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idx, idy);
                            int intensity = (int)(0.299*neighborColor.R + 0.587*neighborColor.G + 0.114*neighborColor.B);
                            if ((mask[i+radiusX, j+radiusY])&&intensity < min) 
                            {
                                min = intensity;
                                pixelColor = neighborColor;
                            }
                        }
                    }
                    filteredImage.SetPixel(x, y, pixelColor);
                }
            }
            
            return filteredImage;
        }
    }

    public class Median
    {
        public const int size = 9;
        public static int average;
        public static int[] newAverage;
        public static int sort(int[] array, int l, int r)
        {
            int x = array[l + (r - l) / 2], i = l, j = r, temp;
            while(i <= j)
            {
                while (array[i] < x)
                    i++;
                while (array[j] > x)
                    j--;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                sort(array, i, r);
            if(j > l)
                sort(array, l, j);
            return array[l+(r-l) / 2];
        }
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for(int x = 0; x <sourceImage.Width; x++)
            {
                for(int y = 0; y <sourceImage.Height; y++)
                {
                    newAverage = new int[size];
                    int k = 0, radius = 1;
                    for(int i = -radius; i <= radius; i++)
                    {
                        for(int j = -radius; j<= radius; j++)
                        {
                            Color currentColor = sourceImage.GetPixel(Math.Min(Math.Max(x + i, 0), sourceImage.Width - 1), Math.Min(Math.Max(y + j, 0), sourceImage.Height - 1));
                            newAverage[k++] =(currentColor.R + currentColor.G + currentColor.B)/3;
                        }
                    }
                    average = sort(newAverage, 0, size - 1);
                    Color pixelColor = Color.FromArgb(Math.Min(Math.Max(average, 0), 255), Math.Min(Math.Max(average, 0), 255), Math.Min(Math.Max(average, 0), 255));
                    filteredImage.SetPixel(x, y, pixelColor);
                }
            }
            return filteredImage;
        }
    }

    public class Sobel
    {
        public static int Clamp(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }
        public static int[,] Gx = {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };
        public static int[,] Gy = {
            { -1, -2, -1 },
            { 0, 0, 0 },
            { 1, 2, 1 }
        };
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int x = 0; x < sourceImage.Width; x++)
            {
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    int radiusX = 1;
                    int radiusY = 1;
                    float resultRX = 0; float resultGX = 0; float resultBX = 0;
                    float resultRY = 0; float resultGY = 0; float resultBY = 0;
                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                            Color neighbourColor = sourceImage.GetPixel(idX, idY);
                            resultRX += neighbourColor.R * Gx[k + radiusX, l + radiusY];
                            resultGX += neighbourColor.G * Gx[k + radiusX, l + radiusY];
                            resultBX += neighbourColor.B * Gx[k + radiusX, l + radiusY];
                            resultRY += neighbourColor.R * Gy[k + radiusX, l + radiusY];
                            resultGY += neighbourColor.G * Gy[k + radiusX, l + radiusY];
                            resultBY += neighbourColor.B * Gy[k + radiusX, l + radiusY];
                        }
                    int resultR = Clamp((int)Math.Sqrt(Math.Pow(resultRX, 2.0) + Math.Pow(resultRY, 2.0)), 0, 255);
                    int resultG = Clamp((int)Math.Sqrt(Math.Pow(resultGX, 2.0) + Math.Pow(resultGY, 2.0)), 0, 255);
                    int resultB = Clamp((int)Math.Sqrt(Math.Pow(resultBX, 2.0) + Math.Pow(resultBY, 2.0)), 0, 255);
                    Color pixelColor = Color.FromArgb(Clamp(resultR, 0, 255), Clamp(resultG, 0, 255), Clamp(resultB, 0, 255));
                    filteredImage.SetPixel(x, y, pixelColor);
                }
            }
            return filteredImage;
        }
    }

    public class Shcarr 
    {
        public static int Clamp(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }
        public static int[,] Gx = {
            { -3, 0, 3 },
            { -10, 0, 10 },
            { -3, 0, 3 }
        };
        public static int[,] Gy = {
            { -3, -10, -3 },
            { 0, 0, 0 },
            { 3, 10, 3 }
        };
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap filteredImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int x = 0; x < sourceImage.Width; x++)
            {
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    int radiusX = 1;
                    int radiusY = 1;
                    float resultRX = 0; float resultGX = 0; float resultBX = 0;
                    float resultRY = 0; float resultGY = 0; float resultBY = 0;
                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                            Color neighbourColor = sourceImage.GetPixel(idX, idY);
                            resultRX += neighbourColor.R * Gx[k + radiusX, l + radiusY];
                            resultGX += neighbourColor.G * Gx[k + radiusX, l + radiusY];
                            resultBX += neighbourColor.B * Gx[k + radiusX, l + radiusY];
                            resultRY += neighbourColor.R * Gy[k + radiusX, l + radiusY];
                            resultGY += neighbourColor.G * Gy[k + radiusX, l + radiusY];
                            resultBY += neighbourColor.B * Gy[k + radiusX, l + radiusY];
                        }
                    int resultR = Clamp((int)Math.Sqrt(Math.Pow(resultRX, 2.0) + Math.Pow(resultRY, 2.0)), 0, 255);
                    int resultG = Clamp((int)Math.Sqrt(Math.Pow(resultGX, 2.0) + Math.Pow(resultGY, 2.0)), 0, 255);
                    int resultB = Clamp((int)Math.Sqrt(Math.Pow(resultBX, 2.0) + Math.Pow(resultBY, 2.0)), 0, 255);
                    Color pixelColor = Color.FromArgb(Clamp(resultR, 0, 255), Clamp(resultG, 0, 255), Clamp(resultB, 0, 255));
                    filteredImage.SetPixel(x, y, pixelColor);
                }
            }
            return filteredImage;
        }
    }
}
