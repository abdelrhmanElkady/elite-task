using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elite_task.main.template
{
    public partial class invoice_create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Save_Bill(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if(!(int.Parse(this.item1_quantity.Value) == 0))
                {
                    Save_item(this.item1_name.InnerHtml, int.Parse(this.item1_quantity.Value), decimal.Parse(this.item1_price.Value), connection);
                    this.item1_quantity.Value = "0";
                    this.item1_price.Value = "0";
                }
                if (!(int.Parse(this.item2_quantity.Value) == 0))
                {
                    Save_item(this.item2_name.InnerHtml, int.Parse(this.item2_quantity.Value), decimal.Parse(this.item2_price.Value), connection);
                    this.item2_quantity.Value = "0";
                    this.item2_price.Value = "0";
                }
                if (!(int.Parse(this.item3_quantity.Value) == 0))
                {
                    Save_item(this.item3_name.InnerHtml, int.Parse(this.item3_quantity.Value), decimal.Parse(this.item3_price.Value), connection);
                    this.item3_quantity.Value = "0";
                    this.item3_price.Value = "0";
                }
            }
        }

        protected void Save_item(string itemName, int quntity, decimal unitPrice, SqlConnection connection)
        {
            string query = "insert into bill (Item_name,Quntity,Unit_price,Total) values (@Item_name,@Quntity,@Unit_price,@Total)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(new SqlParameter("@Item_name", SqlDbType.NVarChar, 100)).Value = itemName;
                command.Parameters.Add(new SqlParameter("@Quntity", SqlDbType.Int)).Value = quntity;
                command.Parameters.Add(new SqlParameter("@Unit_price", SqlDbType.Decimal)).Value = unitPrice;
                command.Parameters.Add(new SqlParameter("@Total", SqlDbType.Decimal)).Value = quntity * unitPrice;
                command.ExecuteNonQuery();
            }

        }
    }
}