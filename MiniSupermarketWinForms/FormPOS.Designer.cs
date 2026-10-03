/*
 * Ten: Nguyen Ngoc Minh Thu
 * Masv: 2124110080
 * Ngay tao: 03/10/2026
 * Mo ta: Giao dien Designer cho Man hinh POS (Ban hang)
 */
namespace MiniSupermarketWinForms
{
    partial class FormPOS
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
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblBarcodeTitle = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.lblCustomerNameTitle = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblCashReceivedTitle = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.lblChangeTitle = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtBarcode.Location = new System.Drawing.Point(120, 15);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(300, 29);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // lblBarcodeTitle
            // 
            this.lblBarcodeTitle.AutoSize = true;
            this.lblBarcodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblBarcodeTitle.Location = new System.Drawing.Point(10, 20);
            this.lblBarcodeTitle.Name = "lblBarcodeTitle";
            this.lblBarcodeTitle.Size = new System.Drawing.Size(104, 20);
            this.lblBarcodeTitle.TabIndex = 1;
            this.lblBarcodeTitle.Text = "Quét mã SP:";
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(10, 60);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.Size = new System.Drawing.Size(650, 520);
            this.dgvCart.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblBarcodeTitle);
            this.panelLeft.Controls.Add(this.txtBarcode);
            this.panelLeft.Controls.Add(this.dgvCart);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(680, 600);
            this.panelLeft.TabIndex = 3;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelRight.Controls.Add(this.lblCustomerPhone);
            this.panelRight.Controls.Add(this.txtCustomerPhone);
            this.panelRight.Controls.Add(this.lblCustomerNameTitle);
            this.panelRight.Controls.Add(this.lblCustomerName);
            this.panelRight.Controls.Add(this.lblTotalTitle);
            this.panelRight.Controls.Add(this.lblTotalAmount);
            this.panelRight.Controls.Add(this.lblCashReceivedTitle);
            this.panelRight.Controls.Add(this.txtCashReceived);
            this.panelRight.Controls.Add(this.lblChangeTitle);
            this.panelRight.Controls.Add(this.lblChange);
            this.panelRight.Controls.Add(this.btnCheckout);
            this.panelRight.Controls.Add(this.btnClearCart);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(680, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(320, 600);
            this.panelRight.TabIndex = 4;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(20, 30);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(95, 13);
            this.lblCustomerPhone.TabIndex = 0;
            this.lblCustomerPhone.Text = "SĐT Khách Hàng:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(120, 27);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(180, 20);
            this.txtCustomerPhone.TabIndex = 1;
            // 
            // lblCustomerNameTitle
            // 
            this.lblCustomerNameTitle.AutoSize = true;
            this.lblCustomerNameTitle.Location = new System.Drawing.Point(20, 70);
            this.lblCustomerNameTitle.Name = "lblCustomerNameTitle";
            this.lblCustomerNameTitle.Size = new System.Drawing.Size(92, 13);
            this.lblCustomerNameTitle.TabIndex = 2;
            this.lblCustomerNameTitle.Text = "Tên Khách Hàng:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.Location = new System.Drawing.Point(120, 70);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(102, 15);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Khách vãng lai";
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.Location = new System.Drawing.Point(20, 130);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(117, 24);
            this.lblTotalTitle.TabIndex = 4;
            this.lblTotalTitle.Text = "Tổng Tiền:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 160);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(65, 37);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "0 đ";
            // 
            // lblCashReceivedTitle
            // 
            this.lblCashReceivedTitle.AutoSize = true;
            this.lblCashReceivedTitle.Location = new System.Drawing.Point(20, 230);
            this.lblCashReceivedTitle.Name = "lblCashReceivedTitle";
            this.lblCashReceivedTitle.Size = new System.Drawing.Size(89, 13);
            this.lblCashReceivedTitle.TabIndex = 6;
            this.lblCashReceivedTitle.Text = "Tiền Khách Đưa:";
            // 
            // txtCashReceived
            // 
            this.txtCashReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCashReceived.Location = new System.Drawing.Point(120, 222);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(180, 26);
            this.txtCashReceived.TabIndex = 7;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);
            // 
            // lblChangeTitle
            // 
            this.lblChangeTitle.AutoSize = true;
            this.lblChangeTitle.Location = new System.Drawing.Point(20, 280);
            this.lblChangeTitle.Name = "lblChangeTitle";
            this.lblChangeTitle.Size = new System.Drawing.Size(59, 13);
            this.lblChangeTitle.TabIndex = 8;
            this.lblChangeTitle.Text = "Tiền Thừa:";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblChange.Location = new System.Drawing.Point(120, 272);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(38, 24);
            this.lblChange.TabIndex = 9;
            this.lblChange.Text = "0 đ";
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(20, 340);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(280, 60);
            this.btnCheckout.TabIndex = 10;
            this.btnCheckout.Text = "THANH TOÁN (F9)";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnClearCart
            // 
            this.btnClearCart.BackColor = System.Drawing.Color.IndianRed;
            this.btnClearCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(20, 420);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(280, 40);
            this.btnClearCart.TabIndex = 11;
            this.btnClearCart.Text = "HỦY GIỎ HÀNG";
            this.btnClearCart.UseVisualStyleBackColor = false;
            // 
            // FormPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "FormPOS";
            this.Text = "Hệ thống Quầy Thu Ngân POS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblBarcodeTitle;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label lblCustomerNameTitle;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblCashReceivedTitle;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.Label lblChangeTitle;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClearCart;
    }
}
