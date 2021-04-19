using GetRecordID.Models;
using GetRecordID.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetRecordIDExample
{
    public partial class FormCreateRecord : Form
    {
        public FormCreateRecord() => InitializeComponent();

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation()) 
            {
                var model = new Record();

                model.BogusName = txtName.Text;
                model.CourtDate = txtCourtDate.Text;
                model.AmountOwed = Convert.ToDecimal(txtAmount.Text);
                
                Config.DbConnection.CreateRecord(model);

                txtAmount.Text = "";
                txtCourtDate.Text = "";
                txtName.Text = "";
                lblMessage.Text = "Record Added!";
            }
        }
        public bool Validation() 
        {
            bool isValid = true;
            var enUS = new CultureInfo("en-us");

            if (txtName.Text.Length == 0 || !Regex.IsMatch(txtName.Text, @"^[a-zA-Z ]+$"))
            {
                MessageBox.Show("Please enter a valid name. \nOnly letters or spaces are accepted. ", "Error: Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }
            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid amount", "Error: Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }
            
            if (!DateTime.TryParseExact(txtCourtDate.Text, @"d", enUS, DateTimeStyles.None, out DateTime cDate))
            {
                MessageBox.Show("Please enter a valid date","Error: Invalid Entry",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            return isValid; 
        }

        private void txtName_TextChanged(object sender, EventArgs e) => lblMessage.Text = "";

        private void txtCourtDate_TextChanged(object sender, EventArgs e) => lblMessage.Text = "";

        private void txtAmount_TextChanged(object sender, EventArgs e) => lblMessage.Text = "";
    }
}
