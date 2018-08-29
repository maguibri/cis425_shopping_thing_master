using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_thing2
{
    public class Product
    {
        //attributes
        private int recNumber;
        private string productID;
        private string productName;
        private string productDescription;
        private double productPrice;

        //properties
        public int RecNumber {
            get { return recNumber; }
            set { this.recNumber = value; }
        }
        public string ProductID {
            get { return productID; }
            set { this.productID = value; }
        }
        public string ProductName {
            get { return productName; }
            set { this.productName = value; }
        }
        public string ProductDescription {
            get { return productDescription; }
            set { this.productDescription = value; }
        }
        public double ProductPrice {
            get { return productPrice; }
            set { this.productPrice = value; }
        }

        //constructors
        public Product(int recNumber, string productID, string productName, string productDescription, double productPrice){
            this.RecNumber = recNumber; this.ProductID = productID; this.ProductName = productName; this.ProductDescription = productDescription;
            this.ProductPrice = productPrice;
        }

        public override string ToString()
        {
            return productName + "<br>" + productPrice + "<br>" + productDescription;
        }
    }
}