namespace VectorQuantizer2DTestApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxVectors = new System.Windows.Forms.GroupBox();
            this.lbVectors = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddVector = new System.Windows.Forms.Button();
            this.gbxCentroids = new System.Windows.Forms.GroupBox();
            this.btnRemoveCentroid = new System.Windows.Forms.Button();
            this.lbCodebook = new System.Windows.Forms.ListBox();
            this.btnAddCentroid = new System.Windows.Forms.Button();
            this.btnQuantize = new System.Windows.Forms.Button();
            this.gbxResults = new System.Windows.Forms.GroupBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.gbxVectors.SuspendLayout();
            this.gbxCentroids.SuspendLayout();
            this.gbxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxVectors
            // 
            this.gbxVectors.Controls.Add(this.btnRemove);
            this.gbxVectors.Controls.Add(this.lbVectors);
            this.gbxVectors.Controls.Add(this.btnAddVector);
            this.gbxVectors.Location = new System.Drawing.Point(12, 12);
            this.gbxVectors.Name = "gbxVectors";
            this.gbxVectors.Size = new System.Drawing.Size(218, 273);
            this.gbxVectors.TabIndex = 0;
            this.gbxVectors.TabStop = false;
            this.gbxVectors.Text = "Vectors";
            // 
            // lbVectors
            // 
            this.lbVectors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVectors.FormattingEnabled = true;
            this.lbVectors.Location = new System.Drawing.Point(6, 19);
            this.lbVectors.Name = "lbVectors";
            this.lbVectors.Size = new System.Drawing.Size(206, 212);
            this.lbVectors.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(57, 237);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(155, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddVector
            // 
            this.btnAddVector.Location = new System.Drawing.Point(6, 237);
            this.btnAddVector.Name = "btnAddVector";
            this.btnAddVector.Size = new System.Drawing.Size(52, 23);
            this.btnAddVector.TabIndex = 2;
            this.btnAddVector.Text = "Add...";
            this.btnAddVector.UseVisualStyleBackColor = true;
            this.btnAddVector.Click += new System.EventHandler(this.btnAddVector_Click);
            // 
            // gbxCentroids
            // 
            this.gbxCentroids.Controls.Add(this.btnRemoveCentroid);
            this.gbxCentroids.Controls.Add(this.lbCodebook);
            this.gbxCentroids.Controls.Add(this.btnAddCentroid);
            this.gbxCentroids.Location = new System.Drawing.Point(236, 12);
            this.gbxCentroids.Name = "gbxCentroids";
            this.gbxCentroids.Size = new System.Drawing.Size(222, 273);
            this.gbxCentroids.TabIndex = 0;
            this.gbxCentroids.TabStop = false;
            this.gbxCentroids.Text = "Codebook";
            // 
            // btnRemoveCentroid
            // 
            this.btnRemoveCentroid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCentroid.Location = new System.Drawing.Point(57, 237);
            this.btnRemoveCentroid.Name = "btnRemoveCentroid";
            this.btnRemoveCentroid.Size = new System.Drawing.Size(159, 23);
            this.btnRemoveCentroid.TabIndex = 3;
            this.btnRemoveCentroid.Text = "Remove Selected";
            this.btnRemoveCentroid.UseVisualStyleBackColor = true;
            this.btnRemoveCentroid.Click += new System.EventHandler(this.btnRemoveCentroid_Click);
            // 
            // lbCodebook
            // 
            this.lbCodebook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCodebook.FormattingEnabled = true;
            this.lbCodebook.Location = new System.Drawing.Point(6, 19);
            this.lbCodebook.Name = "lbCodebook";
            this.lbCodebook.Size = new System.Drawing.Size(210, 212);
            this.lbCodebook.TabIndex = 0;
            // 
            // btnAddCentroid
            // 
            this.btnAddCentroid.Location = new System.Drawing.Point(6, 237);
            this.btnAddCentroid.Name = "btnAddCentroid";
            this.btnAddCentroid.Size = new System.Drawing.Size(52, 23);
            this.btnAddCentroid.TabIndex = 2;
            this.btnAddCentroid.Text = "Add...";
            this.btnAddCentroid.UseVisualStyleBackColor = true;
            this.btnAddCentroid.Click += new System.EventHandler(this.btnAddCentroid_Click);
            // 
            // btnQuantize
            // 
            this.btnQuantize.Location = new System.Drawing.Point(12, 292);
            this.btnQuantize.Name = "btnQuantize";
            this.btnQuantize.Size = new System.Drawing.Size(446, 30);
            this.btnQuantize.TabIndex = 1;
            this.btnQuantize.Text = "Quantize...";
            this.btnQuantize.UseVisualStyleBackColor = true;
            this.btnQuantize.Click += new System.EventHandler(this.btnQuantize_Click);
            // 
            // gbxResults
            // 
            this.gbxResults.Controls.Add(this.txtResults);
            this.gbxResults.Location = new System.Drawing.Point(12, 329);
            this.gbxResults.Name = "gbxResults";
            this.gbxResults.Size = new System.Drawing.Size(446, 113);
            this.gbxResults.TabIndex = 2;
            this.gbxResults.TabStop = false;
            this.gbxResults.Text = "Results";
            // 
            // txtResults
            // 
            this.txtResults.AcceptsReturn = true;
            this.txtResults.AcceptsTab = true;
            this.txtResults.Location = new System.Drawing.Point(7, 20);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(433, 87);
            this.txtResults.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 454);
            this.Controls.Add(this.gbxResults);
            this.Controls.Add(this.btnQuantize);
            this.Controls.Add(this.gbxCentroids);
            this.Controls.Add(this.gbxVectors);
            this.Name = "frmMain";
            this.Text = "K-Means quantizer Test Application";
            this.gbxVectors.ResumeLayout(false);
            this.gbxCentroids.ResumeLayout(false);
            this.gbxResults.ResumeLayout(false);
            this.gbxResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxVectors;
        private System.Windows.Forms.ListBox lbVectors;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddVector;
        private System.Windows.Forms.GroupBox gbxCentroids;
        private System.Windows.Forms.Button btnRemoveCentroid;
        private System.Windows.Forms.ListBox lbCodebook;
        private System.Windows.Forms.Button btnAddCentroid;
        private System.Windows.Forms.Button btnQuantize;
        private System.Windows.Forms.GroupBox gbxResults;
        private System.Windows.Forms.TextBox txtResults;
    }
}

