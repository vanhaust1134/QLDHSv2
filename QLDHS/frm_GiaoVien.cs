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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDHS
{
    public partial class frm_GiaoVien : Form
    {
        public frm_GiaoVien()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source =.; Initial Catalog = QLDHS; Integrated Security = True");

        private void frm_GiaoVien_Load(object sender, EventArgs e)
        {
            LoadFrmGV();
            cboMaLOP.DataSource = LoadFrmLOP();
            cboMaLOP.DisplayMember = "TENLOP";
            cboMaLOP.ValueMember = "MALOP";
        }
        //load dữ liệu
        public void LoadFrmGV()
        {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsGV", connect);
                com.CommandText = "sp_LaydsGV";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dagv = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dtgv = new DataTable();

                dagv.Fill(dtgv);
                //dua du lieu vao datagrid
                dgvGV.DataSource = dtgv;
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
        //load dữ liệu
        public DataTable LoadFrmLOP()
        {
            DataTable dtlop = new DataTable();
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsLOP", connect);
                com.CommandText = "sp_LaydsLOP";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dalop = new SqlDataAdapter(com);
                //khai bao datatable

                dalop.Fill(dtlop);
            }
            catch (Exception)
            {
                MessageBox.Show("Không ket noi duoc");
            }
            finally
            {
                connect.Close();
            }
            return dtlop;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Thêm dữ liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdthemgv = new SqlCommand();
                cmdthemgv.CommandType = CommandType.StoredProcedure;
                cmdthemgv.CommandText = "sp_ThemGV";
                cmdthemgv.Connection = connect;

                //them cac tham so
                cmdthemgv.Parameters.Add(new SqlParameter("@ma", txtMaGV.Text));
                cmdthemgv.Parameters.Add(new SqlParameter("@hoten", txtHoTen.Text));
                cmdthemgv.Parameters.Add(new SqlParameter("@diachi", txtDiaChi.Text));
                cmdthemgv.Parameters.Add(new SqlParameter("@malop", cboMaLOP.SelectedValue.ToString()));

                //thucthi
                if (cmdthemgv.ExecuteNonQuery() > 0)
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
                LoadFrmGV();
            }
        }
        //Click trên datagrid
        private void dgvGV_Click(object sender, EventArgs e)
        {
            int dong = dgvGV.CurrentCell.RowIndex;
            txtMaGV.Text = dgvGV.Rows[dong].Cells[0].Value.ToString();
            txtHoTen.Text = dgvGV.Rows[dong].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvGV.Rows[dong].Cells[2].Value.ToString();
            cboMaLOP.Text = dgvGV.Rows[dong].Cells[3].Value.ToString();
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
                    SqlCommand cmdxoagv = new SqlCommand();
                    cmdxoagv.CommandType = CommandType.StoredProcedure;
                    cmdxoagv.CommandText = "sp_XoaGV";
                    cmdxoagv.Connection = connect;

                    cmdxoagv.Parameters.Add(new SqlParameter("@ma", txtMaGV.Text));

                    if (cmdxoagv.ExecuteNonQuery() > 0)
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
                LoadFrmGV();
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
                    SqlCommand cmdsuagv = new SqlCommand();
                    cmdsuagv.CommandType = CommandType.StoredProcedure;
                    cmdsuagv.CommandText = "sp_SuaGV";
                    cmdsuagv.Connection = connect;

                    cmdsuagv.Parameters.Add(new SqlParameter("@ma", txtMaGV.Text));
                    cmdsuagv.Parameters.Add(new SqlParameter("@hoten", txtHoTen.Text));
                    cmdsuagv.Parameters.Add(new SqlParameter("@diachi", txtDiaChi.Text));

                    SqlParameter para = new SqlParameter("@malop", cboMaLOP.SelectedValue.ToString());

                    cmdsuagv.Parameters.Add(para);

                    if (cmdsuagv.ExecuteNonQuery() > 0)
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
                LoadFrmGV();
            }
        }

        private void frm_GiaoVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //Kiểm tra dữ liệu
        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.Clear();
            }
            else
            {
                this.errorProvider1.SetError(txtHoTen, "Không phải ký tự");
            }
        }
        //Ưu tiên
        private void txtMaGV_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtMaGV, "Bạn phải nhập trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
    }
}
