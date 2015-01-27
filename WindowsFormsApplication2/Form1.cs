using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        public Automata automata = new Automata();

        public Form1()
        {
            InitializeComponent();
            automata.setDrawingArea(drawPanel);
            automata.setHeight(drawPanel);
            automata.setWidth(drawPanel);
        }

        private void setRandom_Click(object sender, EventArgs e)
        {
            automata.setBackground(drawPanel, automata.graphics);
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            automata.changeState((int) numericUpDown1.Value);
        }
    }
}
