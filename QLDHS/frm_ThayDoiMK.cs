/*Họ tên:Huỳnh Bảo Nguyên
 *Công việc:Màn hình thay đổi mật khẩu
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLDHS
{
    public partial class frm_ThayDoiMK : Form
    {
        public frm_ThayDoiMK()
        {
            InitializeComponent();
        }
        //SqlConnection connect = new SqlConnection("Data Source=HBNGUYEN-LAPTOP\\SQLEXPRESS;Initial Catalog=QLDHS;Integrated Security=True");
        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=QLDHS;Integrated Security=True");
        //Giấu mật khẩu
        private void frm_ThayDoiMK_Load(object sender, EventArgs e)
        {
            txtMatKhau1.PasswordChar = '*';
            txtMatKhau2.PasswordChar = '*';
        }
        //load dữ liệu
        public void TaiKhoanND(string s)
        {
            DataTable dtTKNguoiDung = new DataTable();
            try
            {
                //MỞ kết nối
                connect.Open();
                //command
                SqlCommand cmdTaiKhoanND = new SqlCommand("sp_LaydsND", connect);
                cmdTaiKhoanND.CommandText = "SP_TAIKHOANND";
                cmdTaiKhoanND.CommandType = CommandType.StoredProcedure;

                cmdTaiKhoanND.Parameters.Add(new SqlParameter("@TK", s.ToString()));

                //khai bao adapter
                SqlDataAdapter danguoidung = new SqlDataAdapter(cmdTaiKhoanND);
                //khai bao datatable


                danguoidung.Fill(dtTKNguoiDung);
                //Đưa dữ liêu vào datagridview
                dgvNguoiDung.DataSource = dtTKNguoiDung;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
            finally
            {
                connect.Close();
            }
        }
        //load dữ liệu
        private DataTable LoadFromNguoiDung()
        {
            DataTable dtNguoiDung = new DataTable();
            try
            {
                //mở connnect
                connect.Open();
                //command
                SqlCommand comm = new SqlCommand("sp_LaydsND", connect);
                comm.CommandText = "sp_LaydsND";
                comm.CommandType = CommandType.StoredProcedure;

                //khai báo adapter
                SqlDataAdapter daketqua = new SqlDataAdapter(comm);
                //khai báo datatable
                daketqua.Fill(dtNguoiDung);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
            finally
            {
                connect.Close();
            }
            return dtNguoiDung;
        }
        //Gọi loại tài khoản
        public string TenTK(string s)
        {
            string Name = s;
            lbName.Text = Name.ToString();
            return Name;
        }
        //Sửa dữ liệu
        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (kq == DialogResult.Yes)
                {
                    //MỞ kết nối
                    connect.Open();
                    //command
                    SqlCommand cmdSuaND = new SqlCommand("sp_LaydsND", connect);
                    cmdSuaND.CommandText = "sp_SuaND";
                    cmdSuaND.CommandType = CommandType.StoredProcedure;

                    cmdSuaND.Connection = connect;

                    //Thêm các tham số vào 
                    cmdSuaND.Parameters.Add(new SqlParameter("@TK", lbName.Text));
                    SqlParameter paraMatKhau = new SqlParameter("@MK", txtMatKhau2.Text);

                    cmdSuaND.Parameters.Add(paraMatKhau);

                    //Thực thi câu lệnh insert
                    if (cmdSuaND.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Bạn thay đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Bạn thay đổi mật khẩu không thành công !", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
            finally
            {
                connect.Close();
                TaiKhoanND(lbName.Text);
            }
        }
        //Kiểm tra 2 mk
        private void txtMatKhau2_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtMatKhau2.Text != txtMatKhau1.Text)
            {
                this.errorProvider1.SetError(txtMatKhau2, "Mật khẩu không trùng khớp");
                btnThayDoi.Enabled = false;
            }
            else
            {
                this.errorProvider1.Clear();
                btnThayDoi.Enabled = true;
            }
        }
        //Kiểm tra 2 mk
        private void txtMatKhau2_MouseLeave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtMatKhau2.Text != txtMatKhau1.Text)
            {
                this.errorProvider1.SetError(txtMatKhau2, "Mật khẩu không trùng khớp");
                btnThayDoi.Enabled = false;
            }
            else
            {
                this.errorProvider1.Clear();
                btnThayDoi.Enabled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Hiển thị mật khẩu
        private void chbHienThiMk_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHienThiMk.Checked == false)
            {
                txtMatKhau1.PasswordChar = '*';
                txtMatKhau2.PasswordChar = '*';
            }
            else if (chbHienThiMk.Checked == true)
            {
                txtMatKhau1.PasswordChar = '\0';
                txtMatKhau2.PasswordChar = '\0';
            }
        }

        private void frm_ThayDoiMK_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
