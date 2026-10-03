/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026
 * Mo ta: FormQuickReport - Bao cao doanh thu nhanh danh cho Admin
 */
using System;
using System.Windows.Forms;

namespace MiniSupermarketWinForms {
    public partial class FormQuickReport : Form {
        public FormQuickReport() {
            InitializeComponent();
        }

        private void btnRunReport_Click(object sender, EventArgs e) {
            if (MiniSupermarketWinForms.SessionManager.CurrentRole != "Admin") {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Fake logic for report execution since the backend endpoint is not built yet
            lblTotalOrders.Text = "142";
            lblTotalRevenue.Text = "8,450,000 đ";
            lblBestSeller.Text = "Mì Hảo Hảo (120 gói)";
            
            MessageBox.Show($"Báo cáo ngày {dtpReportDate.Value:dd/MM/yyyy} đã được tải!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
