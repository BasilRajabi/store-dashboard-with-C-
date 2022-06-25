using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSprojectP3
{
    public partial class Form5 : Form
    {
        Mycontext ctx = new Mycontext();
        int test;
        string v;
        
        public Form5(string value)
        {
            InitializeComponent();
            dataGridView1.DataSource = ctx.Products.ToList();
            listBox1.DataSource = ctx.Products.Select(x => x.Name ).ToList();
            test = Int32.Parse(value);
            listBox2.DataSource = ctx.Orders.Select(x => x.ID).ToList();


        }

        private void Form5_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order o = new Order() {  status = OrderStatus.InProgress, Date1 = DateTime.Now, CustomerID = test };
            ctx.Orders.Add(o);
            ctx.SaveChanges();
            
            listBox2.DataSource = ctx.Orders.Select(x => x.ID ).ToList();
            


           // int i = listBox1.SelectedItem;

            //ctx.Orders.Where(x => x.status == OrderStatus.InProgress).Select(a => a.status == OrderStatus.Pending).Single();
            //foreach (Order x in ctx.Orders)
            //    x.status = OrderStatus.Pending;
            //ctx.SaveChanges();
            //////////////////////////////////////////////



            //Product p = new Product();
            //o.status = OrderStatus.InProgress;
            //o.Date1 = DateTime.Now;
            //o.CustomerID = test;

            

            //ctx.Orders.Where(x => x.ID == i).Single().TItems.Add(trans);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string test = listBox1.SelectedItem.ToString();
            float p = 0;
            textBox2.Text = listBox1.SelectedItem.ToString();
            p = ctx.Products.Where(x => x.Name == test).Select(b => b.Price).Single();
            textBox3.Text = p.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float w;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                w = 0;
             else w = Convert.ToInt32(textBox1.Text);
                 
            float q = Convert.ToSingle(textBox3.Text);
            richTextBox1.Text = $"Product: \t{textBox2.Text} \nPrice: \t\t {textBox3.Text} \nQuantity: \t {textBox1.Text } \nTotal cost: \t { (q * w).ToString()}";
                               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = ctx.Orders.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Order x in ctx.Orders)
                if (x.status == OrderStatus.InProgress)
                    x.status = OrderStatus.Pending;

                ctx.SaveChanges();
              
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             v = listBox2.SelectedItem.ToString();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Product P = new Product();
            P.Name = textBox2.Text;
            P.Price = Convert.ToInt32(textBox3.Text);
            
            TransactionItem trans = new TransactionItem();
            trans.quantity = Convert.ToInt32(textBox1.Text);
            trans.CostPerItem = Convert.ToSingle(textBox3.Text);
            var str = listBox1.SelectedItem;

            trans.ProductID = ctx.Products.Where(x => x.Name == str).Select(a => a.ID).Single();
            trans.OrderID = 1;
            //trans.Order.ID = Int32.Parse(v);
            ctx.Orders.First().TItems.Add(trans);
            //Where(z => z.ID == 1).Single().TItems.Add(trans);
            dataGridView2.DataSource = ctx.transactionItems.ToList();
            //MessageBox.Show(ctx.Products.Where(x => x.Name == str).Select(a => a.ID).Single().ToString());

       
        }
    }
}
