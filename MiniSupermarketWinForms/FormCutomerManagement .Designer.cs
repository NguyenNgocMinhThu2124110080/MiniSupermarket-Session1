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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.panelTopSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panelPaging = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPaging = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblRewardPoints = new System.Windows.Forms.Label();
            this.txtRewardPoints = new System.Windows.Forms.TextBox();
            this.lblMembershipRank = new System.Windows.Forms.Label();
            this.txtMembershipRank = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panelTopSearch.SuspendLayout();
            this.panelPaging.SuspendLayout();
            this.grpDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpList
            // 
            this.grpList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpList.Controls.Add(this.dgvCustomers);
            this.grpList.Controls.Add(this.panelPaging);
            this.grpList.Controls.Add(this.panelTopSearch);
            this.grpList.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpList.Location = new System.Drawing.Point(12, 12);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(656, 560);
            this.grpList.TabIndex = 1;
            this.grpList.TabStop = false;
            this.grpList.Text = "Danh Sách Khách Hàng Thân Thiết";
            // 
            // panelTopSearch
            // 
            this.panelTopSearch.Controls.Add(this.btnLoad);
            this.panelTopSearch.Controls.Add(this.btnSearch);
            this.panelTopSearch.Controls.Add(this.txtSearch);
            this.panelTopSearch.Controls.Add(this.lblSearch);
            this.panelTopSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopSearch.Location = new System.Drawing.Point(3, 20);
            this.panelTopSearch.Name = "panelTopSearch";
            this.panelTopSearch.Size = new System.Drawing.Size(650, 42);
            this.panelTopSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(62, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(78, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(306, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(394, 7);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 28);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Tải lại";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 62);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.Size = new System.Drawing.Size(650, 456);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // panelPaging
            // 
            this.panelPaging.Controls.Add(this.btnNext);
            this.panelPaging.Controls.Add(this.lblPaging);
            this.panelPaging.Controls.Add(this.btnPrev);
            this.panelPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPaging.Location = new System.Drawing.Point(3, 518);
            this.panelPaging.Name = "panelPaging";
            this.panelPaging.Size = new System.Drawing.Size(650, 39);
            this.panelPaging.TabIndex = 2;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(10, 6);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(110, 28);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<< Trang trước";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblPaging
            // 
            this.lblPaging.AutoSize = true;
            this.lblPaging.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPaging.Location = new System.Drawing.Point(135, 11);
            this.lblPaging.Name = "lblPaging";
            this.lblPaging.Size = new System.Drawing.Size(155, 17);
            this.lblPaging.TabIndex = 1;
            this.lblPaging.Text = "Trang 1 / 1 (Tổng: 0 KH)";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(305, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(110, 28);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Trang sau >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // grpDetail
            // 
            this.grpDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetail.Controls.Add(this.btnClear);
            this.grpDetail.Controls.Add(this.btnDelete);
            this.grpDetail.Controls.Add(this.btnUpdate);
            this.grpDetail.Controls.Add(this.btnAdd);
            this.grpDetail.Controls.Add(this.txtMembershipRank);
            this.grpDetail.Controls.Add(this.lblMembershipRank);
            this.grpDetail.Controls.Add(this.txtRewardPoints);
            this.grpDetail.Controls.Add(this.lblRewardPoints);
            this.grpDetail.Controls.Add(this.txtAddress);
            this.grpDetail.Controls.Add(this.lblAddress);
            this.grpDetail.Controls.Add(this.txtPhoneNumber);
            this.grpDetail.Controls.Add(this.lblPhoneNumber);
            this.grpDetail.Controls.Add(this.txtCustomerName);
            this.grpDetail.Controls.Add(this.lblCustomerName);
            this.grpDetail.Controls.Add(this.txtCustomerId);
            this.grpDetail.Controls.Add(this.lblCustomerId);
            this.grpDetail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetail.Location = new System.Drawing.Point(685, 12);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(320, 560);
            this.grpDetail.TabIndex = 2;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Thông Tin Khách Hàng";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(18, 25);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(50, 17);
            this.lblCustomerId.TabIndex = 0;
            this.lblCustomerId.Text = "Mã KH:";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(20, 45);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(275, 24);
            this.txtCustomerId.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(18, 77);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(102, 17);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Tên khách hàng:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(20, 97);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(275, 24);
            this.txtCustomerName.TabIndex = 3;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(18, 129);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(88, 17);
            this.lblPhoneNumber.TabIndex = 4;
            this.lblPhoneNumber.Text = "Số điện thoại:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(20, 149);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(275, 24);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(18, 181);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(50, 17);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(20, 201);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(275, 24);
            this.txtAddress.TabIndex = 7;
            // 
            // lblRewardPoints
            // 
            this.lblRewardPoints.AutoSize = true;
            this.lblRewardPoints.Location = new System.Drawing.Point(18, 233);
            this.lblRewardPoints.Name = "lblRewardPoints";
            this.lblRewardPoints.Size = new System.Drawing.Size(87, 17);
            this.lblRewardPoints.TabIndex = 8;
            this.lblRewardPoints.Text = "Điểm tích lũy:";
            // 
            // txtRewardPoints
            // 
            this.txtRewardPoints.Location = new System.Drawing.Point(20, 253);
            this.txtRewardPoints.Name = "txtRewardPoints";
            this.txtRewardPoints.Size = new System.Drawing.Size(275, 24);
            this.txtRewardPoints.TabIndex = 9;
            // 
            // lblMembershipRank
            // 
            this.lblMembershipRank.AutoSize = true;
            this.lblMembershipRank.Location = new System.Drawing.Point(18, 285);
            this.lblMembershipRank.Name = "lblMembershipRank";
            this.lblMembershipRank.Size = new System.Drawing.Size(107, 17);
            this.lblMembershipRank.TabIndex = 10;
            this.lblMembershipRank.Text = "Hạng thành viên:";
            // 
            // txtMembershipRank
            // 
            this.txtMembershipRank.Location = new System.Drawing.Point(20, 305);
            this.txtMembershipRank.Name = "txtMembershipRank";
            this.txtMembershipRank.Size = new System.Drawing.Size(275, 24);
            this.txtMembershipRank.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 355);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 40);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(165, 355);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 40);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(20, 407);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 40);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(165, 407);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 40);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FormCustomerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 590);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormCustomerManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Khách hàng";
            this.Load += new System.EventHandler(this.FormCustomerManagement_Load);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panelTopSearch.ResumeLayout(false);
            this.panelTopSearch.PerformLayout();
            this.panelPaging.ResumeLayout(false);
            this.panelPaging.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel panelTopSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel panelPaging;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPaging;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblRewardPoints;
        private System.Windows.Forms.TextBox txtRewardPoints;
        private System.Windows.Forms.Label lblMembershipRank;
        private System.Windows.Forms.TextBox txtMembershipRank;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
    }
}
