﻿namespace QLDHS
{
    partial class frm_KhoiLop
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
            this.dgvKhoiLop = new System.Windows.Forms.DataGridView();
            this.txtMaKL = new System.Windows.Forms.TextBox();
            this.txtTenKL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoiLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKhoiLop
            // 
            this.dgvKhoiLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoiLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoiLop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvKhoiLop.Location = new System.Drawing.Point(0, 404);
            this.dgvKhoiLop.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dgvKhoiLop.Name = "dgvKhoiLop";
            this.dgvKhoiLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoiLop.Size = new System.Drawing.Size(1088, 270);
            this.dgvKhoiLop.TabIndex = 0;
            this.dgvKhoiLop.Click += new System.EventHandler(this.dgvKhoiLop_Click);
            // 
            // txtMaKL
            // 
            this.txtMaKL.Location = new System.Drawing.Point(417, 120);
            this.txtMaKL.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtMaKL.Name = "txtMaKL";
            this.txtMaKL.Size = new System.Drawing.Size(278, 36);
            this.txtMaKL.TabIndex = 1;
            this.txtMaKL.Leave += new System.EventHandler(this.txtMaKL_Leave);
            // 
            // txtTenKL
            // 
            this.txtTenKL.Location = new System.Drawing.Point(417, 197);
            this.txtTenKL.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtTenKL.Name = "txtTenKL";
            this.txtTenKL.Size = new System.Drawing.Size(278, 36);
            this.txtTenKL.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(326, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "QUẢN LÝ KHỐI LỚP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(275, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "MÃ KL :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(275, 200);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "TÊN KL :";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(163, 290);
            this.btnThem.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(162, 51);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "&Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(349, 290);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(162, 51);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "&Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(524, 290);
            this.btnSua.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(162, 51);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "&Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(700, 290);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(162, 51);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frm_KhoiLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(1088, 674);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenKL);
            this.Controls.Add(this.txtMaKL);
            this.Controls.Add(this.dgvKhoiLop);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MinimumSize = new System.Drawing.Size(762, 694);
            this.Name = "frm_KhoiLop";
            this.Text = "frm_KhoiLop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_KhoiLop_FormClosing);
            this.Load += new System.EventHandler(this.frm_KhoiLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoiLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhoiLop;
        private System.Windows.Forms.TextBox txtMaKL;
        private System.Windows.Forms.TextBox txtTenKL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}