using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shopping_thing2
{
    public partial class ShoppingCartPage2 : System.Web.UI.Page
    {
        //declares a new list of products
        List<Product> list_product = new List<Product>();
        List<Product> list_productSelected = new List<Product>();

        /*calculates total for sidebar
         * retrieves info from database to display */

        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutLbl.Visible = false;

            double subTotal = CalculateTotal();
            double salesTax = .056;
            double taxTotal;
            double cartTotal;
            lbl_sTotal.Text = $"${subTotal:f2}";
            taxTotal = subTotal * salesTax;
            lbl_tax.Text = $"${taxTotal:f2}";
            cartTotal = taxTotal + subTotal;
            lbl_total.Text = $"${cartTotal:f2}";

            RetriveInfoFromDatabase();
            int buttonCount = 1;
            int labelCount = 1;

            for (int i = 0; i < list_product.Count; i++)
            {

                Image newButton = new Image();
                Label newLabel = new Label();

                newButton.ImageAlign = ImageAlign.TextTop;

                newButton.ID = "newButton" + buttonCount;
                newLabel.ID = "newLabel" + labelCount;
                newLabel.Text = $"Name: {list_product[i].ProductName} <br> Description: {list_product[i].ProductDescription} <br> Price: ${list_product[i].ProductPrice} <br><br><br><br><br><br> ";

                int int_productID = Convert.ToInt32(list_product[i].ProductID);

                //assigns image based on productID
                switch (int_productID)
                {
                    case 1000:
                        newButton.ImageUrl = "~/userDefinedImages/baseballBat.jpg";
                        break;
                    case 2000:
                        newButton.ImageUrl = "~/userDefinedImages/baseballHelmet.jpg";
                        break;
                    case 3000:
                        newButton.ImageUrl = "~/userDefinedImages/baseballCleats.jpg";
                        break;
                    case 4000:
                        newButton.ImageUrl = "~/userDefinedImages/baseBallGlove.jpg";
                        break;
                    case 5000:
                        newButton.ImageUrl = "~/userDefinedImages/baseball.jpg";
                        break;
                    case 1600:
                        newButton.ImageUrl = "~/userDefinedImages/footballPads.jpg";
                        break;
                    case 5600:
                        newButton.ImageUrl = "~/userDefinedImages/footballs.jpg";
                        break;
                    case 2600:
                        newButton.ImageUrl = "~/userDefinedImages/footballHelment.jpg";
                        break;
                    case 3600:
                        newButton.ImageUrl = "~/userDefinedImages/footballCleats.jpg";
                        break;
                    case 6600:
                        newButton.ImageUrl = "~/userDefinedImages/football Gloves.jpg";
                        break;
                    case 1300:
                        newButton.ImageUrl = "~/userDefinedImages/hockeyStick.jpg";
                        break;
                    case 2300:
                        newButton.ImageUrl = "~/userDefinedImages/HockeyHelmet.jpg";
                        break;
                    case 6300:
                        newButton.ImageUrl = "~/userDefinedImages/hockeyGloves.jpg";
                        break;
                    case 7300:
                        newButton.ImageUrl = "~/userDefinedImages/hockeyPuck.jpg";
                        break;
                    case 1100:
                        newButton.ImageUrl = "~/userDefinedImages/lacrossePads.jpg";
                        break;
                    case 4100:
                        newButton.ImageUrl = "~/userDefinedImages/lacrossegloves.jpg";
                        break;
                    case 3100:
                        newButton.ImageUrl = "~/userDefinedImages/lacrosseCleats.jpg";
                        break;
                    default:
                        break;
                }

                //some productIDs have dupe so used name instead
                switch (list_product[i].ProductName)
                {
                    case "Hockey Pads":
                        newButton.ImageUrl = "~/userDefinedImages/hockyPads.jpg";
                        break;
                    case "Lacrosse Stick":
                        newButton.ImageUrl = "~/userDefinedImages/lacrosseStick.jpg";
                        break;
                    case "Lacrosse Helmet":
                        newButton.ImageUrl = "~/userDefinedImages/lacrosseHelmet.jpg";
                        break;
                    default:
                        break;
                }
                newButton.Height = 155; newButton.Width = 155;
                newLabel.Height = 155; newLabel.Width = 495;
                buttonCount++;
                labelCount++;


                panel_test.Controls.Add(newButton);
                panel_label.Controls.Add(newLabel);

            }


        }

        //for the logo. takes you back to the homepage
        protected void imgBtn_logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainPage2.aspx", true);
        }

        //retrieves information from proudctCart
        public void RetriveInfoFromDatabase()
        {
            //records user input and declare variables
            string query = "";

            //establishes connection with server
            string dbServer = "cis425.wpcarey.asu.edu"; //"<Server IP or Hostname>"
            string username = "dhua5";      // "<DB username>"
            string password = "glassGATE56";      // "<DB password>"
            string dbName = "groupb04";  // "<DB name>"
            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};",
                            dbServer, username, password, dbName);
            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
            conn.Open();

            //populates query
            query = $"select * from productcart";

            //runs Query
            //creates command and reader object using query string and connection
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            var reader = cmd.ExecuteReader();

            //goes through database and store products in list_product
            while (reader.Read())
            {
                //records information and converts some variables for constructor
                var recNumber = reader["recNumber"];
                var productID = reader["productCartID"];
                var productName = reader["productCartName"];
                var productDescription = reader["productCartDescription"];
                var productPrice = reader["productCartPrice"];
                int int_recNumber = Convert.ToInt32(recNumber);
                double double_productPrice = Convert.ToDouble(productPrice);

                Product tmpProduct = new Product(int_recNumber, productID.ToString(), productName.ToString(), productDescription.ToString(),
                    double_productPrice);
                list_product.Add(tmpProduct);

            }
            reader.Close();
        }

        protected void img_shoppingCart_Click(object sender, ImageClickEventArgs e)
        {
        }

        //access databases and deletes all items in productCart table and hides the panel
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            string query;

            //establishes connection with server
            string dbServer = "cis425.wpcarey.asu.edu"; //"<Server IP or Hostname>"
            string username = "dhua5";      // "<DB username>"
            string password = "glassGATE56";      // "<DB password>"
            string dbName = "groupb04";  // "<DB name>"
            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};",
                            dbServer, username, password, dbName);
            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
            conn.Open();

            //populates query
            query = "delete from productcart";

            //runs Query
            //creates command and reader object using query string and connection
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            var reader = cmd.ExecuteReader();
            reader.Close();

            checkoutLbl.Visible = true;
            checkoutLbl.ForeColor = System.Drawing.Color.Red;
            checkoutLbl.Font.Size = 15;
            checkoutLbl.Text = "Your purchase has been cancelled.";

            panel_label.Visible = false;
            panel_test.Visible = false;
            //panel_checkBox.Visible = false;
            lbl_sTotal.Text = "$0.00";
            lbl_tax.Text = "$0.00";
            lbl_total.Text = "$0.00";
        }

        //accesses database to sum up all the prices in the product cart table
        public double CalculateTotal()
        {
            //records user input and declare variables
            string query = "";
            double totalAmount = 0;

            //establishes connection with server
            string dbServer = "cis425.wpcarey.asu.edu"; //"<Server IP or Hostname>"
            string username = "dhua5";      // "<DB username>"
            string password = "glassGATE56";      // "<DB password>"
            string dbName = "groupb04";  // "<DB name>"
            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};",
                            dbServer, username, password, dbName);
            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
            conn.Open();

            //populates query
            query = $"select sum(productCart.productCartPrice) as 'totalprice'from productcart";

            //runs Query
            //creates command and reader object using query string and connection
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            var reader = cmd.ExecuteReader();

            //goes through database and store products in list_product
            while (reader.Read())
            {
                //records information and converts some variables for constructor

                var totalPrice = reader["totalPrice"];

                if (totalPrice.ToString() != "")
                {
                    totalAmount = Convert.ToDouble(totalPrice);
                }

            }
            reader.Close();

            return totalAmount;
        }

        protected void btn_checkout_Click(object sender, EventArgs e)
        {
            if (lbl_sTotal.Text == "$0.00")
            {
                checkoutLbl.Visible = true;
                checkoutLbl.ForeColor = System.Drawing.Color.Red;
                checkoutLbl.Font.Size = 15;
                checkoutLbl.Text = "Your shopping cart is empty. Please select products to checkout.";
                panel_label.Visible = false;
                panel_test.Visible = false;
            }

            else
            {
                string query;

                //establishes connection with server
                string dbServer = "cis425.wpcarey.asu.edu"; //"<Server IP or Hostname>"
                string username = "dhua5";      // "<DB username>"
                string password = "glassGATE56";      // "<DB password>"
                string dbName = "groupb04";  // "<DB name>"
                string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};",
                                dbServer, username, password, dbName);
                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
                conn.Open();

                //populates query
                query = "delete from productcart";

                //runs Query
                //creates command and reader object using query string and connection
                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                reader.Close();

                checkoutLbl.Visible = true;
                checkoutLbl.ForeColor = System.Drawing.Color.Green;
                checkoutLbl.Font.Size = 24;
                checkoutLbl.Text = "Purchase Successful! Thank you for shopping with us!";
                panel_label.Visible = false;
                panel_test.Visible = false;
                //panel_checkBox.Visible = false;
                lbl_sTotal.Text = "$0.00";
                lbl_tax.Text = "$0.00";
                lbl_total.Text = "$0.00";
            }
        }

        protected void imgBtn_search_Click(object sender, ImageClickEventArgs e)
        {
            //redirect to main page
            //save txt_search.Text in Session   
            Session["searchText"] = txt_search.Text;

            Response.Redirect("MainPage2.aspx", true);

        }
    }
}