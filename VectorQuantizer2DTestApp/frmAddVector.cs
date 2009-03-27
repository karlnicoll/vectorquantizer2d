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
    public partial class frmAddVector : Form
    {
        /// <summary>
        /// Gets the vector entered into this form
        /// </summary>
        public Vector2D Vector
        {
            get { return new Vector2D(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text)); }
        }

        public frmAddVector()
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
