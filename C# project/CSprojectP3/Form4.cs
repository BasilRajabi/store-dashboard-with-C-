using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSprojectP3
{
    public partial class Form4 : Form
    {
        Mycontext ctx = new Mycontext();
        public Form4()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            if (radioButton1.Checked) panel2.Visible = true;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = false;
            if (radioButton2.Checked) panel3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User a = new User();
            a.username = textBox1.Text;
            a.password = textBox2.Text;
            if (radioButton3.Checked) a.sex = "Male";
            else if (radioButton4.Checked) a.sex = "Female";

            Company b = new Company();
            b.username = textBox1.Text;
            b.password = textBox2.Text;
            b.CompanyType = textBox4.Text;
            b.Location = textBox3.Text;

            if (radioButton1.Checked) ctx.Customers.Add(a);
            else if (radioButton2.Checked) ctx.Customers.Add(b);

            ctx.SaveChanges();

        }
    }
}
