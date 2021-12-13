/*Họ tên:Huỳnh Bảo Nguyên
 *Công việc:Màn hình quản lý khối lớp
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDHS
{
    public partial class frm_KhoiLop : Form
    {
        public frm_KhoiLop()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source =.; Initial Catalog = QLDHS; Integrated Security = True");
        //SqlConnection connect = new SqlConnection("Data Source=HBNGUYEN-LAPTOP\\SQLEXPRESS;Initial Catalog=QLDHS;Integrated Security=True");
        private void frm_KhoiLop_Load(object sender, EventArgs e)
        {
            LoadfrmKhoiLop();
        }
        private void ClearDL()
        {
            txtMaKL.Clear();
            txtTenKL.Clear();
        }
        //load dữ liệu
        private void LoadfrmKhoiLop()
        {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsKL", connect);
                com.CommandText = "sp_LaydsKL";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dakl = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dtkl = new DataTable();

                dakl.Fill(dtkl);
                //dua du lieu vao datagrid
                dgvKhoiLop.DataSource = dtkl;
            }
            catch (Exception)
            {
                MessageBox.Show("Không kết nối được");
            }
            finally
            {
                connect.Close();
            }
        }
        //Click trên datagrid
        private void dgvKhoiLop_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvKhoiLop.SelectedRows)
            {
                txtMaKL.Text = row.Cells[0].Value.ToString();
                txtTenKL.Text = row.Cells[1].Value.ToString();
            }
        }
        //thêm dữ liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdthemHK = new SqlCommand();
                cmdthemHK.CommandType = CommandType.StoredProcedure;
                cmdthemHK.CommandText = "sp_ThemKL";
                cmdthemHK.Connection = connect;

                //them cac tham so
                cmdthemHK.Parameters.Add(new SqlParameter("@ma", txtMaKL.Text));
                cmdthemHK.Parameters.Add(new SqlParameter("@tenkl", txtTenKL.Text));

                //thucthi
                if (cmdthemHK.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không được" + ex);
            }
            finally
            {
                connect.Close();
                LoadfrmKhoiLop();
                ClearDL();
            }
        }
        //xóa dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn xoá không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (kq == DialogResult.Yes)
                {
                    connect.Open();
                    SqlCommand cmdthemHK = new SqlCommand();
                    cmdthemHK.CommandType = CommandType.StoredProcedure;
                    cmdthemHK.CommandText = "sp_XoaKL";
                    cmdthemHK.Connection = connect;

                    //them cac tham so
                    cmdthemHK.Parameters.Add(new SqlParameter("@ma", txtMaKL.Text));

                    //thucthi
                    if (cmdthemHK.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xoá thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("Xoá khong thanh cong");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá khong duoc" + ex);
            }
            finally
            {
                connect.Close();
                LoadfrmKhoiLop();
                ClearDL();
            }
        }
        //sửa dữ liệu
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (kq == DialogResult.Yes)
                {
                    connect.Open();
                    SqlCommand cmdSua = new SqlCommand();
                    cmdSua.CommandType = CommandType.StoredProcedure;
                    cmdSua.CommandText = "sp_SuaKL";
                    cmdSua.Connection = connect;

                    //them cac tham so
                    cmdSua.Parameters.Add(new SqlParameter("@ma", txtMaKL.Text));
                    cmdSua.Parameters.Add(new SqlParameter("@tenkl", txtTenKL.Text));

                    //thucthi
                    if (cmdSua.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không được" + ex);
            }
            finally
            {
                connect.Close();
                LoadfrmKhoiLop();
                ClearDL();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_KhoiLop_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //Ưu tiên
        private void txtMaKL_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtMaKL, "Bạn phải nhập trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
    }
}
