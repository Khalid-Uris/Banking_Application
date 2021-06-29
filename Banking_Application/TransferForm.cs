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
    public partial class TransferForm : Form
    {
        public TransferForm()
        {
            InitializeComponent();
            loaddate();
        }

        private void loaddate()
        {
            //throw new NotImplementedException();
            label2.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {

        }
        // Show Details
        private void button1_Click(object sender, EventArgs e)
        {
            Banking_dbEntities1 dbe = new Banking_dbEntities1();
            decimal b = Convert.ToDecimal(fromacctxt.Text);
            var item = (from u in dbe.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();
            nametxt.Text = item.Name;
            amounttxt.Text = Convert.ToString(item.Balance);
        }
        // Transfer Account
        private void button2_Click(object sender, EventArgs e)
        {
            Banking_dbEntities1 dbe = new Banking_dbEntities1();
            decimal b = Convert.ToDecimal(fromacctxt.Text);
            var item = (from u in dbe.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();

            decimal b1 = Convert.ToDecimal(item.Balance);
            decimal totalbal = Convert.ToDecimal(transfertxt.Text);
            decimal transferacc = Convert.ToDecimal(desaccounttxt.Text);
            if(b1>totalbal)
            {
                userAccount item2= (from u in dbe.userAccounts
                                    where u.Account_No == transferacc
                                    select u).FirstOrDefault();

                item2.Balance = item2.Balance + totalbal;
                item.Balance = item.Balance + totalbal;

                Transfer transfer = new Transfer();
                transfer.Account_No = Convert.ToDecimal(fromacctxt.Text);
                //transfer.ToTransfer = Convert.ToDecimal(desaccounttxt.Text);
                transfer.Date = DateTime.UtcNow.ToString();
                transfer.Name = nametxt.Text;
                transfer.balance = Convert.ToDecimal(transfertxt.Text);

                dbe.Transfers.Add(transfer);
                dbe.SaveChanges();
                MessageBox.Show("Transfer Money Successfully");


            }
        }
    }
}
