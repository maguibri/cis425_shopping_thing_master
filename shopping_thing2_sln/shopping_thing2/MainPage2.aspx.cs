using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shopping_thing2
{
    public partial class MainPage2 : System.Web.UI.Page
    {
        //declares a new list of products
        List<Product> list_product = new List<Product>();
        List<Product> list_productSelected = new List<Product>();

        /* retrives info from database
         * displays the items in the list
         * make jquery string to pass information to ProductDetailsPage */
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.Visible = true;
            aboutLbl.Visible = true;
            RetriveInfoFromDatabase();
            aboutLbl.Text = "We are the Unkown company. Our company was created by a group of uncreative individuals who refused to come up with a creative name. Unkown sells a variety of sports products from four major types of sports: Baseball, Hockey, Football, and Lacrosse. We thank you for shopping on our website and hope you find everything that you need.";
            panel_label.Visible = false;
            panel_test.Visible = false;

            int buttonCount = 1;
            int hyperLinkCount = 1;
            //displays the items, passes information
            //adds control to panel
            for (int i = 0; i < list_product.Count; i++)
            {
                Image newButton = new Image();
                HyperLink newHyperLink = new HyperLink();
                newButton.ImageAlign = ImageAlign.TextTop;
                newButton.ID = "newButton" + buttonCount;
                newHyperLink.ID = "newHyperLink" + hyperLinkCount;
                newHyperLink.Text = $"Name: {list_product[i].ProductName} <br> Description: {list_product[i].ProductDescription} <br> Price: ${list_product[i].ProductPrice}<br><br><br><br><br><br> ";

                switch (list_product[i].RecNumber)
                {
                    case 1:
                        newButton.ImageUrl = "~/userDefinedImages/baseballBat.jpg";
                        break;
                    case 2:
                        newButton.ImageUrl = "~/userDefinedImages/baseballHelmet.jpg";
                        break;
                    case 3:
                        newButton.ImageUrl = "~/userDefinedImages/baseballCleats.jpg";
                        break;
                    case 4:
                        newButton.ImageUrl = "~/userDefinedImages/baseBallGlove.jpg";
                        break;
                    case 5:
                        newButton.ImageUrl = "~/userDefinedImages/baseball.jpg";
                        break;
                    case 6:
                        newButton.ImageUrl = "~/userDefinedImages/footballPads.jpg";
                        break;
                    case 7:
                        newButton.ImageUrl = "~/userDefinedImages/footballs.jpg";
                        break;
                    case 8:
                        newButton.ImageUrl = "~/userDefinedImages/footballHelment.jpg";
                        break;
                    case 9:
                        newButton.ImageUrl = "~/userDefinedImages/footballCleats.jpg";
                        break;
                    case 10:
                        newButton.ImageUrl = "~/userDefinedImages/football Gloves.jpg";
                        break;
                    case 11:
                        newButton.ImageUrl = "~/userDefinedImages/hockeyStick.jpg";
                        break;
                    case 12:
                        newButton.ImageUrl = "~/userDefinedImages/HockeyHelmet.jpg";
                        break;
                    case 13:
                        newButton.ImageUrl = "~/userDefinedImages/hockeyGloves.jpg";
                        break;
                    case 14:
                        newButton.ImageUrl = "~/userDefinedImages/hockeyPuck.jpg";
                        break;
                    case 15:
                        newButton.ImageUrl = "~/userDefinedImages/hockyPads.jpg";
                        break;
                    case 16:
                        newButton.ImageUrl = "~/userDefinedImages/lacrossePads.jpg";
                        break;
                    case 17:
                        newButton.ImageUrl = "~/userDefinedImages/lacrossegloves.jpg";
                        break;
                    case 18:
                        newButton.ImageUrl = "~/userDefinedImages/lacrosseCleats.jpg";
                        break;
                    case 19:
                        newButton.ImageUrl = "~/userDefinedImages/lacrosseStick.jpg";
                        break;
                    case 20:
                        newButton.ImageUrl = "~/userDefinedImages/lacrosseHelmet.jpg";
                        break;
                    default:
                        break;
                }
                newButton.Height = 155; newButton.Width = 155;
                newHyperLink.Height = 155; newHyperLink.Width = 495;

                //makes a jquery string to pass information to product details page
                string recNumber = "0";
                recNumber = list_product[i].RecNumber.ToString();
                newHyperLink.NavigateUrl = $"ProductDetailsPage.aspx?recNumber={recNumber}";

                buttonCount++;
                hyperLinkCount++;

                //adds controls to panel
                panel_test.Controls.Add(newButton);
                panel_label.Controls.Add(newHyperLink);
            }

            txt_search.Text = Session["searchText"] as string;

            if (txt_search.Text != "")
            {
                RetriveInfoFromDatabase();
                Image1.Visible = false;
                aboutLbl.Visible = false;
                panel_label.Visible = true;
                panel_test.Visible = true;
            }
        }

        /* records List of selected items
         * navigates user to shoppingCart page */
        protected void img_shoppingCart_Click(object sender, ImageClickEventArgs e)
        {
            //nagivates to shoppingCart Page
            Response.Redirect("ShoppingCartPage2.aspx", true);
        }

        //makes panels visible for user
        protected void imgBtn_search_Click(object sender, ImageClickEventArgs e)
        {
            Image1.Visible = false;
            aboutLbl.Visible = false;
            panel_label.Visible = true;
            panel_test.Visible = true;
            txt_search.Text = "";
        }

        /* connect to database
         * retrieves data
         * apply filter */
        public void RetriveInfoFromDatabase()
        {
            //records user input and declare variables
            string userInput = txt_search.Text;
            string priceFilter = "";
            string sportFilter = "";
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

            //applys filter
            if (ddl_price.SelectedValue == "H2L")
            {
                priceFilter = "desc";
            }
            if (ddl_price.SelectedValue == "L2H")
            {
                priceFilter = "asc";
            }
            if (ddl_sport.SelectedValue != "0")
            {
                sportFilter = ddl_sport.SelectedItem.ToString();
            }

            //populates query
            query = $"select * from products where productName like ('%{userInput}%')";

            if (sportFilter != "")
            {
                query += $" and productName like ('%{sportFilter}%')";
            }
            if (priceFilter != "")
            {
                query += $" order by productPrice {priceFilter}";
            }

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
        }

        protected void imgBtn_logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainPage2.aspx", true);
        }
    }
}