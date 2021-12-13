/*Họ tên:Trần Văn Hậu
 *Công việc:Màn hình quản lý môn học
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
    public partial class frmMonHoc : Form
    {
        public frmMonHoc()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source =.; Initial Catalog = QLDHS; Integrated Security = True");

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            LoadFrmMH();
        }
        public void LoadFrmMH()
        {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsMH", connect);
                com.CommandText = "sp_LaydsMH";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter damh = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dtmh = new DataTable();

                damh.Fill(dtmh);
                //dua du lieu vao datagrid
                dgvMH.DataSource = dtmh;
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdthemmh = new SqlCommand();
                cmdthemmh.CommandType = CommandType.StoredProcedure;
                cmdthemmh.CommandText = "sp_ThemMH";
                cmdthemmh.Connection = connect;

                //them cac tham so
                cmdthemmh.Parameters.Add(new SqlParameter("@mamh", txtMaMH.Text));
                cmdthemmh.Parameters.Add(new SqlParameter("@tenmh", txtTenMH.Text));
                cmdthemmh.Parameters.Add(new SqlParameter("@sotiet", txtSoTiet.Text));

                //thucthi
                if (cmdthemmh.ExecuteNonQuery() > 0)
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
                LoadFrmMH();
            }
        }

        private void dgvMH_Click(object sender, EventArgs e)
        {
            int dong = dgvMH.CurrentCell.RowIndex;
            txtMaMH.Text = dgvMH.Rows[dong].Cells[0].Value.ToString();
            txtTenMH.Text = dgvMH.Rows[dong].Cells[1].Value.ToString();
            txtSoTiet.Text = dgvMH.Rows[dong].Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("ban co muon xoa khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (kq == DialogResult.Yes)
                {
                    connect.Open();
                    SqlCommand cmdxoamh = new SqlCommand();
                    cmdxoamh.CommandType = CommandType.StoredProcedure;
                    cmdxoamh.CommandText = "sp_XoaMH";
                    cmdxoamh.Connection = connect;

                    cmdxoamh.Parameters.Add(new SqlParameter("@mamh", txtMaMH.Text));

                    if (cmdxoamh.ExecuteNonQuery() > 0)
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
                LoadFrmMH();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("ban co muon sua khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (kq == DialogResult.Yes)
                {
                    connect.Open();
                    SqlCommand cmdsuamh = new SqlCommand();
                    cmdsuamh.CommandType = CommandType.StoredProcedure;
                    cmdsuamh.CommandText = "sp_SuaMH";
                    cmdsuamh.Connection = connect;

                    cmdsuamh.Parameters.Add(new SqlParameter("@mamh", txtMaMH.Text));
                    cmdsuamh.Parameters.Add(new SqlParameter("@tenmh", txtTenMH.Text));

                    SqlParameter para = new SqlParameter("@sotiet", txtSoTiet.Text);

                    cmdsuamh.Parameters.Add(para);

                    if (cmdsuamh.ExecuteNonQuery() > 0)
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
                LoadFrmMH();
            }
        }

        private void frmMonHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void txtTenMH_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.Clear();
            }
            else
            {
                this.errorProvider1.SetError(txtTenMH, "Không phải ký tự");
            }
        }

        private void txtMaMH_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtMaMH, "Bạn phải nhập trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void txtSoTiet_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.SetError(txtSoTiet, "Không phải số");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
    }
}
