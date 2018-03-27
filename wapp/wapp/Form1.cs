using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace wapp
{
    public partial class Form1 : Form
    {
        NorthWindDAO _northWindDAO = new NorthWindDAO();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            _northWindDAO = await DoStuffAsync();
            label1.Text = "DB done";
        }
       
        private async Task<NorthWindDAO> DoStuffAsync()
        {
            return await Task.Run<NorthWindDAO>(() =>
            {
                return LoadDBTables();
            });
        }
        private NorthWindDAO LoadDBTables()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand { Connection = connection, CommandType = CommandType.StoredProcedure, CommandText = "[dbo].NorthwindDB" };
            SqlDataAdapter da = new SqlDataAdapter { SelectCommand = command };
            DataSet ds = new DataSet();
            NorthWindDAO northWindDAO = new NorthWindDAO();

            connection.Open();
            da.Fill(ds);
            for (int i = 0; i < 13; i++)
            {
                switch (i)
                {
                    case 0:
                        northWindDAO._categorys = ds.Tables[i].DataTableToList<Category>();
                        break;
                    case 1:
                        northWindDAO._customerCustomerDemos = ds.Tables[i].DataTableToList<CustomerCustomerDemo>();
                        break;
                    case 2:
                        northWindDAO._customerDemographics = ds.Tables[i].DataTableToList<CustomerDemographic>();
                        break;
                    case 3:
                        northWindDAO._customers = ds.Tables[i].DataTableToList<Customer>();
                        break;
                    case 4:
                        northWindDAO._employees = ds.Tables[i].DataTableToList<Employee>();
                        break;
                    case 5:
                        northWindDAO._employeeTerritories = ds.Tables[i].DataTableToList<EmployeeTerritory>();

                        break;
                    case 6:
                        northWindDAO._order_Details = ds.Tables[i].DataTableToList<Order_Detail>();

                        break;
                    case 7:
                        northWindDAO._orders = ds.Tables[i].DataTableToList<Order>();

                        break;
                    case 8:
                        northWindDAO._products = ds.Tables[i].DataTableToList<Product>();

                        break;
                    case 9:
                        northWindDAO._regions = ds.Tables[i].DataTableToList<Region>();

                        break;
                    case 10:
                        northWindDAO._shippers = ds.Tables[i].DataTableToList<Shipper>();

                        break;
                    case 11:
                        northWindDAO._suppliers = ds.Tables[i].DataTableToList<Supplier>();
                        break;
                    case 12:
                        northWindDAO._territories = ds.Tables[i].DataTableToList<Territory>();
                        break;

                }


            }
            connection.Close();

            return northWindDAO;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text == "DB done")
            {
                var orderdets =( from o in _northWindDAO._order_Details where o.OrderID== 10248 select o );
              var   orderdet = (from od in _northWindDAO._order_Details join o in _northWindDAO._orders on od._OrderID equals o._OrderID where  o._OrderID == 10248
                             select new { o._OrderID, od._ProductID, od._UnitPrice });
            }
        }

      
    }
}
