using System;
using System.Windows.Forms;
using System.Net.Http.Json;

namespace MiniSupermarketWinForms {
    public partial class FormQuickReport : Form {
        public FormQuickReport() {
            InitializeComponent();
        }

        private async void btnRunReport_Click(object sender, EventArgs e) {
            if (!string.Equals(MiniSupermarketWinForms.SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase)) {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try {
                // Call real API built in Buoi 5
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseObj = await MiniSupermarketWinForms.ApiClientService.Client.GetFromJsonAsync<ReportResponseDto>($"Reports/revenue-by-date?fromDate={dtpReportDate.Value:yyyy-MM-dd}&toDate={dtpReportDate.Value:yyyy-MM-dd}T23:59:59", options);
                
                int totalOrders = 0;
                decimal totalRevenue = 0;

                if (responseObj != null && responseObj.Data != null) {
                    foreach (var item in responseObj.Data) {
                        totalOrders += item.TotalOrders;
                        totalRevenue += item.TotalRevenue;
                    }
                }

                lblTotalOrders.Text = totalOrders.ToString();
                lblTotalRevenue.Text = totalRevenue.ToString("N0") + " đ";
                lblBestSeller.Text = "Đang cập nhật..."; // Khong co tren API revenue-by-date
                
                MessageBox.Show($"Báo cáo ngày {dtpReportDate.Value:dd/MM/yyyy} đã được tải!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class ReportDto {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }
    public class ReportResponseDto {
        public System.Collections.Generic.List<ReportDto> Data { get; set; }
    }
}
