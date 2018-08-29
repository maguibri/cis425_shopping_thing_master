using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shopping_thing2
{
    public partial class ProductDetailsPage : System.Web.UI.Page
    {
        List<Product> list_product = new List<Product>();
        Product addProductToCart;

        /* receives queryString from main page
         * checks string against database
         * displays the correct item images and label */

        protected void Page_Load(object sender, EventArgs e)
        {
            //preset button text
            addBtn.Text = "Add to Cart";
            //receives query string from main page
            string recNumber = Request.QueryString["recNumber"];
            //checks string against database
            Product product = RetriveInfoFromDatabase(recNumber);
            addProductToCart = product;

            //creates images, labels correctly.
            int imageCount = 1;
            int labelCount = 1;

            Image newImage = new Image();
            Label newLabel = new Label();

            newImage.ID = "newImage" + imageCount;
            newLabel.ID = "newLabel" + labelCount;
            newLabel.Text = $"Name: {product.ProductName} <br> Description: {product.ProductDescription} <br> Price: ${product.ProductPrice} <br><br><br><br><br><br> ";

            switch (product.RecNumber)
            {
                case 1:
                    newImage.ImageUrl = "~/userDefinedImages/baseballBat.jpg";
                    break;
                case 2:
                    newImage.ImageUrl = "~/userDefinedImages/baseballHelmet.jpg";
                    break;
                case 3:
                    newImage.ImageUrl = "~/userDefinedImages/baseballCleats.jpg";
                    break;
                case 4:
                    newImage.ImageUrl = "~/userDefinedImages/baseBallGlove.jpg";
                    break;
                case 5:
                    newImage.ImageUrl = "~/userDefinedImages/baseball.jpg";
                    break;
                case 6:
                    newImage.ImageUrl = "~/userDefinedImages/footballPads.jpg";
                    break;
                case 7:
                    newImage.ImageUrl = "~/userDefinedImages/footballs.jpg";
                    break;
                case 8:
                    newImage.ImageUrl = "~/userDefinedImages/footballHelment.jpg";
                    break;
                case 9:
                    newImage.ImageUrl = "~/userDefinedImages/footballCleats.jpg";
                    break;
                case 10:
                    newImage.ImageUrl = "~/userDefinedImages/football Gloves.jpg";
                    break;
                case 11:
                    newImage.ImageUrl = "~/userDefinedImages/hockeyStick.jpg";
                    break;
                case 12:
                    newImage.ImageUrl = "~/userDefinedImages/HockeyHelmet.jpg";
                    break;
                case 13:
                    newImage.ImageUrl = "~/userDefinedImages/hockeyGloves.jpg";
                    break;
                case 14:
                    newImage.ImageUrl = "~/userDefinedImages/hockeyPuck.jpg";
                    break;
                case 15:
                    newImage.ImageUrl = "~/userDefinedImages/hockyPads.jpg";
                    break;
                case 16:
                    newImage.ImageUrl = "~/userDefinedImages/lacrossePads.jpg";
                    break;
                case 17:
                    newImage.ImageUrl = "~/userDefinedImages/lacrossegloves.jpg";
                    break;
                case 18:
                    newImage.ImageUrl = "~/userDefinedImages/lacrosseCleats.jpg";
                    break;
                case 19:
                    newImage.ImageUrl = "~/userDefinedImages/lacrosseStick.jpg";
                    break;
                case 20:
                    newImage.ImageUrl = "~/userDefinedImages/lacrosseHelmet.jpg";
                    break;
                default:
                    break;
            }

            newImage.Height = 155; newImage.Width = 155;
            newLabel.Height = 155; newLabel.Width = 495;

            imageCount++;
            labelCount++;

            panel_test.Controls.Add(newImage);
            panel_label.Controls.Add(newLabel);



        }

        /* uses cartRecNumber to receive product information */
        public Product RetriveInfoFromDatabase(string cartRecNumber)
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
            query = $"select * from products where recNumber = '{cartRecNumber}'";

            //runs Query
            //creates command and reader object using query string and connection
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            var reader = cmd.ExecuteReader();

            //goes through database and store products in list_product
            while (reader.Read())
            {
                //records information and converts some variables for constructor
                var recNumber = reader["recNumber"];
                var productID = reader["productID"];
                var productName = reader["productName"];
                var productDescription = reader["productDescription"];
                var productPrice = reader["productPrice"];
                int int_recNumber = Convert.ToInt32(recNumber);
                double double_productPrice = Convert.ToDouble(productPrice);

                //constructs product object and stores in list_product
                Product tmpProduct = new Product(int_recNumber, productID.ToString(), productName.ToString(), productDescription.ToString(),
                    double_productPrice);
                list_product.Add(tmpProduct);
            }
            reader.Close();
            return list_product[0];
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            addBtn.Text = "Added to Cart";
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
            query = $"Insert into productcart (productcartID,productCartName,productCartDescription,productCartPrice) " +
                $"values ('{addProductToCart.ProductID}', '{addProductToCart.ProductName}','{addProductToCart.ProductDescription}','{addProductToCart.ProductPrice}')";

            //runs Query
            //creates command and reader object using query string and connection
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            var reader = cmd.ExecuteReader();

            //goes through database and store products in list_product
            while (reader.Read())
            {
                //records information and converts some variables for constructor
                var recNumber = reader["recNumber"];
                var productID = reader["productID"];
                var productName = reader["productName"];
                var productDescription = reader["productDescription"];
                var productPrice = reader["productPrice"];
                int int_recNumber = Convert.ToInt32(recNumber);
                double double_productPrice = Convert.ToDouble(productPrice);
            }
            reader.Close();

        }

        protected void img_shoppingCart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShoppingCartPage2.aspx");

        }

        protected void imgBtn_logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainPage2.aspx");
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