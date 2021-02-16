using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E1846061_I.U_Kottahachchi_ITE1112_Assignment_2
{
    public partial class Form1 : Form
    {
        int billNo;
        double totalBill;
        int noItems;

        public Form1()
        {
            InitializeComponent();
            btnClearAll_61.Enabled = false;
            grpPaymentloyalityinfo_61.Enabled = false;
            grpItemInfo_61.Enabled = false;
            dgvitemizedbills_61.Enabled = false;
            billNo = 0;
            totalBill = 0;
            noItems = 0;
        }

        private void btnNeworder_61_Click(object sender, EventArgs e)
        {
            dgvitemizedbills_61.Rows.Clear();
            this.clearItemDetails();
            this.clearPaymentDetails();
            grpItemInfo_61.Enabled = false;
            billNo++;
            grpPaymentloyalityinfo_61.Enabled = true;
            txtBillNumber_61.Text = billNo.ToString();
            txtDataTime_61.Text = DateTime.Now.ToString();
            txtTotalorderValue_61.Text = "0.00";
            txtLoyalityDiscount_61.Text = "0.00";
            txtFinalorderValue_61.Text = "0.00";
            btnClearAll_61.Enabled = true;
        }

        private void btnContinue_61_Click(object sender, EventArgs e)
        {
            if (rbtCashPayment_61.Checked || rbtCreditCardPayment_61.Checked)
            {
                grpPaymentloyalityinfo_61.Enabled = false;
                grpItemInfo_61.Enabled = true;
            }
            else
            {
                MessageBox.Show("Select Payment Option");
            }

        }

        private void btnAdditem_61_Click(object sender, EventArgs e)
        {
            double price;
            int qty;
            if (txtItemname_61.Text == "" || cmbCategory_61.SelectedIndex < 0
                || !Double.TryParse(txtUnitprice_61.Text, out price)
                || !Int32.TryParse(txtQuan_61.Text, out qty))
            {
                MessageBox.Show("Invalid Item Information");
            }
            else
            {
                int paymentType = 0;

                if (rbtCreditCardPayment_61.Checked)
                {
                    paymentType = 1;
                }


                OrderItem item1 = new OrderItem(txtItemname_61.Text,
                    Convert.ToString(cmbCategory_61.SelectedItem),
                    price, qty, paymentType);

                this.noItems++;

                dgvitemizedbills_61.Rows.Add(
                    this.noItems.ToString(),
                    item1.item_name,
                    item1.item_category,
                    item1.item_unitPrice.ToString("#.##"),
                    item1.item_qty.ToString(),
                    item1.item_orderValue.ToString("#.##"),
                    item1.item_discount.ToString("#.##"),
                    item1.item_disOrderValue.ToString("#.##"));

                totalBill += item1.item_disOrderValue;
                txtTotalorderValue_61.Text = totalBill.ToString("#.##");

                double loyaltyDis = 0;

                if (chk_loyaltyCustomer_61.Checked && totalBill>2500)
                {
                    loyaltyDis = totalBill * 0.02;
                    txtLoyalityDiscount_61.Text = loyaltyDis.ToString("#.##");
                }

                txtFinalorderValue_61.Text = (totalBill - loyaltyDis).ToString("#.##");
                this.clearItemDetails();

            }
        }
        private void clearItemDetails()
        {
            txtItemname_61.Text = "";
            cmbCategory_61.Text = "";
            txtUnitprice_61.Text = "";
            txtQuan_61.Text = "";
            txtItemname_61.Focus();
        }
        private void clearPaymentDetails()
        {
            rbtCashPayment_61.Checked = false;
            rbtCreditCardPayment_61.Checked = false;
            chk_loyaltyCustomer_61.Checked = false;
        }

        private void btnClearAll_61_Click(object sender, EventArgs e)
        {

            this.clearItemDetails();
            txtFinalorderValue_61.Text = "0.00";
            txtLoyalityDiscount_61.Text = "0.00";
            txtTotalorderValue_61.Text = "0.00";
            dgvitemizedbills_61.Rows.Clear();
        }
    }
}
