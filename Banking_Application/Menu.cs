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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void newAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newAccount newacc = new newAccount();
            newacc.MdiParent = this;
            newacc.Show();
        }

        private void updateSearchAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdationForm up = new UpdationForm();
            up.MdiParent = this;
            up.Show();
        }

        private void allCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerList C1 = new CustomerList();
            C1.MdiParent = this;
            C1.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreditForm crdfrm = new CreditForm();
            crdfrm.MdiParent = this;
            crdfrm.Show();
        }

        private void widthdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debitform dbf = new Debitform();
            dbf.MdiParent = this;
            dbf.Show();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferForm Tf = new TransferForm();
            Tf.MdiParent = this;
            Tf.Show();
        }

        private void fDFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDForm fds = new FDForm();
            fds.MdiParent = this;
            fds.Show();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            balanceSheet bls = new balanceSheet();
            bls.MdiParent = this;
            bls.Show();
        }

        private void viewFDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewFD viewFDobject = new viewFD();
            viewFDobject.MdiParent = this;
            viewFDobject.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.MdiParent = this;
            cp.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
