using System;
using System.Windows.Forms;

namespace mealPlan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //string[,] mealArray = new string[,] { { "Bagel", "3.95" }, { "Vegetarian Special", "10.95" }, { "Protein Platter", "11.95" } };
        string[] mealArray = new string[] {"Bagel", "Vegetarian Special","Protein Platter" };

        private void Form1_Load(object sender, EventArgs e)
        {
            resetLabels();// Function call clears label information

            //This for loop initializes three combo boxes for with the meal type
            for (Int32 index = 0; index < mealArray.Length; index++) {
                cboMeal1.Items.Add(mealArray[index]);
                cboMeal2.Items.Add(mealArray[index]);
                cboMeal3.Items.Add(mealArray[index]);
            }
        }

        private void btnOrderNow_Click(object sender, EventArgs e)
        {
            resetLabels();// Function call clears label information

            Int32[] qtyArray = new Int32[3];
            string[] mealSelection = new string[3];
            bool errStatus = true;
            bool cboStatus = true;
           // bool negativieStatus = true;

            //Stores meal selection from comboboxes in an array
            mealSelection[0] = cboMeal1.Text;
            mealSelection[1] = cboMeal2.Text;
            mealSelection[2] = cboMeal3.Text;

            //This if statement checks for empty comboboxes 
            //If any are found, the user is alerted and a flag is initialized
            if ((cboMeal1.SelectedIndex == -1) || (cboMeal2.SelectedIndex == -1) ||
                (cboMeal3.SelectedIndex == -1)) {
                lblCboErr.Text = "Please complete meal selection";
                cboStatus = false;
            }        
            else{
                //These if statements check for invalid quantities 
                //If any are found, the user is alerted and a flag is initialized
                //Otherwise the data is stored in an array
                if((Int32.TryParse(txtQty1.Text, out qtyArray[0]) == false) || (qtyArray[0] < 1)) {
                    lblQtyErr1.Text = "Only Positive Numbers Allowed";
                    errStatus = false;                   
                }
                /*else if (qtyArray[0] < 1)
                    {
                    lblQtyErr1.Text = "+ Numbers Only";
                    errStatus = false;
                }*/
                if ((Int32.TryParse(txtQty2.Text, out qtyArray[1]) == false) || (qtyArray[1] < 1)) {
                    lblQtyErr2.Text = "Only Positive Numbers Allowed";
                    errStatus = false;
                }
                if ((Int32.TryParse(txtQty3.Text, out qtyArray[2]) == false) || (qtyArray[2] < 1)) {
                    lblQtyErr3.Text = "Only Positive Numbers Allowed";
                    errStatus = false;
                }
             
                //This if statement checks the state of the flags 
                //If the state has remained true the code is executed
                if ((errStatus == true) && (cboStatus == true)){                    
                    double subtotal = CalculateSubTotal(mealSelection, qtyArray);
                    double tax = CalculateTax(subtotal);
                    CalculateTotal(subtotal,tax);                     
                }
            }
        }
        //This function calculates and returns the subtotal of the meal plan based on
        //the meal, price and quantity and return the result        
        public double CalculateSubTotal(string[] mealSelect, Int32[] qty) {
            double subTotal = 0;
            for (Int32 i = 0; i < mealSelect.Length; i++) {
                if (mealSelect[i] == "Bagel"){ 
                    subTotal += 3.95 * qty[i];
                }
                if (mealSelect[i] == "Vegetarian Special") {
                    subTotal += 10.95 * qty[i];
                }
                if (mealSelect[i] == "Protein Platter") {
                    subTotal += 11.95 * qty[i];
                }
            }
            lblShowSubTotal.Text = "$" + Convert.ToString(subTotal);
            return subTotal;
        }
        //This function calculates and returns the taxes applied to the meal 
        //plan based on the subtotal   
        public double CalculateTax(double subTotal) {
            double tax = 0;
            tax = Math.Round((subTotal * 0.13), 2);
            lblShowTax.Text = "$" + Convert.ToString(tax);
            return tax;
        }
        //This function calculates the final total of the meal 
        //plan based on the subtotal and taxes
        public void CalculateTotal(double subTotal, double tax) {
            double total = 0;
            total = subTotal + tax;
            lblShowTotal.Text = "$" + Convert.ToString(total);
        }
        //This function resets all text lables used to display content to the user
        public void resetLabels() {
            lblCboErr.ResetText();
            lblQtyErr1.ResetText();
            lblQtyErr2.ResetText();
            lblQtyErr3.ResetText();
            lblShowSubTotal.ResetText();
            lblShowTax.ResetText();
            lblShowTotal.ResetText();
        }
    }
}