/*Họ tên:Huỳnh Bảo Nguyên
 *Công việc:Màn hình đăng nhập
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
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }
        //SqlConnection connect = new SqlConnection("Data Source=HBNGUYEN-LAPTOP\\SQLEXPRESS;Initial Catalog=QLDHS;Integrated Security=True");
        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=QLDHS;Integrated Security=True");

        //Kiểm tra tài khoản
        private void KiemTra()
        {
            if (txtTaiKhoan.Text.ToLower().Contains("school") == true)
            {
                frm_QuanLyDiem fm = new frm_QuanLyDiem();
                fm.anmnMain(txtTaiKhoan.Text);
                DataTable dt = new DataTable();
                try
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("sp_LaydsND", connect);
                    cmd.CommandText = "SP_KIEMTRAND";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TK", txtTaiKhoan.Text));
                    SqlParameter paraMK = new SqlParameter("@MK", txtMatKhau.Text);

                    cmd.Parameters.Add(paraMK);
                    SqlDataAdapter dasv = new SqlDataAdapter(cmd);
                    //khai bao datatable

                    dasv.Fill(dt);
                    SqlDataReader dta = cmd.ExecuteReader();
                    if (dta.Read() == true)
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        fm.Show();
                        fm.TenTK(txtTaiKhoan.Text.ToString());
                        txtTaiKhoan.Clear();
                        txtMatKhau.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản mật hoặc khẩu bị sai");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            //Kiểm tra tài khoản
            else if (txtTaiKhoan.Text.ToLower().Contains("teacher") == true)
            {
                frm_QuanLyDiem fm = new frm_QuanLyDiem();
                fm.anmnMain(txtTaiKhoan.Text);
                DataTable dt = new DataTable();
                try
                {
                    connect.Open();
                    SqlCommand cmdKtraUser = new SqlCommand("sp_LaydsND", connect);
                    cmdKtraUser.CommandText = "SP_KIEMTRAND1";
                    cmdKtraUser.CommandType = CommandType.StoredProcedure;
                    cmdKtraUser.Parameters.Add(new SqlParameter("@TK", txtTaiKhoan.Text.ToLower()));
                    SqlParameter paraMK = new SqlParameter("@MK", txtMatKhau.Text);

                    cmdKtraUser.Parameters.Add(paraMK);
                    SqlDataAdapter dasv = new SqlDataAdapter(cmdKtraUser);
                    //khai bao datatable

                    dasv.Fill(dt);
                    SqlDataReader dta = cmdKtraUser.ExecuteReader();
                    if (dta.Read() == true)
                    {
                        MessageBox.Show("Đăng nhập thành công");

                        fm.TenTK(txtTaiKhoan.Text.ToString());
                        fm.Show();
                        txtTaiKhoan.Clear();
                        txtMatKhau.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Tài khoản mật hoặc khẩu bị sai");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            //Kiểm tra tài khoản
            else if (txtTaiKhoan.Text.ToLower().Contains("student") == true)
            {
                frm_QuanLyDiem fm = new frm_QuanLyDiem();
                fm.anmnMain(txtTaiKhoan.Text);
                DataTable dt = new DataTable();
                try
                {
                    connect.Open();
                    SqlCommand cmdKtraUser = new SqlCommand("sp_LaydsND", connect);
                    cmdKtraUser.CommandText = "SP_KIEMTRAND2";
                    cmdKtraUser.CommandType = CommandType.StoredProcedure;
                    cmdKtraUser.Parameters.Add(new SqlParameter("@TK", txtTaiKhoan.Text.ToLower()));
                    SqlParameter paraMK = new SqlParameter("@MK", txtMatKhau.Text);

                    cmdKtraUser.Parameters.Add(paraMK);
                    SqlDataAdapter dasv = new SqlDataAdapter(cmdKtraUser);
                    //khai bao datatable

                    dasv.Fill(dt);
                    SqlDataReader dta = cmdKtraUser.ExecuteReader();
                    if (dta.Read() == true)
                    {
                        MessageBox.Show("Đăng nhập thành công");

                        fm.TenTK(txtTaiKhoan.Text.ToString());
                        fm.Show();
                        txtTaiKhoan.Clear();
                        txtMatKhau.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Tài khoản mật hoặc khẩu bị sai");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        //Giấu MK
        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            KiemTra();
        }

        //Thoát
        private void frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Hiển thị mật khẩu
        private void chbhienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                txtMatKhau.PasswordChar = '*';
            }
            else if (checkBox1.Checked == true)
            {
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void txtTaiKhoan_Click(object sender, EventArgs e)
        {
            txtMatKhau.Clear();
        }
    }
}
