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

        // GroupBox danh sach
        private System.Windows.Forms.GroupBox     grpList;
        private System.Windows.Forms.DataGridView dgvCustomers;

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

            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 16);
            this.dgvCustomers.Size = new System.Drawing.Size(674, 426);
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.Name = "dgvCustomers";

            this.dgvCustomers.Columns.Add("CustomerId",     "Mã KH");
            this.dgvCustomers.Columns.Add("CustomerName",   "Tên khách hàng");
            this.dgvCustomers.Columns.Add("PhoneNumber",    "Số điện thoại");
            this.dgvCustomers.Columns.Add("Address",        "Địa chỉ");
            this.dgvCustomers.Columns.Add("RewardPoints",   "Điểm tích lũy");
            this.dgvCustomers.Columns.Add("MembershipRank", "Hạng thành viên");

            this.dgvCustomers.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);

            // =====================================================
            // GROUP BOX 2: THONG TIN (phai)
            // =====================================================
            this.grpDetail.Location = new System.Drawing.Point(702, 42);
            this.grpDetail.Size     = new System.Drawing.Size(334, 445);
            this.grpDetail.Text     = "Thông tin Khách hàng";

            int labelX = 10, inputX = 120, inputW = 195, rowH = 32;

            // Ma KH
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(labelX, 25);
            this.lblCustomerId.Text     = "Mã KH";
            this.txtCustomerId.Location = new System.Drawing.Point(inputX, 22);
            this.txtCustomerId.Size     = new System.Drawing.Size(inputW, 20);
            this.txtCustomerId.ReadOnly = true;

            // Ten
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(labelX, 25 + rowH);
            this.lblCustomerName.Text     = "Tên khách hàng";
            this.txtCustomerName.Location = new System.Drawing.Point(inputX, 22 + rowH);
            this.txtCustomerName.Size     = new System.Drawing.Size(inputW, 20);

            // SDT
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(labelX, 25 + rowH * 2);
            this.lblPhoneNumber.Text     = "Số điện thoại";
            this.txtPhoneNumber.Location = new System.Drawing.Point(inputX, 22 + rowH * 2);
            this.txtPhoneNumber.Size     = new System.Drawing.Size(inputW, 20);

            // Dia chi
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(labelX, 25 + rowH * 3);
            this.lblAddress.Text     = "Địa chỉ";
            this.txtAddress.Location = new System.Drawing.Point(inputX, 22 + rowH * 3);
            this.txtAddress.Size     = new System.Drawing.Size(inputW, 20);

            // Diem
            this.lblRewardPoints.AutoSize = true;
            this.lblRewardPoints.Location = new System.Drawing.Point(labelX, 25 + rowH * 4);
            this.lblRewardPoints.Text     = "Điểm tích lũy";
            this.txtRewardPoints.Location = new System.Drawing.Point(inputX, 22 + rowH * 4);
            this.txtRewardPoints.Size     = new System.Drawing.Size(inputW, 20);

            // Hang
            this.lblMembershipRank.AutoSize = true;
            this.lblMembershipRank.Location = new System.Drawing.Point(labelX, 25 + rowH * 5);
            this.lblMembershipRank.Text     = "Hạng thành viên";
            this.txtMembershipRank.Location = new System.Drawing.Point(inputX, 22 + rowH * 5);
            this.txtMembershipRank.Size     = new System.Drawing.Size(inputW, 20);

            // Nut hanh dong
            int btnY = 22 + rowH * 6 + 10;

            this.btnAdd.Location               = new System.Drawing.Point(10,  btnY);
            this.btnAdd.Size                   = new System.Drawing.Size(90, 26);
            this.btnAdd.Text                   = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click                 += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location               = new System.Drawing.Point(108, btnY);
            this.btnUpdate.Size                   = new System.Drawing.Size(90, 26);
            this.btnUpdate.Text                   = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click                 += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location               = new System.Drawing.Point(206, btnY);
            this.btnDelete.Size                   = new System.Drawing.Size(90, 26);
            this.btnDelete.Text                   = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click                 += new System.EventHandler(this.btnDelete_Click);

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