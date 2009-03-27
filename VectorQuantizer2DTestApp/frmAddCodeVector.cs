using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorQuantizer2D;

namespace VectorQuantizer2DTestApp
{
    public partial class frmAddCodeVector : Form
    {
        /// <summary>
        /// Gets the code vector entered into this form
        /// </summary>
        public Centroid<string> Vector
        {
            get { return new Centroid<string>(Convert.ToDouble(txtX.Text), Convert.ToDouble(txtY.Text), txtValue.Text); }
        }

        public frmAddCodeVector()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Check the boxes
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
