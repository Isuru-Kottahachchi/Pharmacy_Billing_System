using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1846061_I.U_Kottahachchi_ITE1112_Assignment_2
{
    class OrderItem
    {

        //attributes
        private string itemName;
        private string category;
        private double unitPrice;
        private int qty;
        private double orderValue;
        private double discount;
        private double discountedOrderValue;

        //Constructor
        public OrderItem(string itemName, string category, double unitPrice,
            int qty, int paymentType = 0)
        {
            this.itemName = itemName;
            this.category = category;
            this.unitPrice = unitPrice;
            this.qty = qty;
            this.orderValue = this.unitPrice * this.qty;

            this.discount = 0;

            //discount
            if (paymentType == 0)
            {
                this.cashDiscount();
            }
            else
            {
                this.ccDiscount();
            }


            this.discountedOrderValue = this.orderValue - this.discount;
        }

        private void cashDiscount()
        {
            if (this.category == "Pharmaceuticals" && this.orderValue >= 500
                && this.orderValue <= 1000)
            {
                this.discount = this.orderValue * 0.05;
            }
            else if (this.category == "Pharmaceuticals" && this.orderValue > 1000)
            {
                this.discount = this.orderValue * 0.07;
            }
            else if (this.category == "Milk supplements" && this.orderValue > 1000)
            {
                this.discount = this.orderValue * 0.05;
            }
            else if (this.category == "Diapers" && this.orderValue > 1000)
            {
                this.discount = this.orderValue * 0.04;
            }
            else
            {
                this.discount = 0;
            }
        }

        private void ccDiscount()
        {
            if (this.category == "Pharmaceuticals" && this.orderValue >= 500
                && this.orderValue <= 1000)
            {
                this.discount = this.orderValue * 0.03;
            }
            else if (this.category == "Pharmaceuticals" && this.orderValue > 1000)
            {
                this.discount = this.orderValue * 0.05;
            }
            else if (this.category == "Milk supplements" && this.orderValue > 1000)
            {
                this.discount = this.orderValue * 0.03;
            }
            else if (this.category == "Diapers" && this.orderValue > 1000)
            {
                this.discount = this.orderValue * 0.02;
            }
            else
            {
                this.discount = 0;
            }
        }

        //getters
        public string item_name
        {
            get
            {
                return this.itemName;
            }
        }

        public string item_category
        {
            get
            {
                return this.category;
            }
        }

        public double item_unitPrice
        {
            get
            {
                return this.unitPrice;
            }
        }

        public int item_qty
        {
            get
            {
                return this.qty;
            }
        }

        public double item_orderValue
        {
            get
            {
                return this.orderValue;
            }
        }

        public double item_discount
        {
            get
            {
                return this.discount;
            }
        }

        public double item_disOrderValue
        {
            get
            {
                return this.discountedOrderValue;
            }





























        }
    }
}

