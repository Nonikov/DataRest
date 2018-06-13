using System;
using System.Threading;
using System.Windows.Forms;
using DalRest;

namespace wfRestaurant
{
    public partial class Restaurant : Form
    {
        Facade facade;
        public Restaurant()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            facade = new Facade();
            dataGridView1.DataSource = facade.GetMeasureType();
            dataGridView2.DataSource = facade.GetProductTypes();
            dataGridView3.DataSource = facade.GetProducts();
            dataGridView4.DataSource = facade.GetDishes();
            dataGridView5.DataSource = facade.GetRecipes();
            dataGridView6.DataSource = facade.GetConsumptiones();
            dataGridView7.DataSource = facade.GetPurchases();
            dataGridView8.DataSource = facade.GetSales();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {

            facade = new Facade();
            try
            {
                facade.AddMeasureType(textBox1.Text);
                lb_error.Visible = false;
            }
            catch (Exception)
            {
                lb_error.Visible = true;
            }
            if (lb_error.Visible != true)
            {
                textBox1.Text = "";
                dataGridView1.DataSource = facade.GetMeasureType();
            }
        }

        private void buttonProd_Click(object sender, EventArgs e)
        {
            facade = new Facade();
            try
            {
                facade.AddProductTypes(textBoxProdT.Text);
                lb_error.Visible = false;
            }
            catch (Exception)
            {
                lb_error.Visible = true;
            }
            if (lb_error.Visible != true)
            {
                textBoxProdT.Text = "";
                dataGridView2.DataSource = facade.GetProductTypes();
            }
        }

        private void buttPodType_Click(object sender, EventArgs e)
        {
            facade = new Facade();
            try
            {
                facade.AddProduct(textBoxP_p.Text, textBoxP_pt.Text, textBoxP_mt.Text);
                lb_error.Visible = false;
            }
            catch (Exception)
            {
                lb_error.Visible = true;
            }
            if (lb_error.Visible != true)
            {
                textBoxP_p.Text = "";
                textBoxP_pt.Text = "";
                textBoxP_mt.Text = "";
                dataGridView3.DataSource = facade.GetProducts();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            facade = new Facade();
            try
            {
                facade.AddDishe(textBox5.Text, textBox3.Text);
                lb_error.Visible = false;
            }
            catch (Exception)
            {
                lb_error.Visible = true;
            }
            if (lb_error.Visible != true)
            {
                textBox5.Text = "";
                textBox3.Text = "";
                dataGridView4.DataSource = facade.GetDishes();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            facade = new Facade();
            try
            {
                facade.AddRecipe(textBox4.Text, textBox2.Text);
                dataGridView4.DataSource = facade.GetDishes();
                lb_error.Visible = false;
            }
            catch (Exception)
            {
                lb_error.Visible = true;
            }
            if (lb_error.Visible != true)
            {
                textBox4.Text = "";
                textBox2.Text = "";
                dataGridView5.DataSource = facade.GetRecipes();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            facade = new Facade();
            try
            {
                facade.AddConsumption(textBox8.Text, textBox7.Text, Convert.ToSingle(textBox6.Text));
                lb_error.Visible = false;
            }
            catch (Exception)
            {
                lb_error.Visible = true;
            }
            if (lb_error.Visible != true)
            {
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                dataGridView6.DataSource = facade.GetConsumptiones();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            facade = new Facade();
            try
            {
                facade.AddPurchase(textBox11.Text, Convert.ToDecimal(textBox10.Text), Convert.ToInt32(textBox9.Text));
                lb_error.Visible = false;
            }
            catch (Exception)
            {
                lb_error.Visible = true;
            }
            if (lb_error.Visible != true)
            {
                textBox11.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
                dataGridView7.DataSource = facade.GetPurchases();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            facade = new Facade();
            try
            {
                facade.AddSale(textBox14.Text, Convert.ToDecimal(textBox13.Text), Convert.ToInt32(textBox12.Text));
                lb_error.Visible = false;
            }
            catch (Exception)
            {
                lb_error.Visible = true;
            }
            if (lb_error.Visible != true)
            {
                textBox14.Text = "";
                textBox13.Text = "";
                textBox12.Text = "";
                dataGridView8.DataSource = facade.GetSales();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            facade = new Facade();
            facade.DropAllTables();

            facade = new Facade();
            dataGridView1.DataSource = facade.GetMeasureType();
            dataGridView2.DataSource = facade.GetProductTypes();
            dataGridView3.DataSource = facade.GetProducts();
            dataGridView4.DataSource = facade.GetDishes();
            dataGridView5.DataSource = facade.GetRecipes();
            dataGridView6.DataSource = facade.GetConsumptiones();
            dataGridView7.DataSource = facade.GetPurchases();
            dataGridView8.DataSource = facade.GetSales();
        }
    }
}
