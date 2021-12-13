namespace QLDHS
{
    partial class frm_Diem
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
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSTT = new System.Windows.Forms.TextBox();
            this.txtDiemM = new System.Windows.Forms.TextBox();
            this.cboMaHS = new System.Windows.Forms.ComboBox();
            this.cboMaMH = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiemThi = new System.Windows.Forms.TextBox();
            this.txtDiem15p = new System.Windows.Forms.TextBox();
            this.txtDiem45p = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.cboMaHK = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboMaHL = new System.Windows.Forms.ComboBox();
            this.cboMaHM = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDiem
            // 
            this.dgvDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDiem.Location = new System.Drawing.Point(0, 480);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.RowTemplate.Height = 28;
            this.dgvDiem.Size = new System.Drawing.Size(953, 188);
            this.dgvDiem.TabIndex = 0;
            this.dgvDiem.Click += new System.EventHandler(this.dgvDiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(586, 411);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 44);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(470, 411);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 44);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(354, 411);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 44);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(238, 411);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 44);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "STT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã HS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "MãMH:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(479, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 29);
            this.label4.TabIndex = 16;
            this.label4.Text = "Điểm miệng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Điểm 15p:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Điểm 45p:";
            // 
            // txtSTT
            // 
            this.txtSTT.Location = new System.Drawing.Point(115, 69);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Size = new System.Drawing.Size(295, 36);
            this.txtSTT.TabIndex = 19;
            this.txtSTT.TextChanged += new System.EventHandler(this.txtSTT_TextChanged);
            this.txtSTT.Leave += new System.EventHandler(this.txtSTT_Leave);
            // 
            // txtDiemM
            // 
            this.txtDiemM.Location = new System.Drawing.Point(622, 69);
            this.txtDiemM.Name = "txtDiemM";
            this.txtDiemM.Size = new System.Drawing.Size(298, 36);
            this.txtDiemM.TabIndex = 22;
            this.txtDiemM.TextChanged += new System.EventHandler(this.txtDiemM_TextChanged);
            // 
            // cboMaHS
            // 
            this.cboMaHS.FormattingEnabled = true;
            this.cboMaHS.Location = new System.Drawing.Point(115, 125);
            this.cboMaHS.Name = "cboMaHS";
            this.cboMaHS.Size = new System.Drawing.Size(295, 37);
            this.cboMaHS.TabIndex = 23;
            // 
            // cboMaMH
            // 
            this.cboMaMH.FormattingEnabled = true;
            this.cboMaMH.Location = new System.Drawing.Point(115, 184);
            this.cboMaMH.Name = "cboMaMH";
            this.cboMaMH.Size = new System.Drawing.Size(295, 37);
            this.cboMaMH.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(479, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "Điểm thi:";
            // 
            // txtDiemThi
            // 
            this.txtDiemThi.Location = new System.Drawing.Point(622, 244);
            this.txtDiemThi.Name = "txtDiemThi";
            this.txtDiemThi.Size = new System.Drawing.Size(298, 36);
            this.txtDiemThi.TabIndex = 26;
            this.txtDiemThi.TextChanged += new System.EventHandler(this.txtDiemThi_TextChanged);
            // 
            // txtDiem15p
            // 
            this.txtDiem15p.Location = new System.Drawing.Point(622, 121);
            this.txtDiem15p.Name = "txtDiem15p";
            this.txtDiem15p.Size = new System.Drawing.Size(298, 36);
            this.txtDiem15p.TabIndex = 27;
            this.txtDiem15p.TextChanged += new System.EventHandler(this.txtDiem15p_TextChanged);
            // 
            // txtDiem45p
            // 
            this.txtDiem45p.Location = new System.Drawing.Point(622, 180);
            this.txtDiem45p.Name = "txtDiem45p";
            this.txtDiem45p.Size = new System.Drawing.Size(298, 36);
            this.txtDiem45p.TabIndex = 28;
            this.txtDiem45p.TextChanged += new System.EventHandler(this.txtDiem45p_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(316, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(324, 48);
            this.label8.TabIndex = 29;
            this.label8.Text = "QUẢN LÝ ĐIỂM";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 29);
            this.label9.TabIndex = 30;
            this.label9.Text = "Mã HK:";
            // 
            // cboMaHK
            // 
            this.cboMaHK.FormattingEnabled = true;
            this.cboMaHK.Location = new System.Drawing.Point(115, 247);
            this.cboMaHK.Name = "cboMaHK";
            this.cboMaHK.Size = new System.Drawing.Size(295, 37);
            this.cboMaHK.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 304);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 29);
            this.label10.TabIndex = 34;
            this.label10.Text = "Mã HL:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 349);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 29);
            this.label11.TabIndex = 35;
            this.label11.Text = "Mã HM:";
            // 
            // cboMaHL
            // 
            this.cboMaHL.FormattingEnabled = true;
            this.cboMaHL.Location = new System.Drawing.Point(115, 301);
            this.cboMaHL.Name = "cboMaHL";
            this.cboMaHL.Size = new System.Drawing.Size(295, 37);
            this.cboMaHL.TabIndex = 36;
            // 
            // cboMaHM
            // 
            this.cboMaHM.FormattingEnabled = true;
            this.cboMaHM.Location = new System.Drawing.Point(115, 346);
            this.cboMaHM.Name = "cboMaHM";
            this.cboMaHM.Size = new System.Drawing.Size(295, 37);
            this.cboMaHM.TabIndex = 37;
            // 
            // frm_Diem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 668);
            this.Controls.Add(this.cboMaHM);
            this.Controls.Add(this.cboMaHL);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboMaHK);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDiem45p);
            this.Controls.Add(this.txtDiem15p);
            this.Controls.Add(this.txtDiemThi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboMaMH);
            this.Controls.Add(this.cboMaHS);
            this.Controls.Add(this.txtDiemM);
            this.Controls.Add(this.txtSTT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvDiem);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Diem";
            this.Text = "frm_Diem";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Diem_FormClosing);
            this.Load += new System.EventHandler(this.frm_Diem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSTT;
        private System.Windows.Forms.TextBox txtDiemM;
        private System.Windows.Forms.ComboBox cboMaHS;
        private System.Windows.Forms.ComboBox cboMaMH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiemThi;
        private System.Windows.Forms.TextBox txtDiem15p;
        private System.Windows.Forms.TextBox txtDiem45p;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboMaHK;
        private System.Windows.Forms.ComboBox cboMaHM;
        private System.Windows.Forms.ComboBox cboMaHL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}