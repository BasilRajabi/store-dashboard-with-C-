using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSprojectP3
{
    //Person person1 = new Person();
    //
    public partial class Form1 : Form
    {
        
        Mycontext ctx = new Mycontext();
        string admin = "a";
        string password = "a";
        
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (textBox1.Text == admin && textBox2.Text == password)
                form2.Show();
            else MessageBox.Show("incorrect");

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                int customertest;
                //Form5 form5 = new Form5();
                string d1 = textBox1.Text;
                Customer d2 = ctx.Customers.Where(y => y.username == d1).Single();
                if (d2.password == textBox2.Text)
                {
                    customertest = d2.ID;
                    Form5 form5 = new Form5($"{customertest}");
                    form5.Show();
                    
                }
                else MessageBox.Show("username or password is incorrect");
            }
            catch 
            {
                MessageBox.Show("Account does not exist"); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            dataGridView1.DataSource = ctx.Customers.ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
