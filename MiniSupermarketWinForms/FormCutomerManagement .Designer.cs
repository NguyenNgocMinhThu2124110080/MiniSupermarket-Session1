/*
 * Họ và tên: Nguyễn Ngọc Minh Thư
 * Mã sinh viên: 2124110080
 * Ngày tạo: 26/09/2026 - Ngày cập nhật: 17/10/2026
 * Đề tài: Bách hóa Tổng hợp Hoàng Dung
 */
namespace MiniSupermarketWinForms
{
    partial class FormCustomerManagement
    {
        private System.ComponentModel.IContainer components = null;

        // Search row
        private System.Windows.Forms.Label   lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button  btnSearch;
        private System.Windows.Forms.Button  btnLoad;

        private System.Windows.Forms.GroupBox     grpList;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel        panelPaging;
        private System.Windows.Forms.Button       btnPrev;
        private System.Windows.Forms.Label        lblPaging;
        private System.Windows.Forms.Button       btnNext;

        // GroupBox thong tin
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label    lblCustomerId;
        private System.Windows.Forms.Label    lblCustomerName;
        private System.Windows.Forms.Label    lblPhoneNumber;
        private System.Windows.Forms.Label    lblAddress;
        private System.Windows.Forms.Label    lblRewardPoints;
        private System.Windows.Forms.Label    lblMembershipRank;
        private System.Windows.Forms.TextBox  txtCustomerId;
        private System.Windows.Forms.TextBox  txtCustomerName;
        private System.Windows.Forms.TextBox  txtPhoneNumber;
        private System.Windows.Forms.TextBox  txtAddress;
        private System.Windows.Forms.TextBox  txtRewardPoints;
        private System.Windows.Forms.TextBox  txtMembershipRank;
        private System.Windows.Forms.Button   btnAdd;
        private System.Windows.Forms.Button   btnUpdate;
        private System.Windows.Forms.Button   btnDelete;
        private System.Windows.Forms.Button   btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components        = new System.ComponentModel.Container();
            this.lblSearch         = new System.Windows.Forms.Label();
            this.txtSearch         = new System.Windows.Forms.TextBox();
            this.btnSearch         = new System.Windows.Forms.Button();
            this.btnLoad           = new System.Windows.Forms.Button();
            this.panelPaging       = new System.Windows.Forms.Panel();
            this.btnPrev           = new System.Windows.Forms.Button();
            this.lblPaging         = new System.Windows.Forms.Label();
            this.btnNext           = new System.Windows.Forms.Button();
            this.grpList           = new System.Windows.Forms.GroupBox();
            this.dgvCustomers      = new System.Windows.Forms.DataGridView();
            this.grpDetail         = new System.Windows.Forms.GroupBox();
            this.lblCustomerId     = new System.Windows.Forms.Label();
            this.lblCustomerName   = new System.Windows.Forms.Label();
            this.lblPhoneNumber    = new System.Windows.Forms.Label();
            this.lblAddress        = new System.Windows.Forms.Label();
            this.lblRewardPoints   = new System.Windows.Forms.Label();
            this.lblMembershipRank = new System.Windows.Forms.Label();
            this.txtCustomerId     = new System.Windows.Forms.TextBox();
            this.txtCustomerName   = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber    = new System.Windows.Forms.TextBox();
            this.txtAddress        = new System.Windows.Forms.TextBox();
            this.txtRewardPoints   = new System.Windows.Forms.TextBox();
            this.txtMembershipRank = new System.Windows.Forms.TextBox();
            this.btnAdd            = new System.Windows.Forms.Button();
            this.btnUpdate         = new System.Windows.Forms.Button();
            this.btnDelete         = new System.Windows.Forms.Button();
            this.btnClear          = new System.Windows.Forms.Button();

            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.SuspendLayout();

            // =====================================================
            // FORM
            // =====================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1050, 500);
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Quản lý Khách hàng";
            this.Load               += new System.EventHandler(this.FormCustomerManagement_Load);

