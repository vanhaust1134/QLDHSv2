/*Họ tên:Trần Văn Hậu
 *Công việc:Màn hình quản lý giáo viên
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDHS
{
    public partial class frm_HocLuc : Form
    {
        public frm_HocLuc()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=QLDHS;Integrated Security=True");
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //load dữ liệu
        public void LoadFrmHL()
        {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsHL", connect);
                com.CommandText = "sp_LaydsHL";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dahl = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dthl = new DataTable();

                dahl.Fill(dthl);
                //dua du lieu vao datagrid
                dgvHL.DataSource = dthl;
            }
            catch (Exception)
            {
                MessageBox.Show("Không ket noi duoc");
            }
            finally
            {
                connect.Close();
            }
        }
        //sửa dữ liệu
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("ban co muon sua khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (kq == DialogResult.Yes)
                {
                    connect.Open();
                    SqlCommand cmdsuahl = new SqlCommand();
                    cmdsuahl.CommandType = CommandType.StoredProcedure;
                    cmdsuahl.CommandText = "sp_SuaHL";
                    cmdsuahl.Connection = connect;

                    cmdsuahl.Parameters.Add(new SqlParameter("@mahl", txtMaHL.Text));

                    SqlParameter para = new SqlParameter("@tenhl", txtTenHL.Text);

                    cmdsuahl.Parameters.Add(para);

                    if (cmdsuahl.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Ban da sua thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("Ban da sua khong thanh cong");
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                connect.Close();
                LoadFrmHL();
            }
        }
        //xóa dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("ban co muon xoa khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (kq == DialogResult.Yes)
                {
                    connect.Open();
                    SqlCommand cmdxoahl = new SqlCommand();
                    cmdxoahl.CommandType = CommandType.StoredProcedure;
                    cmdxoahl.CommandText = "sp_XoaHL";
                    cmdxoahl.Connection = connect;

                    cmdxoahl.Parameters.Add(new SqlParameter("@mahl", txtMaHL.Text));

                    if (cmdxoahl.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Ban da xoa thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("Ban da xoa khong thanh cong");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi" + ex);
            }
            finally
            {
                connect.Close();
                LoadFrmHL();
            }
        }
        //thêm dữ liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdthemhl = new SqlCommand();
                cmdthemhl.CommandType = CommandType.StoredProcedure;
                cmdthemhl.CommandText = "sp_ThemHL";
                cmdthemhl.Connection = connect;

                //them cac tham so
                cmdthemhl.Parameters.Add(new SqlParameter("@mahl", txtMaHL.Text));
                cmdthemhl.Parameters.Add(new SqlParameter("@tenhl", txtTenHL.Text));
                //thucthi
                if (cmdthemhl.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Them thanh cong");
                }
                else
                {
                    MessageBox.Show("Them khong thanh cong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Them khong duoc" + ex);
            }
            finally
            {
                connect.Close();
                LoadFrmHL();
            }
        }

        private void frm_HocLuc_Load(object sender, EventArgs e)
        {
            LoadFrmHL();
        }
        //Click trên data grid
        private void dgvHL_Click(object sender, EventArgs e)
        {
            int dong = dgvHL.CurrentCell.RowIndex;
            txtMaHL.Text = dgvHL.Rows[dong].Cells[0].Value.ToString();
            txtTenHL.Text = dgvHL.Rows[dong].Cells[1].Value.ToString();
        }
        //Kiểm tra dữ liệu
        private void txtTenHL_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.Clear();
            }
            else
            {
                this.errorProvider1.SetError(txtTenHL, "Không phải ký tự");
            }
        }
        //Ưu tiên
        private void txtMaHL_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtMaHL, "Bạn phải nhập trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
    }
}
