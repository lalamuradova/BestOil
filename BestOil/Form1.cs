using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CalculateBtn.BackColor = Color.FromArgb(170, 172, 110);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(170, 172, 110);
           
            this.ForeColor = Color.FromArgb(222, 38, 28);
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            
            
        }

        
    }
}
