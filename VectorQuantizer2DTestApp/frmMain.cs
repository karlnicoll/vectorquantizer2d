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
    public partial class frmMain : Form
    {
        private List<Vector2D> vectors;
        private List<Centroid<string>> centroids;

        public frmMain()
        {
            InitializeComponent();
            vectors = new List<Vector2D>();
            centroids = new List<Centroid<string>>();
        }

        private void btnAddVector_Click(object sender, EventArgs e)
        {
            frmAddVector vectorForm = new frmAddVector();
            if (vectorForm.ShowDialog() == DialogResult.OK)
            {
                vectors.Add(vectorForm.Vector);
                lbVectors.Items.Add("{ " + vectorForm.Vector.X.ToString() + ", " + vectorForm.Vector.Y.ToString() + " }");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (int curItem in lbVectors.SelectedIndices)
            {
                lbVectors.Items.RemoveAt(curItem);
                vectors.RemoveAt(curItem);
            }
        }

        private void btnAddCentroid_Click(object sender, EventArgs e)
        {
            frmAddCodeVector vectorForm = new frmAddCodeVector();
            if (vectorForm.ShowDialog() == DialogResult.OK)
            {
                centroids.Add(vectorForm.Vector);
                lbCodebook.Items.Add(vectorForm.Vector.Value + ": { " + vectorForm.Vector.X.ToString() + ", " + vectorForm.Vector.Y.ToString() + " }");
            }
        }

        private void btnRemoveCentroid_Click(object sender, EventArgs e)
        {
            foreach (int curItem in lbCodebook.SelectedIndices)
            {
                lbCodebook.Items.RemoveAt(curItem);
                centroids.RemoveAt(curItem);
            }
        }

        private void btnQuantize_Click(object sender, EventArgs e)
        {
            KMeansQuantizer<string> quantizer = new KMeansQuantizer<string>(centroids);
            string[] results = quantizer.Quantize(vectors.ToArray());

            for (int i = 0; i < results.Length; i++)
            {
                txtResults.Text += lbVectors.Items[i].ToString() + ": " + results[i] + "\n";
            }
            MessageBox.Show("Complete!");
        }
    }
}
