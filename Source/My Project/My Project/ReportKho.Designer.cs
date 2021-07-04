namespace My_Project
{
    partial class ReportKho
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
            this.crrInRaHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crrInRaHoaDon
            // 
            this.crrInRaHoaDon.ActiveViewIndex = -1;
            this.crrInRaHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crrInRaHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.crrInRaHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crrInRaHoaDon.Location = new System.Drawing.Point(0, 0);
            this.crrInRaHoaDon.Name = "crrInRaHoaDon";
            this.crrInRaHoaDon.Size = new System.Drawing.Size(284, 261);
            this.crrInRaHoaDon.TabIndex = 0;
            // 
            // ReportKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.crrInRaHoaDon);
            this.Name = "ReportKho";
            this.Text = "ReportKho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportKho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crrInRaHoaDon;
    }
}