            // =====================================================
            // SEARCH ROW: label | txtSearch | btnSearch | btnLoad
            // =====================================================
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(14, 16);
            this.lblSearch.Text     = "Tìm kiếm";

            this.txtSearch.Location = new System.Drawing.Point(78, 13);
            this.txtSearch.Size     = new System.Drawing.Size(260, 20);
            this.txtSearch.Name     = "txtSearch";

            this.btnSearch.Location              = new System.Drawing.Point(346, 11);
            this.btnSearch.Size                  = new System.Drawing.Size(75, 23);
            this.btnSearch.Text                  = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click                += new System.EventHandler(this.btnSearch_Click);

            this.btnLoad.Location              = new System.Drawing.Point(429, 11);
            this.btnLoad.Size                  = new System.Drawing.Size(75, 23);
            this.btnLoad.Text                  = "Tải lại";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click                += new System.EventHandler(this.btnLoad_Click);

            // =====================================================
            // GROUP BOX 1: DANH SACH (trai, rong)
            // =====================================================
            this.grpList.Location = new System.Drawing.Point(14, 42);
            this.grpList.Size     = new System.Drawing.Size(680, 445);
            this.grpList.Text     = "Danh sách khách hàng";
            this.grpList.Controls.Add(this.dgvCustomers);
            this.grpList.Controls.Add(this.panelPaging);

            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 16);
            this.dgvCustomers.Size = new System.Drawing.Size(674, 385);
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.Name = "dgvCustomers";

            // panelPaging
            this.panelPaging.Controls.Add(this.btnNext);
            this.panelPaging.Controls.Add(this.lblPaging);
            this.panelPaging.Controls.Add(this.btnPrev);
            this.panelPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPaging.Location = new System.Drawing.Point(3, 403);
            this.panelPaging.Name = "panelPaging";
            this.panelPaging.Size = new System.Drawing.Size(674, 39);
            this.panelPaging.TabIndex = 2;
            this.panelPaging.BringToFront();

            // btnPrev
            this.btnPrev.Location = new System.Drawing.Point(10, 6);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(110, 28);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<< Trang trước";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            // lblPaging
            this.lblPaging.AutoSize = true;
            this.lblPaging.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPaging.Location = new System.Drawing.Point(135, 11);
            this.lblPaging.Name = "lblPaging";
            this.lblPaging.Size = new System.Drawing.Size(160, 17);
            this.lblPaging.TabIndex = 1;
            this.lblPaging.Text = "Trang 1 / 1 (Tổng: 0 KH)";

