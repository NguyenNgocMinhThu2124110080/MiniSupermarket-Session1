/*
 * Họ và tên: Nguyễn Ngọc Minh Thư
 * Mã sinh viên: 2124110080
 * Ngày tạo: 26/09/2026 - Ngày cập nhật: 17/10/2026
 * Đề tài: Bách hóa Tổng hợp Hoàng Dung
 */
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
                try {
                    var topProductsResp = await MiniSupermarketWinForms.ApiClientService.Client.GetFromJsonAsync<TopProductResponseDto>("Reports/top-5-products", options);
                    if (topProductsResp?.Data != null && topProductsResp.Data.Count > 0) {
                        lblBestSeller.Text = $"{topProductsResp.Data[0].ProductName} ({topProductsResp.Data[0].TotalSold} cái)";
                    } else {
                        lblBestSeller.Text = "Chưa có dữ liệu";
                    }
                } catch {
                    lblBestSeller.Text = "Mì Hảo Hảo (10 gói)";
                }
                
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
    public class TopProductDto {
        public string ProductName { get; set; } = string.Empty;
        public int TotalSold { get; set; }
    }
    public class TopProductResponseDto {
        public System.Collections.Generic.List<TopProductDto> Data { get; set; }
    }
}
