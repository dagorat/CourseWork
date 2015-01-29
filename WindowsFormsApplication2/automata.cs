using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApplication2
{
    public class Automata
    {

        public int width = 0, height = 0;
        public int[,] field;
        private Color[] colors = new Color[16]   {   
            Color.FromName("AliceBlue"), 
            Color.FromName("Aquamarine"), 
            Color.FromName("DarkOrange"), 
            Color.FromName("Gainsboro"), 
            Color.FromName("Gray"), 
            Color.FromName("GreenYellow"), 
            Color.FromName("LightPink"), 
            Color.FromName("Magenta"), 
            Color.FromName("Purple"), 
            Color.FromName("Violet"),
            Color.FromName("Tomato"), 
            Color.FromName("SeaShell"),
            Color.FromName("Red"), 
            Color.FromName("Plum"),
            Color.FromName("Orchid"), 
            Color.FromName("MistyRose")
        };

        public Graphics graphics;
        public Bitmap myBitmap;

        public void setDrawingArea(Control area)
        {
            area.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
                    myBitmap.SetPixel(Xcount, Ycount, colors[field[Ycount, Xcount]]);
                }
            }
            graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width,
                 myBitmap.Height); 

        }

        public void changeState(int number)
        {
            for (int i = 0; i < number; i++)
            {
                int width = myBitmap.Width;
                int height = myBitmap.Height;
                int[,] newRow = new int[height, width];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int newState = (field[y, x] + 1) % colors.Length;
                        if (
                            (field[(y + height - 1) % height, x] == newState) ||
                            (field[(y + 1) % height, x] == newState) ||
                            (field[y, (x + width - 1) % width] == newState) ||
                            (field[y, (x + 1) % width] == newState)
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
                for (int Xcount = 0; Xcount < width; Xcount++)
                {
                    for (int Ycount = 0; Ycount < height; Ycount++)
                    {
                        myBitmap.SetPixel(Xcount, Ycount, colors[field[Ycount, Xcount]]);
                    }
                }
                graphics.DrawImage(myBitmap, 0, 0, width,
                      height);
            }
        }

    }
}