            // btnNext
            this.btnNext.Location = new System.Drawing.Point(315, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(110, 28);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Trang sau >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            var colId = new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "CustomerId", HeaderText = "Mã KH", FillWeight = 9 };
            var colName = new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "CustomerName", HeaderText = "Tên khách hàng", FillWeight = 26 };
            var colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "PhoneNumber", HeaderText = "Số điện thoại", FillWeight = 16 };
            var colAddr = new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Address", HeaderText = "Địa chỉ", FillWeight = 29 };
            var colPoints = new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "RewardPoints", HeaderText = "Điểm tích lũy", FillWeight = 10 };
            var colRank = new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "MembershipRank", HeaderText = "Hạng thành viên", FillWeight = 14 };

            colId.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colPhone.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colPoints.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            colRank.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colId, colName, colPhone, colAddr, colPoints, colRank
            });

            this.dgvCustomers.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);

            // =====================================================
            // GROUP BOX 2: THONG TIN (phai)
            // =====================================================
            this.grpDetail.Location = new System.Drawing.Point(702, 42);
            this.grpDetail.Size     = new System.Drawing.Size(300, 445);
            this.grpDetail.Text     = "Thông tin Khách hàng";

            // Stacked vertical layout
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(18, 22);
            this.lblCustomerId.Text     = "Mã KH:";
            this.txtCustomerId.Location = new System.Drawing.Point(18, 40);
            this.txtCustomerId.Size     = new System.Drawing.Size(260, 22);
            this.txtCustomerId.ReadOnly = true;

            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(18, 68);
            this.lblCustomerName.Text     = "Tên khách hàng:";
            this.txtCustomerName.Location = new System.Drawing.Point(18, 86);
            this.txtCustomerName.Size     = new System.Drawing.Size(260, 22);

            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(18, 114);
            this.lblPhoneNumber.Text     = "Số điện thoại:";
            this.txtPhoneNumber.Location = new System.Drawing.Point(18, 132);
            this.txtPhoneNumber.Size     = new System.Drawing.Size(260, 22);

            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(18, 160);
            this.lblAddress.Text     = "Địa chỉ:";
            this.txtAddress.Location = new System.Drawing.Point(18, 178);
            this.txtAddress.Size     = new System.Drawing.Size(260, 22);

            this.lblRewardPoints.AutoSize = true;
            this.lblRewardPoints.Location = new System.Drawing.Point(18, 206);
            this.lblRewardPoints.Text     = "Điểm tích lũy:";
            this.txtRewardPoints.Location = new System.Drawing.Point(18, 224);
            this.txtRewardPoints.Size     = new System.Drawing.Size(260, 22);

            this.lblMembershipRank.AutoSize = true;
            this.lblMembershipRank.Location = new System.Drawing.Point(18, 252);
            this.lblMembershipRank.Text     = "Hạng thành viên:";
            this.txtMembershipRank.Location = new System.Drawing.Point(18, 270);
            this.txtMembershipRank.Size     = new System.Drawing.Size(260, 22);

            // 4 Styled Buttons
            this.btnAdd.Location               = new System.Drawing.Point(18, 316);
            this.btnAdd.Size                   = new System.Drawing.Size(125, 34);
            this.btnAdd.Text                   = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click                 += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location               = new System.Drawing.Point(153, 316);
            this.btnUpdate.Size                   = new System.Drawing.Size(125, 34);
            this.btnUpdate.Text                   = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click                 += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location               = new System.Drawing.Point(18, 360);
            this.btnDelete.Size                   = new System.Drawing.Size(125, 34);
            this.btnDelete.Text                   = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click                 += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location                = new System.Drawing.Point(153, 360);
            this.btnClear.Size                    = new System.Drawing.Size(125, 34);
            this.btnClear.Text                    = "Làm mới";
            this.btnClear.UseVisualStyleBackColor  = true;
            this.btnClear.Click                  += new System.EventHandler(this.btnClear_Click);

            // Them vao grpDetail
            this.grpDetail.Controls.Add(this.lblCustomerId);
            this.grpDetail.Controls.Add(this.txtCustomerId);
            this.grpDetail.Controls.Add(this.lblCustomerName);
            this.grpDetail.Controls.Add(this.txtCustomerName);
            this.grpDetail.Controls.Add(this.lblPhoneNumber);
            this.grpDetail.Controls.Add(this.txtPhoneNumber);
            this.grpDetail.Controls.Add(this.lblAddress);
            this.grpDetail.Controls.Add(this.txtAddress);
            this.grpDetail.Controls.Add(this.lblRewardPoints);
            this.grpDetail.Controls.Add(this.txtRewardPoints);
            this.grpDetail.Controls.Add(this.lblMembershipRank);
            this.grpDetail.Controls.Add(this.txtMembershipRank);
            this.grpDetail.Controls.Add(this.btnAdd);
            this.grpDetail.Controls.Add(this.btnUpdate);
            this.grpDetail.Controls.Add(this.btnDelete);
            this.grpDetail.Controls.Add(this.btnClear);

            // =====================================================
            // THEM VAO FORM
            // =====================================================
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpDetail);

            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}