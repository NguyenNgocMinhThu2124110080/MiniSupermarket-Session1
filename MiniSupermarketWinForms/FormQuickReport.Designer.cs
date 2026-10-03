/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026
 * Mo ta: Giao dien Designer cho Man hinh Bao cao doanh thu
 */
namespace MiniSupermarketWinForms
{
    partial class FormQuickReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalOrdersTitle = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalRevenueTitle = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblBestSellerTitle = new System.Windows.Forms.Label();
            this.lblBestSeller = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpReportDate
            // 
            this.dtpReportDate.Location = new System.Drawing.Point(30, 30);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(200, 20);
            this.dtpReportDate.TabIndex = 0;
            // 
            // btnRunReport
            // 
            this.btnRunReport.Location = new System.Drawing.Point(250, 27);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(120, 26);
            this.btnRunReport.TabIndex = 1;
            this.btnRunReport.Text = "Xem Báo Cáo";
            this.btnRunReport.UseVisualStyleBackColor = true;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.lblTotalOrders);
            this.panel1.Controls.Add(this.lblTotalOrdersTitle);
            this.panel1.Location = new System.Drawing.Point(30, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 150);
            this.panel1.TabIndex = 2;
            // 
            // lblTotalOrdersTitle
            // 
            this.lblTotalOrdersTitle.AutoSize = true;
            this.lblTotalOrdersTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersTitle.Location = new System.Drawing.Point(10, 20);
            this.lblTotalOrdersTitle.Name = "lblTotalOrdersTitle";
            this.lblTotalOrdersTitle.Size = new System.Drawing.Size(130, 17);
            this.lblTotalOrdersTitle.TabIndex = 0;
            this.lblTotalOrdersTitle.Text = "Tổng số hóa đơn";
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.Location = new System.Drawing.Point(10, 60);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(36, 37);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.lblTotalRevenue);
            this.panel2.Controls.Add(this.lblTotalRevenueTitle);
            this.panel2.Location = new System.Drawing.Point(300, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 150);
            this.panel2.TabIndex = 3;
            // 
            // lblTotalRevenueTitle
            // 
            this.lblTotalRevenueTitle.AutoSize = true;
            this.lblTotalRevenueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueTitle.Location = new System.Drawing.Point(10, 20);
            this.lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            this.lblTotalRevenueTitle.Size = new System.Drawing.Size(123, 17);
            this.lblTotalRevenueTitle.TabIndex = 0;
            this.lblTotalRevenueTitle.Text = "Tổng doanh thu";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.Location = new System.Drawing.Point(10, 60);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(65, 37);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0 đ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCoral;
            this.panel3.Controls.Add(this.lblBestSeller);
            this.panel3.Controls.Add(this.lblBestSellerTitle);
            this.panel3.Location = new System.Drawing.Point(570, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 150);
            this.panel3.TabIndex = 4;
            // 
            // lblBestSellerTitle
            // 
            this.lblBestSellerTitle.AutoSize = true;
            this.lblBestSellerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblBestSellerTitle.Location = new System.Drawing.Point(10, 20);
            this.lblBestSellerTitle.Name = "lblBestSellerTitle";
            this.lblBestSellerTitle.Size = new System.Drawing.Size(161, 17);
            this.lblBestSellerTitle.TabIndex = 0;
            this.lblBestSellerTitle.Text = "Mặt hàng bán chạy nhất";
            // 
            // lblBestSeller
            // 
            this.lblBestSeller.AutoSize = true;
            this.lblBestSeller.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblBestSeller.Location = new System.Drawing.Point(10, 60);
            this.lblBestSeller.Name = "lblBestSeller";
            this.lblBestSeller.Size = new System.Drawing.Size(117, 24);
            this.lblBestSeller.TabIndex = 1;
            this.lblBestSeller.Text = "Chưa có dữ liệu";
            // 
            // FormQuickReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.dtpReportDate);
            this.Name = "FormQuickReport";
            this.Text = "Báo cáo Doanh thu & Hiệu suất";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalOrdersTitle;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalRevenueTitle;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBestSellerTitle;
        private System.Windows.Forms.Label lblBestSeller;
    }
}
