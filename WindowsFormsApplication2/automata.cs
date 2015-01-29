using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsFormsApplication2
{
    public class Automata
    {

        public int width = 0, height = 0;
        public int[,] field;
        private string[] names = new string[16]   {"AliceBlue", "Aquamarine", "DarkOrange", "Gainsboro", "Gray", "GreenYellow", "LightPink", "Magenta", 
           "Purple", "Violet","Tomato", "SeaShell","Red", "Plum","Orchid", "MistyRose"};
        public Graphics graphics;
        public Bitmap myBitmap;

        public void setDrawingArea(Control area)
        {
            graphics = area.CreateGraphics();
        }

        public void setWidth(Control control)
        {
            width = control.Width;
        }

        public void setHeight(Control control)
        {
            height = control.Height;
        }

        public void setBackground(Control control, Graphics graphics)
        {
            myBitmap = new Bitmap(width, height);
            Random r = new Random();
            field = new int[height, width];
            for (int Xcount = 0; Xcount < myBitmap.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < myBitmap.Height; Ycount++)
                {
                    field[Ycount, Xcount] = r.Next(16);
                    myBitmap.SetPixel(Xcount, Ycount, Color.FromName(names[field[Ycount, Xcount]]));
                }
            }
            graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width,
                 myBitmap.Height); 

        }

        public void changeState(int number)
        {
            for (int i = 0; i < number; i++)
            {
                int[,] newRow = new int[height, width];
                for (int y = 0; y < myBitmap.Height; y++)
                {
                    for (int x = 0; x < myBitmap.Width; x++)
                    {
                        int newState = (field[y, x] + 1) % names.Length;
                        if (
                            (field[(y + myBitmap.Height - 1) % myBitmap.Height, x] == newState) ||
                            (field[(y + 1) % myBitmap.Height, x] == newState) ||
                            (field[y, (x + myBitmap.Width - 1) % myBitmap.Width] == newState) ||
                            (field[y, (x + 1) % myBitmap.Width] == newState)
                        )
                        {
                            newRow[y, x] = newState;
                        }
                        else
                        {
                            newRow[y, x] = field[y, x];
                        }
                    }
                }
                field = newRow;
                for (int Xcount = 0; Xcount < myBitmap.Width; Xcount++)
                {
                    for (int Ycount = 0; Ycount < myBitmap.Height; Ycount++)
                    {
                        myBitmap.SetPixel(Xcount, Ycount, Color.FromName(names[field[Ycount, Xcount]]));
                    }
                }
                graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width,
                      myBitmap.Height);
            }
        }

    }
}
