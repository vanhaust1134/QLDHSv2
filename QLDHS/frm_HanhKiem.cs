/*Họ tên:Trần Văn Hậu
 *Công việc:Màn hình quản lý hạnh kiểm
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
    public partial class frm_HanhKiem : Form
    {
        public frm_HanhKiem()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=QLDHS;Integrated Security=True");
        private void frm_HanhKiem_Load(object sender, EventArgs e)
        {
            LoadFrmHM();
        }
        //load dữ liệu
        public void LoadFrmHM()
        {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsHM", connect);
                com.CommandText = "sp_LaydsHM";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dahm = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dthm = new DataTable();

                dahm.Fill(dthm);
                //dua du lieu vao datagrid
                dgvHM.DataSource = dthm;
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
        //thêm dữ liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdthemhm = new SqlCommand();
                cmdthemhm.CommandType = CommandType.StoredProcedure;
                cmdthemhm.CommandText = "sp_ThemHM";
                cmdthemhm.Connection = connect;

                //them cac tham so
                cmdthemhm.Parameters.Add(new SqlParameter("@mahm", txtMaHM.Text));
                cmdthemhm.Parameters.Add(new SqlParameter("@tenhm", txtTenHM.Text));
                //thucthi
                if (cmdthemhm.ExecuteNonQuery() > 0)
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
                LoadFrmHM();
            }
        }
        //Click tên datagrid
        private void dgvHM_Click(object sender, EventArgs e)
        {
            int dong = dgvHM.CurrentCell.RowIndex;
            txtMaHM.Text = dgvHM.Rows[dong].Cells[0].Value.ToString();
            txtTenHM.Text = dgvHM.Rows[dong].Cells[1].Value.ToString();
        }
        //Xóa dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("ban co muon xoa khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (kq == DialogResult.Yes)
                {
                    connect.Open();
                    SqlCommand cmdxoahm = new SqlCommand();
                    cmdxoahm.CommandType = CommandType.StoredProcedure;
                    cmdxoahm.CommandText = "sp_XoaHM";
                    cmdxoahm.Connection = connect;

                    cmdxoahm.Parameters.Add(new SqlParameter("@mahm", txtMaHM.Text));

                    if (cmdxoahm.ExecuteNonQuery() > 0)
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
                LoadFrmHM();
            }
        }
        //Sửa dữ liệu
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("ban co muon sua khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (kq == DialogResult.Yes)
                {
                    connect.Open();
                    SqlCommand cmdsuahm = new SqlCommand();
                    cmdsuahm.CommandType = CommandType.StoredProcedure;
                    cmdsuahm.CommandText = "sp_SuaHM";
                    cmdsuahm.Connection = connect;

                    cmdsuahm.Parameters.Add(new SqlParameter("@mahm", txtMaHM.Text));

                    SqlParameter para = new SqlParameter("@tenhm", txtTenHM.Text);

                    cmdsuahm.Parameters.Add(para);

                    if (cmdsuahm.ExecuteNonQuery() > 0)
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
                LoadFrmHM();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Kiểm tra dữ liệu
        private void txtTenHM_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.Clear();
            }
            else
            {
                this.errorProvider1.SetError(txtTenHM, "Không phải ký tự");
            }
        }
        //Ưu tiên
        private void txtMaHM_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtMaHM, "Bạn phải nhập trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
    }
}
