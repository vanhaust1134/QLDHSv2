/*Họ tên:Huỳnh Bảo Nguyên
 *Công việc:Màn hình quản lý năm học
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
    public partial class frm_NamHoc : Form
    {
        public frm_NamHoc()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=QLDHS;Integrated Security=True");
        private void frm_NamHoc_Load(object sender, EventArgs e)
        {
            LoadNamHoc();
        }
        //load dữ liệu
        private void LoadNamHoc() {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsNAMHOC", connect);
                com.CommandText = "sp_LaydsNAMHOC";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter danh = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dtnh = new DataTable();

                danh.Fill(dtnh);
                //dua du lieu vao datagrid
                dgvNamHoc.DataSource = dtnh;
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
        private void clearDL()
        {
            txtMaNH.Clear();
            txtTenNH.Clear();
        }
        //Thêm dữ liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdthemNH = new SqlCommand();
                cmdthemNH.CommandType = CommandType.StoredProcedure;
                cmdthemNH.CommandText = "sp_ThemNAMHOC";
                cmdthemNH.Connection = connect;

                //them cac tham so
                cmdthemNH.Parameters.Add(new SqlParameter("@ma", txtMaNH.Text));
                cmdthemNH.Parameters.Add(new SqlParameter("@ten",txtTenNH.Text));

                //thucthi
                if (cmdthemNH.ExecuteNonQuery() > 0)
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
                LoadNamHoc();
                clearDL();
            }
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
                    SqlCommand cmdxoaNH = new SqlCommand();
                    cmdxoaNH.CommandType = CommandType.StoredProcedure;
                    cmdxoaNH.CommandText = "sp_XoaNAMHOC";
                    cmdxoaNH.Connection = connect;

                    cmdxoaNH.Parameters.Add(new SqlParameter("@ma", txtMaNH.Text));

                    if (cmdxoaNH.ExecuteNonQuery() > 0)
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
                LoadNamHoc();
                clearDL();
            }
        }
        //Click trên datagrid
        private void dgvNamHoc_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNamHoc.SelectedRows)
            {
                txtMaNH.Text = row.Cells[0].Value.ToString();
                txtTenNH.Text = row.Cells[1].Value.ToString();
            }
        }
        //Sửa dữ liệu
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdSua = new SqlCommand();
                cmdSua.CommandType = CommandType.StoredProcedure;
                cmdSua.CommandText = "sp_SuaNAMHOC";
                cmdSua.Connection = connect;

                //them cac tham so
                cmdSua.Parameters.Add(new SqlParameter("@ma", txtMaNH.Text));
                cmdSua.Parameters.Add(new SqlParameter("@ten", txtTenNH.Text));

                //thucthi
                if (cmdSua.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Sửa không  thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không được" + ex);
            }
            finally
            {
                connect.Close();
                LoadNamHoc();
                clearDL();
            }
        }

        private void frm_NamHoc_FormClosing(object sender, FormClosingEventArgs e)
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
        private void txtMaNH_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtMaNH, "Bạn phải nhập trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
        //Kiểm tra dữ liệu
        private void txtTenNH_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.SetError(txtTenNH, "Không phải số");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void txtMaNH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
