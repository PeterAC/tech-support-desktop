using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerIncidents
{
    public partial class frmCustomerIncidents : Form
    {
        public frmCustomerIncidents()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.techSupportDataSet);

        }

        private void frmCustomerIncidents_Load(object sender, EventArgs e)
        {
            this.incidentsTableAdapter.Fill(this.techSupportDataSet.Incidents, Convert.ToInt32(customerIDToolStripTextBox.Text));
            this.customersTableAdapter.Fill(this.techSupportDataSet.Customers);
        }

        private void fillByCustomerIDToolStripButton_Click(object sender, EventArgs e)
        {
            int custID = Convert.ToInt32(customerIDToolStripTextBox.Text);
            try
            {
                this.customersTableAdapter.FillByCustomerID(this.techSupportDataSet.Customers, custID);
                // TODO: Add customer id not found error handling.
                if (true)
                {
                    this.incidentsTableAdapter.Fill(this.techSupportDataSet.Incidents, custID);
                }
                else
                {
                    MessageBox.Show("Customer not found", "ID error");
                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

    }
}
