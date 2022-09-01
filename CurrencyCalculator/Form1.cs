using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CurrencyCalculator
{
    public partial class CurrencyCalculator : Form
    {
        public CurrencyCalculator()
        {
            InitializeComponent();
            LoadXML();
        }

        private void LoadXML()
        {
            txtHowMuch.Enabled = false;
            txtEnd.Enabled = false;
            listBox2.Visible = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("Currency.xml");
            int i = 0;

            foreach (XmlNode node in doc.GetElementsByTagName("Cube"))
            {

                if (i < 2)
                {
                    i++;
                }
                else
                {
                    listBox1.Items.Add(node.Attributes[0].Value);
                    listBox2.Items.Add(node.Attributes[1].Value);
                }
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            if (listBox1.SelectedIndex != -1)
            {
                txtValue.Text = Convert.ToString(listBox2.SelectedItem);
                if(txtHowMuch.Text != "")
                {
                    txtEnd.Text = Kalkulator.Calc((txtHowMuch.Text).Replace('.', ','), (txtValue.Text).Replace('.', ','));
                }
            }
            txtHowMuch.Enabled = true;
        }

        private void txtHowMuch_TextChanged(object sender, EventArgs e)
        {
            if (txtHowMuch.Text == "")
            {
                txtEnd.Text = "";
            }
            else
            {
                txtEnd.Text = Kalkulator.Calc((txtHowMuch.Text).Replace('.', ','), (txtValue.Text).Replace('.', ','));
            }

        }

        private void txtHowMuch_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex("^[A-Za-z]+$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}
