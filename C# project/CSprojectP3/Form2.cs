using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSprojectP3
{
    public partial class Form2 : Form
    {
        Mycontext ctx = new Mycontext();
        //public List<string> printall(Order x , int i)
        public void printall(Order x, int i)

        {
          //  float Tcost = x.calfinalcost();
            string b = $"Order No. {i}";
            List<string> a = new List<string>();
            a.Add(b);
            a.Add( "ID " + x.ID.ToString());
           // a.Add(" name" + x.Customer.username.ToString());
            a.Add("date " + x.Date1.ToString());
            a.Add("status" +x.status.ToString());
            //  //  a.Add((Tcost).ToString());
            //dataGridView1.DataSource = a.ToList();
           // textBox4.Text = a;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product x = new Product();
            x.Name = textBox1.Text;
            x.Price = Convert.ToInt32(textBox2.Text);
            x.Inventory_Level = Convert.ToInt32(textBox3.Text);
            ctx.Products.Add(x);
            ctx.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Order x in ctx.Orders)
                x.status = OrderStatus.delivered;
            ctx.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = ctx.Customers.Select(x => x.username).ToList();
            dataGridView1.DataSource = ctx.Orders.ToList();

            //listBox1.DataSource = ctx.Customers.Where(x => x.ID == 1).Select(c => c.OrderList.Select(v => v.Date1.DayOfWeek.ToString())).ToList();


            // dataGridView1.DataSource = ctx.Orders.ToList();

            // richTextBox1.Text =$"Order No. 1: \nOrderID: {ctx.Orders.Select(x => x.ID ==i).Single()} Customer name: {ctx.Customers.Select(a => a.ID == i).Single()} ";

            // int i = 1;
            // ICollection<Order> a = new ICollection<Order>();
            //   a = ctx.Customers.
            //printall(a, i);
            //  textBox4.Text = a.calfinalcost().ToString();
            //string[] a = new string[50];
            //List<string> b = new List<string>();
            //b.Add("dkdld");
            //b.Add("kjdnd");
            //textBox4.Text = b.ToString();

            // int i = 0;

            //foreach (Order a in ctx.Orders )
            // {
            //List<Order> b = new List<Order>();
            //b = ctx.Orders.ToList();
            //foreach (Order a in b)
            //{
            //    printall(a, i);
            //    i++;
            //}
            //}
            //  Order x = new Order();
            // x = ctx.Orders.Where(a => a.ID = 1).Single();
            // dataGridView1.DataSource = x;

            // int i = 0;
            // if (ctx.Orders != null)
            // {
            //   foreach(Order a in ctx.Orders)
            //    {

            //Customer a = ctx.Customers.Where(a => a.ID ==1).Single();
            //string b = a.username;
            //richTextBox1.Text = b;
            ////dataGridView1.DataSource = b;
            //listBox1.DataSource =  b.Single();
            //listBox1.DataSource = a ;
            // richTextBox1.Text = $"Order No. {ctx.Orders.Select(a => a.Customer.username)} \n Order ID:  \nCustomer name:   \n Date:  \n Status:  ";
            //         i++;
            //    }
            //richTextBox1.Text = $"Order No.{i} \n Order ID: {a.ID} \nCustomer name: {a.Customer.username} \n Date: {a.Date1} \n Status: {a.status} ";

            // }
            //listBox1.DataSource = ctx.Orders.Select(a => a.Customer.username).ToList();
            //dataGridView1.DataSource = ctx.Orders.ToList();
            //Total cost: {a.Final_Cost}



        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource =ctx.Products.Where(a => a.Inventory_Level == 0).Select(x => x.Name).ToList() ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Company a = new Company();
            int i = 0;
            foreach (Customer x in ctx.Customers)
                if (x.GetType() == a.GetType()) i++;
            MessageBox.Show("No. of companies:" + i);

        }
    }
}
