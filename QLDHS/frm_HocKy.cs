/*Họ tên:Huỳnh Bảo Nguyên
 *Công việc:Màn hình quản lý học kỳ
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
    public partial class frm_HocKy : Form
    {
        public frm_HocKy()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source =.; Initial Catalog = QLDHS; Integrated Security = True");
        //SqlConnection connect = new SqlConnection("Data Source=HBNGUYEN-LAPTOP\\SQLEXPRESS;Initial Catalog=QLDHS;Integrated Security=True");
        private void frm_HocKy_Load(object sender, EventArgs e)
        {
            LoadfrmHOCKY();
        }

        private void ClearDL()
        {
            txtmaHK.Clear();
            txtTenHk.Clear();
            txtHeSo.Clear();
        }
        //load dữ liệu
        private void LoadfrmHOCKY()
        {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsHOCKY", connect);
                com.CommandText = "sp_LaydsHOCKY";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dahk = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dthk = new DataTable();

                dahk.Fill(dthk);
                //dua du lieu vao datagrid
                dgvHocKy.DataSource = dthk;
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
        private void dgvHocKy_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHocKy.SelectedRows)
            {
                txtmaHK.Text = row.Cells[0].Value.ToString();
                txtTenHk.Text = row.Cells[1].Value.ToString();
                txtHeSo.Text = row.Cells[2].Value.ToString();
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
                cmdthemHK.CommandText = "sp_ThemHOCKY";
                cmdthemHK.Connection = connect;

                //them cac tham so
                cmdthemHK.Parameters.Add(new SqlParameter("@ma", txtmaHK.Text));
                cmdthemHK.Parameters.Add(new SqlParameter("@ten", txtTenHk.Text));
                cmdthemHK.Parameters.Add(new SqlParameter("@heso", txtHeSo.Text));

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
                LoadfrmHOCKY();
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
                    cmdthemHK.CommandText = "sp_XoaHOCKY";
                    cmdthemHK.Connection = connect;

                    //them cac tham so
                    cmdthemHK.Parameters.Add(new SqlParameter("@ma", txtmaHK.Text));

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
                LoadfrmHOCKY();
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
                    cmdSua.CommandText = "sp_SuaHOCKY";
                    cmdSua.Connection = connect;

                    //them cac tham so
                    cmdSua.Parameters.Add(new SqlParameter("@ma", txtmaHK.Text));
                    cmdSua.Parameters.Add(new SqlParameter("@ten", txtTenHk.Text));
                    cmdSua.Parameters.Add(new SqlParameter("@heso", txtHeSo.Text));

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
                LoadfrmHOCKY();
                ClearDL();
            }
        }

        private void frm_HocKy_FormClosing(object sender, FormClosingEventArgs e)
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
        //Ưu tiên
        private void txtmaHK_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtmaHK, "Bạn phải nhập trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
        //Kiểm tra dữ liệu
        private void txtHeSo_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.SetError(txtHeSo, "Không phải số");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
    }
}
