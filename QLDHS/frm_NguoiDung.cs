/*Họ tên:Huỳnh Bảo Nguyên
 *Công việc:Màn hình quản lý người dùng
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
    public partial class frm_NguoiDung : Form
    {
        public frm_NguoiDung()
        {
            InitializeComponent();
        }
        //SqlConnection connect = new SqlConnection("Data Source=HBNGUYEN-LAPTOP\\SQLEXPRESS;Initial Catalog=QLDHS;Integrated Security=True");
        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=QLDHS;Integrated Security=True");
        private void frm_NguoiDung_Load(object sender, EventArgs e)
        {
            LoadFormNguoiDung();
        }
        //load dữ liệu
        private void LoadFormNguoiDung()
        {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsND", connect);
                com.CommandText = "sp_LaydsND";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dand = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dtnd = new DataTable();

                dand.Fill(dtnd);
                dgvNguoiDung.DataSource = dtnd;
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
        private void dgvNguoiDung_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvNguoiDung.SelectedRows)
            {
                txtTaiKhoan.Text = row.Cells[0].Value.ToString();
                txtMatKhau.Text = row.Cells[1].Value.ToString();
            }
        }
        private void ClearDL()
        {
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
        }
        //Thêm dữ liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdThem = new SqlCommand();
                cmdThem.CommandType = CommandType.StoredProcedure;
                cmdThem.CommandText = "sp_ThemND";
                cmdThem.Connection = connect;

                //them cac tham so
                cmdThem.Parameters.Add(new SqlParameter("@tk", txtTaiKhoan.Text));
                cmdThem.Parameters.Add(new SqlParameter("@mk", txtMatKhau.Text));

                //thucthi
                if (cmdThem.ExecuteNonQuery() > 0)
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
                LoadFormNguoiDung();
                ClearDL();
            }
        }
        //Xóa dữ liệu
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
                    cmdthemHK.CommandText = "sp_XoaND";
                    cmdthemHK.Connection = connect;

                    //them cac tham so
                    cmdthemHK.Parameters.Add(new SqlParameter("@tk", txtTaiKhoan.Text));

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
                LoadFormNguoiDung();
                ClearDL();
            }
        }
        //Sửa dữ liệu
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
                    cmdSua.CommandText = "sp_SuaND";
                    cmdSua.Connection = connect;

                    //them cac tham so
                    cmdSua.Parameters.Add(new SqlParameter("@tk", txtTaiKhoan.Text));
                    cmdSua.Parameters.Add(new SqlParameter("@mk", txtMatKhau.Text));

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
                LoadFormNguoiDung();
                ClearDL();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_NguoiDung_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //Ưu tiên
        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtTaiKhoan, "Bạn phải trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
    }
}
