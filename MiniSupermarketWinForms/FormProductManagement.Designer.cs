namespace MiniSupermarketWinForms
{
    partial class FormProductManagement
    {
        private System.ComponentModel.IContainer components = null;

        // Search + Filter row
        private System.Windows.Forms.Label    lblSearch;
        private System.Windows.Forms.TextBox  txtSearch;
        private System.Windows.Forms.Button   btnSearch;
        private System.Windows.Forms.Button   btnLoad;
        private System.Windows.Forms.Label    lblFilterCategory;
        private System.Windows.Forms.ComboBox cboFilterCategory;

        // GroupBox danh sach
        private System.Windows.Forms.GroupBox     grpList;
        private System.Windows.Forms.DataGridView dgvProducts;

        // GroupBox thong tin
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label    lblProductId;
        private System.Windows.Forms.Label    lblBarcode;
        private System.Windows.Forms.Label    lblProductName;
        private System.Windows.Forms.Label    lblPrice;
        private System.Windows.Forms.Label    lblStockQuantity;
        private System.Windows.Forms.Label    lblCategory;
        private System.Windows.Forms.TextBox  txtProductId;
        private System.Windows.Forms.TextBox  txtBarcode;
        private System.Windows.Forms.TextBox  txtProductName;
        private System.Windows.Forms.TextBox  txtPrice;
        private System.Windows.Forms.TextBox  txtStockQuantity;
        private System.Windows.Forms.ComboBox cboCategory;
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
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.grpList           = new System.Windows.Forms.GroupBox();
            this.dgvProducts       = new System.Windows.Forms.DataGridView();
            this.grpDetail         = new System.Windows.Forms.GroupBox();
            this.lblProductId      = new System.Windows.Forms.Label();
            this.lblBarcode        = new System.Windows.Forms.Label();
            this.lblProductName    = new System.Windows.Forms.Label();
            this.lblPrice          = new System.Windows.Forms.Label();
            this.lblStockQuantity  = new System.Windows.Forms.Label();
            this.lblCategory       = new System.Windows.Forms.Label();
            this.txtProductId      = new System.Windows.Forms.TextBox();
            this.txtBarcode        = new System.Windows.Forms.TextBox();
            this.txtProductName    = new System.Windows.Forms.TextBox();
            this.txtPrice          = new System.Windows.Forms.TextBox();
            this.txtStockQuantity  = new System.Windows.Forms.TextBox();
            this.cboCategory       = new System.Windows.Forms.ComboBox();
            this.btnAdd            = new System.Windows.Forms.Button();
            this.btnUpdate         = new System.Windows.Forms.Button();
            this.btnDelete         = new System.Windows.Forms.Button();

            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.SuspendLayout();

            // =====================================================
            // FORM
            // =====================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1100, 560);
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Quản lý Sản phẩm";
            this.Load               += new System.EventHandler(this.FormProductManagement_Load);

            // =====================================================
            // SEARCH + FILTER ROW
            // =====================================================
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(14, 16);
            this.lblSearch.Text     = "Tìm kiếm:";

            this.txtSearch.Location = new System.Drawing.Point(75, 13);
            this.txtSearch.Size     = new System.Drawing.Size(220, 20);
            this.txtSearch.Name     = "txtSearch";

            this.btnSearch.Location              = new System.Drawing.Point(303, 11);
            this.btnSearch.Size                  = new System.Drawing.Size(75, 23);
            this.btnSearch.Text                  = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click                += new System.EventHandler(this.btnSearch_Click);

            this.btnLoad.Location              = new System.Drawing.Point(386, 11);
            this.btnLoad.Size                  = new System.Drawing.Size(75, 23);
            this.btnLoad.Text                  = "Tải lại";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click                += new System.EventHandler(this.btnLoad_Click);

            this.lblFilterCategory.AutoSize = true;
            this.lblFilterCategory.Location = new System.Drawing.Point(480, 16);
            this.lblFilterCategory.Text     = "Lọc danh mục:";

            this.cboFilterCategory.Location             = new System.Drawing.Point(568, 13);
            this.cboFilterCategory.Size                 = new System.Drawing.Size(200, 21);
            this.cboFilterCategory.DropDownStyle        = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Name                 = "cboFilterCategory";
            this.cboFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cboFilterCategory_SelectedIndexChanged);

            // =====================================================
            // GROUP BOX 1: DANH SACH (trai, rong)
            // =====================================================
            this.grpList.Location = new System.Drawing.Point(14, 44);
            this.grpList.Size     = new System.Drawing.Size(720, 500);
            this.grpList.Text     = "Danh sách sản phẩm";
            this.grpList.Controls.Add(this.dgvProducts);

            this.dgvProducts.AllowUserToAddRows             = false;
            this.dgvProducts.ReadOnly                       = true;
            this.dgvProducts.SelectionMode                  = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.ColumnHeadersHeightSizeMode    = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.AutoSizeColumnsMode            = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.RowTemplate.Height             = 24;
            this.dgvProducts.Location                       = new System.Drawing.Point(3, 16);
            this.dgvProducts.Size                           = new System.Drawing.Size(714, 481);
            this.dgvProducts.Anchor                         = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.Name = "dgvProducts";

            this.dgvProducts.Columns.Add("ProductId",     "Mã SP");
            this.dgvProducts.Columns.Add("Barcode",       "Mã vạch");
            this.dgvProducts.Columns.Add("ProductName",   "Tên sản phẩm");
            this.dgvProducts.Columns.Add("Price",         "Giá bán");
            this.dgvProducts.Columns.Add("StockQuantity", "Tồn kho");
            this.dgvProducts.Columns.Add("CategoryId",    "Mã DM");
            this.dgvProducts.Columns.Add("CategoryName",  "Danh mục");

            // An cot CategoryId
            this.dgvProducts.Columns["CategoryId"].Visible = false;

            this.dgvProducts.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);

            // =====================================================
            // GROUP BOX 2: THONG TIN (phai)
            // =====================================================
            this.grpDetail.Location = new System.Drawing.Point(742, 44);
            this.grpDetail.Size     = new System.Drawing.Size(342, 500);
            this.grpDetail.Text     = "Thông tin Sản phẩm";

            int labelX = 10, inputX = 120, inputW = 205, rowH = 34;

            // Ma SP
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(labelX, 25);
            this.lblProductId.Text     = "Mã sản phẩm";
            this.txtProductId.Location = new System.Drawing.Point(inputX, 22);
            this.txtProductId.Size     = new System.Drawing.Size(inputW, 20);
            this.txtProductId.ReadOnly = true;
            this.txtProductId.Name     = "txtProductId";

            // Ma vach
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(labelX, 25 + rowH);
            this.lblBarcode.Text     = "Mã vạch";
            this.txtBarcode.Location = new System.Drawing.Point(inputX, 22 + rowH);
            this.txtBarcode.Size     = new System.Drawing.Size(inputW, 20);
            this.txtBarcode.Name     = "txtBarcode";

            // Ten san pham
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(labelX, 25 + rowH * 2);
            this.lblProductName.Text     = "Tên sản phẩm";
            this.txtProductName.Location = new System.Drawing.Point(inputX, 22 + rowH * 2);
            this.txtProductName.Size     = new System.Drawing.Size(inputW, 20);
            this.txtProductName.Name     = "txtProductName";

            // Gia ban
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(labelX, 25 + rowH * 3);
            this.lblPrice.Text     = "Giá bán (đ)";
            this.txtPrice.Location = new System.Drawing.Point(inputX, 22 + rowH * 3);
            this.txtPrice.Size     = new System.Drawing.Size(inputW, 20);
            this.txtPrice.Name     = "txtPrice";

            // Ton kho
            this.lblStockQuantity.AutoSize = true;
            this.lblStockQuantity.Location = new System.Drawing.Point(labelX, 25 + rowH * 4);
            this.lblStockQuantity.Text     = "Tồn kho";
            this.txtStockQuantity.Location = new System.Drawing.Point(inputX, 22 + rowH * 4);
            this.txtStockQuantity.Size     = new System.Drawing.Size(inputW, 20);
            this.txtStockQuantity.Name     = "txtStockQuantity";

            // Danh muc (ComboBox)
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(labelX, 25 + rowH * 5);
            this.lblCategory.Text     = "Danh mục";
            this.cboCategory.Location      = new System.Drawing.Point(inputX, 22 + rowH * 5);
            this.cboCategory.Size          = new System.Drawing.Size(inputW, 21);
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Name          = "cboCategory";

            // Nut hanh dong
            int btnY = 22 + rowH * 6 + 12;

            this.btnAdd.Location               = new System.Drawing.Point(10, btnY);
            this.btnAdd.Size                   = new System.Drawing.Size(90, 28);
            this.btnAdd.Text                   = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click                 += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location               = new System.Drawing.Point(108, btnY);
            this.btnUpdate.Size                   = new System.Drawing.Size(90, 28);
            this.btnUpdate.Text                   = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click                 += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location               = new System.Drawing.Point(206, btnY);
            this.btnDelete.Size                   = new System.Drawing.Size(90, 28);
            this.btnDelete.Text                   = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click                 += new System.EventHandler(this.btnDelete_Click);

            // Them vao grpDetail
            this.grpDetail.Controls.Add(this.lblProductId);
            this.grpDetail.Controls.Add(this.txtProductId);
            this.grpDetail.Controls.Add(this.lblBarcode);
            this.grpDetail.Controls.Add(this.txtBarcode);
            this.grpDetail.Controls.Add(this.lblProductName);
            this.grpDetail.Controls.Add(this.txtProductName);
            this.grpDetail.Controls.Add(this.lblPrice);
            this.grpDetail.Controls.Add(this.txtPrice);
            this.grpDetail.Controls.Add(this.lblStockQuantity);
            this.grpDetail.Controls.Add(this.txtStockQuantity);
            this.grpDetail.Controls.Add(this.lblCategory);
            this.grpDetail.Controls.Add(this.cboCategory);
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
            this.Controls.Add(this.lblFilterCategory);
            this.Controls.Add(this.cboFilterCategory);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpDetail);

            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
