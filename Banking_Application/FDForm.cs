using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_Application
{
    public partial class FDForm : Form
    {
        public FDForm()
        {
            InitializeComponent();
            loaddate();
            loadmode();
        }

        private void loadmode()
        {
            //throw new NotImplementedException();
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Cheque");
        }

        private void loaddate()
        {
            //throw new NotImplementedException();
            datelbl.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Banking_dbEntities1 dbe = new Banking_dbEntities1();
            decimal accno = Convert.ToDecimal(accnotxt.Text);
            var accounts = dbe.userAccounts.Where(x => x.Account_No == accno).SingleOrDefault();
            FD fdform = new FD();

            fdform.Account_No = Convert.ToDecimal(accnotxt.Text);
            fdform.Mode = comboBox1.SelectedItem.ToString();
            fdform.Rupees = rupeestxt.Text;
            fdform.Period = Convert.ToInt32(periodtxt.Text);
            fdform.Interest_Rate = Convert.ToDecimal(interesttxt.Text);
            fdform.Start_Data = DateTime.UtcNow.ToString("MM/dd/yyyy");
            fdform.Maturity_Date = (DateTime.UtcNow.AddDays(Convert.ToInt32(periodtxt.Text))).ToString("MM/dd/yyyy");
            fdform.Maturity_Amount = ((Convert.ToDecimal(rupeestxt.Text) * Convert.ToInt32(periodtxt.Text) * Convert.ToDecimal(interesttxt.Text)) /
                (100 * 12 * 30)) + (Convert.ToDecimal(rupeestxt.Text));
            dbe.FDs.Add(fdform);

            decimal amount = Convert.ToDecimal(rupeestxt.Text);
            decimal totalamount = Convert.ToDecimal(accounts.Balance);
            decimal fdamount = totalamount - amount;
            //accounts.Balance = fdamount;
            dbe.SaveChanges();
            MessageBox.Show("FD Started Now");

        }
    }
}
