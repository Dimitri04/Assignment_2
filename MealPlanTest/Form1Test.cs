using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mealPlan;
using System.Windows.Forms;

namespace MealPlanTest
{
    [TestClass]
    public class Form1Test
    {
        Form1 form;
        String[] arr1;
        Int32[] arr3;
        Label lblShowSubTotal;
        Label lblShowTax;
        Label lblShowTotal;
        Double subtotal;
        double tax;

        [TestInitialize]
        public void TestInit() {
            form = new Form1();
            arr1 = new String[] { "Bagel", "Vegetarian Special", "Protein Platter" };
            arr3 = new Int32[] { 1, 1, 1 };
            lblShowSubTotal = form.lblShowSubTotal;
            lblShowTax = form.lblShowTax;
            lblShowTotal = form.lblShowTotal;
            subtotal = 19.75; // 5 bagels at $3.95 each
            tax = 2.57;
        }

        [TestMethod]
        public void SubtotalValid() {
            form.CalculateSubTotal(arr1, arr3);
            Assert.AreEqual("$"+ Convert.ToString(26.85), lblShowSubTotal.Text);
        }

        [TestMethod]
        public void TaxValid() {
            form.CalculateTax(subtotal);
            Assert.AreEqual("$" + Convert.ToString(2.57), form.lblShowTax.Text);
        }

        [TestMethod]
        public void TotalValid() {
            form.CalculateTotal(subtotal, tax);
            Assert.AreEqual("$" + Convert.ToString(22.32), form.lblShowTotal.Text);
        }

        [TestMethod]
        public void ResetValid() {
            form.resetLabels();
            Assert.AreEqual("", form.lblShowSubTotal.Text);
            Assert.AreEqual("", form.lblShowTax.Text);
            Assert.AreEqual("", form.lblShowTotal.Text);
        }
    }
}
