﻿
using System;
using System.Windows.Forms;
using System.Diagnostics;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOil
{
    public partial class Form1 : Form
    {
        DataBase DB = new DataBase();
        public double Price { get; set; } = 0;
        public int CheckNumber { get; set; } = 0;
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
            double OilPrice;

            if (PayLbl.Text != string.Empty)
            {
                 OilPrice = double.Parse(PayLbl.Text);
            }
            else
            {
                OilPrice = 0;
            }
            double CafePrice;
            if (PayCafelbl.Text!=string.Empty)
            {
                CafePrice = double.Parse(PayCafelbl.Text);
            }
            else
            {
                CafePrice = 0;
            }
            var total = OilPrice + CafePrice;

            var num = total.ToString();

            TotalPriceLbl.Text = num;

            CreateGasolineObject();
            ++CheckNumber;
            string filename = "PaymentCheck" + CheckNumber.ToString() + ".pdf";

            PDF.CreatePDF(DB, filename,num);
        }

        public void CreateGasolineObject()
        {
            string qua;
            int quantity = 0;
            if (LiterTxtBox.Text != string.Empty)
            {
                qua = LiterTxtBox.Text;
                quantity = int.Parse(qua);
            }
            else if(MoneyTxtBox.Text != string.Empty)
            {
                double m = double.Parse(MoneyTxtBox.Text);
                double pr = double.Parse(priceTxtbox.Text);
                int result = (int)(m / pr);
                quantity = result;
            }

            string gasoline = gasolineCombobox.Text;
            Refueling gas = new Refueling
            {
                Gasoline = gasoline,
                Quantity = quantity,
                Price = double.Parse(priceTxtbox.Text),
                TotalPrice = int.Parse(PayLbl.Text),
            };
            DB.AddGasoline(gas);
        }

        public void CreateCafeObject(string eat,double price,int count,double Totalprice)
        {
            MiniCafe eatt = new MiniCafe
            {
                Eat = eat,
                Price = price,
                Count = count,
                TotalPrice=Totalprice,
            };
            DB.AddEats(eatt);
        }

        private void gasolineCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = gasolineCombobox.SelectedItem.ToString();

            if (item == "92")
            {
                priceTxtbox.Text = "1";
            }
            else if (item == "95") 
            {
                priceTxtbox.Text = "1.20";
            }
            else if (item == "Premium")
            {
                priceTxtbox.Text = "1.45";
            }


        }

        private void LitrRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            MoneyTxtBox.Text = string.Empty;
            PayLbl.Text = string.Empty;
            MoneyTxtBox.Enabled = false;
            LiterTxtBox.Enabled = true;
        }

        private void MoneyRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            LiterTxtBox.Text = string.Empty;
            PayLbl.Text = string.Empty;
            LiterTxtBox.Enabled = false;
            MoneyTxtBox.Enabled = true;
        }

       
        private void LiterTxtBox_TextChanged(object sender, EventArgs e)
        {
           
            if (System.Text.RegularExpressions.Regex.IsMatch(LiterTxtBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                LiterTxtBox.Text = LiterTxtBox.Text.Remove(LiterTxtBox.Text.Length - 1);               
            }
            else
            {
                Calculate1();
            }
           
        }
        public void Calculate1()
        {
            if (LiterTxtBox.Text != string.Empty && priceTxtbox.Text != string.Empty)
            {
                double price = double.Parse(priceTxtbox.Text);
                int l = int.Parse(LiterTxtBox.Text);

                PayLbl.Text = (price * l).ToString();
            }
        }

        private void MoneyTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(LiterTxtBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                LiterTxtBox.Text = LiterTxtBox.Text.Remove(LiterTxtBox.Text.Length - 1);
            }
            else
            {
                PayLbl.Text = MoneyTxtBox.Text;
            }
        }

        private void HotDogCountTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(HotDogCountTxtBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                HotDogCountTxtBox.Text = HotDogCountTxtBox.Text.Remove(HotDogCountTxtBox.Text.Length - 1);
            }
            else
            {
                if (HotDogCountTxtBox.Text != string.Empty)
                {
                    int count = int.Parse(HotDogCountTxtBox.Text);
                    double p = double.Parse(HotdogPriceTxtBox.Text);

                    Price += count * p;

                    PayCafelbl.Text = Price.ToString();

                    CreateCafeObject(checkBox1.Text, p, count, count * p);
                }
            }
        }

        private void HamburgercountTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(HamburgercountTxtBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                HamburgercountTxtBox.Text = HamburgercountTxtBox.Text.Remove(HamburgercountTxtBox.Text.Length - 1);
            }
            else
            {
                if (HamburgercountTxtBox.Text != string.Empty)
                {
                    int count = int.Parse(HamburgercountTxtBox.Text);
                    double p = double.Parse(HamburgerPriceTxtBox.Text);

                    Price += count * p;

                    PayCafelbl.Text = Price.ToString();
                    CreateCafeObject(checkBox3.Text, p, count, count * p);
                }
            }
        }

        private void FreeCountTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(FreeCountTxtBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                FreeCountTxtBox.Text = FreeCountTxtBox.Text.Remove(FreeCountTxtBox.Text.Length - 1);
            }
            else
            {
                if (FreeCountTxtBox.Text != string.Empty)
                {
                    int count = int.Parse(FreeCountTxtBox.Text);
                    double p = double.Parse(FreePriceTxtBox.Text);

                    Price += count * p;

                    PayCafelbl.Text = Price.ToString();
                    CreateCafeObject(checkBox2.Text, p, count, count * p);
                }
            }
        }

        private void ColaCountTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ColaCountTxtBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                ColaCountTxtBox.Text = ColaCountTxtBox.Text.Remove(ColaCountTxtBox.Text.Length - 1);
            }
            else
            {
                if (ColaCountTxtBox.Text != string.Empty)
                {
                    int count = int.Parse(ColaCountTxtBox.Text);
                    double p = double.Parse(ColaPriceTxtBox.Text);

                    Price += count * p;

                    PayCafelbl.Text = Price.ToString();
                    CreateCafeObject(checkBox4.Text, p, count, count * p);
                }
            }            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            HotDogCountTxtBox.Enabled = true;
            if (!checkBox1.Checked)
            {
                HotDogCountTxtBox.Text = string.Empty;
                HotDogCountTxtBox.Enabled = false;
                PayCafelbl.Text = string.Empty;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            HamburgercountTxtBox.Enabled = true;
           
            if (!checkBox3.Checked)
            {
                HamburgercountTxtBox.Text = string.Empty;
                HamburgercountTxtBox.Enabled = false;
                PayCafelbl.Text = string.Empty;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            FreeCountTxtBox.Enabled = true;

            if (!checkBox2.Checked)
            {
                FreeCountTxtBox.Text = string.Empty;
                FreeCountTxtBox.Enabled = false;
                PayCafelbl.Text = string.Empty;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ColaCountTxtBox.Enabled = true;
            if (!checkBox4.Checked)
            {
                ColaCountTxtBox.Text = string.Empty;
                ColaCountTxtBox.Enabled = false;
                PayCafelbl.Text = string.Empty;
            }
        }
    }
}
