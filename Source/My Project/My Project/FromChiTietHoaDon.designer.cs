namespace My_Project
{
    partial class frmChiTietHoaDon
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietHoaDon));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.crrInRaHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // crrInRaHoaDon
            // 
            this.crrInRaHoaDon.ActiveViewIndex = -1;
            this.crrInRaHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crrInRaHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.crrInRaHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crrInRaHoaDon.Location = new System.Drawing.Point(0, 0);
            this.crrInRaHoaDon.Name = "crrInRaHoaDon";
            this.crrInRaHoaDon.Size = new System.Drawing.Size(620, 394);
            this.crrInRaHoaDon.TabIndex = 0;
            // 
            // frmChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(620, 394);
            this.Controls.Add(this.crrInRaHoaDon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiTietHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Hóa Đơn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChiTietHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crrInRaHoaDon;
    }
}