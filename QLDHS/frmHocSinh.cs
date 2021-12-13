/*Họ tên:Trần Văn Hậu
 *Công việc:Màn hình quản lý học sinh
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
    public partial class frmHocSinh : Form
    {
        public frmHocSinh()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        SqlConnection connect = new SqlConnection("Data Source =.; Initial Catalog = QLDHS; Integrated Security = True");
        //SqlConnection connect = new SqlConnection("Data Source=HBNGUYEN-LAPTOP\\SQLEXPRESS;Initial Catalog=QLDHS;Integrated Security=True");
        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            LoadFrmHS();
            cboMALOP.DataSource = LoadFrmLOP();
            cboMALOP.DisplayMember = "TENLOP";
            cboMALOP.ValueMember = "MALOP";
        }
        //load dữ liệu
        public void LoadFrmHS()
        {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsHS", connect);
                com.CommandText = "sp_LaydsHS";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dahs = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dths = new DataTable();

                dahs.Fill(dths);
                //dua du lieu vao datagrid
                dgvHS.DataSource = dths;
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
        //thêm dữ liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdthemhs = new SqlCommand();
                cmdthemhs.CommandType = CommandType.StoredProcedure;
                cmdthemhs.CommandText = "sp_ThemHS";
                cmdthemhs.Connection = connect;

                //them cac tham so
                cmdthemhs.Parameters.Add(new SqlParameter("@mahs", txtMAHS.Text));
                cmdthemhs.Parameters.Add(new SqlParameter("@malop", cboMALOP.SelectedValue.ToString()));
                cmdthemhs.Parameters.Add(new SqlParameter("@ten", txtHoTen.Text));
                string gt = "Nam";
                if (radNu.Checked == true)
                {
                    gt = radNu.Text;
                }
                cmdthemhs.Parameters.Add(new SqlParameter("@gioitinh", gt));
                cmdthemhs.Parameters.Add(new SqlParameter("@ns", dtpNS.Text));
                cmdthemhs.Parameters.Add(new SqlParameter("@dc", txtDC.Text));

                //thucthi
                if (cmdthemhs.ExecuteNonQuery() > 0)
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
                LoadFrmHS();
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
                    SqlCommand cmdxoahs = new SqlCommand();
                    cmdxoahs.CommandType = CommandType.StoredProcedure;
                    cmdxoahs.CommandText = "sp_XoaHS";
                    cmdxoahs.Connection = connect;

                    cmdxoahs.Parameters.Add(new SqlParameter("@mahs", txtMAHS.Text));

                    if (cmdxoahs.ExecuteNonQuery() > 0)
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
                LoadFrmHS();
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
                    SqlCommand cmdsuahs = new SqlCommand();
                    cmdsuahs.CommandType = CommandType.StoredProcedure;
                    cmdsuahs.CommandText = "sp_SuaHS";
                    cmdsuahs.Connection = connect;

                    cmdsuahs.Parameters.Add(new SqlParameter("@mahs", txtMAHS.Text));
                    cmdsuahs.Parameters.Add(new SqlParameter("@malop", cboMALOP.SelectedValue.ToString()));
                    cmdsuahs.Parameters.Add(new SqlParameter("@ten", txtHoTen.Text));
                    string gt = "NAM";
                    if (radNu.Checked == true)
                    {
                        gt = radNu.Text;
                    }
                    cmdsuahs.Parameters.Add(new SqlParameter("@gioitinh", gt));
                    cmdsuahs.Parameters.Add(new SqlParameter("@ns", dtpNS.Text));

                    SqlParameter para = new SqlParameter("@dc",txtDC.Text);

                    cmdsuahs.Parameters.Add(para);

                    if (cmdsuahs.ExecuteNonQuery() > 0)
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
                LoadFrmHS();
            }
        }
        //Click trên datagrid
        private void dgvHS_Click(object sender, EventArgs e)
        {
            int dong = dgvHS.CurrentCell.RowIndex;
            txtMAHS.Text = dgvHS.Rows[dong].Cells[0].Value.ToString();
            cboMALOP.SelectedValue = dgvHS.Rows[dong].Cells[1].Value.ToString();
            txtHoTen.Text = dgvHS.Rows[dong].Cells[2].Value.ToString();
            if (dgvHS.Rows[dong].Cells[3].Value.ToString() == radNam.Text)
            {
                radNam.Checked = true;
            }
            if (dgvHS.Rows[dong].Cells[3].Value.ToString() == radNu.Text)
            {
                radNu.Checked = true;
            }
            dtpNS.Text = dgvHS.Rows[dong].Cells[4].Value.ToString();
            txtDC.Text = dgvHS.Rows[dong].Cells[5].Value.ToString();
        }
        
        private void frmHocSinh_FormClosing(object sender, FormClosingEventArgs e)
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
        private void txtMAHS_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtMAHS, "Bạn phải nhập trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

    }
}
