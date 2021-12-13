/*Họ tên:Trần Văn Hậu
 *Công việc:Màn hình quản lý điểm
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
    public partial class frm_Diem : Form
    {
        public frm_Diem()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=QLDHS;Integrated Security=True");
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Load dữ liệu
        public void LoadFrmDiem()
        {
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsDIEM", connect);
                com.CommandText = "sp_LaydsDIEM";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dadiem = new SqlDataAdapter(com);
                //khai bao datatable
                DataTable dtdiem = new DataTable();

                dadiem.Fill(dtdiem);
                //dua du lieu vao datagrid
                dgvDiem.DataSource = dtdiem;
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
        //Load dữ liệu
        public DataTable LoadFrmHS()
        {
            DataTable dths = new DataTable();
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

                dahs.Fill(dths);
            }
            catch (Exception)
            {
                MessageBox.Show("Không ket noi duoc");
            }
            finally
            {
                connect.Close();
            }
            return dths;
        }
        //Load dữ liệu
        public DataTable LoadFrmMH()
        {
            DataTable dtmh = new DataTable();
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

                damh.Fill(dtmh);
            }
            catch (Exception)
            {
                MessageBox.Show("Không ket noi duoc");
            }
            finally
            {
                connect.Close();
            }
            return dtmh;
        }
        //Load dữ liệu
        public DataTable LoadFrmHK()
        {
            DataTable dthk = new DataTable();
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

                dahk.Fill(dthk);
            }
            catch (Exception)
            {
                MessageBox.Show("Không ket noi duoc");
            }
            finally
            {
                connect.Close();
            }
            return dthk;
        }
        //Load dữ liệu
        public DataTable LoadFrmHL()
        {
            DataTable dthl = new DataTable();
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand com = new SqlCommand("sp_LaydsHL", connect);
                com.CommandText = "sp_LaydsHL";
                com.CommandType = CommandType.StoredProcedure;

                //khai bao adapter
                SqlDataAdapter dahl = new SqlDataAdapter(com);
                //khai bao datatable

                dahl.Fill(dthl);
            }
            catch (Exception)
            {
                MessageBox.Show("Không ket noi duoc");
            }
            finally
            {
                connect.Close();
            }
            return dthl;
        }
        //Load dữ liệu
        public DataTable LoadFrmHM()
        {
            DataTable dthm = new DataTable();
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

                dahm.Fill(dthm);
            }
            catch (Exception)
            {
                MessageBox.Show("Không ket noi duoc");
            }
            finally
            {
                connect.Close();
            }
            return dthm;
        }
        private void frm_Diem_Load(object sender, EventArgs e)
        {
            LoadFrmDiem();
            cboMaHS.DataSource = LoadFrmHS();
            cboMaHS.DisplayMember = "HOTEN";
            cboMaHS.ValueMember = "MAHS";
            cboMaMH.DataSource = LoadFrmMH();
            cboMaMH.DisplayMember = "TENMH";
            cboMaMH.ValueMember = "MAMH";
            cboMaHK.DataSource = LoadFrmHK();
            cboMaHK.DisplayMember = "TENHK";
            cboMaHK.ValueMember = "MAHK";
            cboMaHL.DataSource = LoadFrmHL();
            cboMaHL.DisplayMember = "TENHL";
            cboMaHL.ValueMember = "MAHL";
            cboMaHM.DataSource = LoadFrmHM();
            cboMaHM.DisplayMember = "TENHK";
            cboMaHM.ValueMember = "MAHM";

        }
        //Thêm dữ liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdthemd = new SqlCommand();
                cmdthemd.CommandType = CommandType.StoredProcedure;
                cmdthemd.CommandText = "sp_ThemDIEM";
                cmdthemd.Connection = connect;

                //them cac tham so
                cmdthemd.Parameters.Add(new SqlParameter("@stt", txtSTT.Text));
                cmdthemd.Parameters.Add(new SqlParameter("@mahs", cboMaHS.SelectedValue.ToString()));
                cmdthemd.Parameters.Add(new SqlParameter("@mamh", cboMaMH.SelectedValue.ToString()));
                cmdthemd.Parameters.Add(new SqlParameter("@mahk", cboMaHK.SelectedValue.ToString()));
                cmdthemd.Parameters.Add(new SqlParameter("@mahl", cboMaHL.SelectedValue.ToString()));
                cmdthemd.Parameters.Add(new SqlParameter("@mahm", cboMaHM.SelectedValue.ToString()));
                cmdthemd.Parameters.Add(new SqlParameter("@dmieng", txtDiemM.Text));
                cmdthemd.Parameters.Add(new SqlParameter("@d15p", txtDiem15p.Text));
                cmdthemd.Parameters.Add(new SqlParameter("@d45p", txtDiem45p.Text));
                cmdthemd.Parameters.Add(new SqlParameter("@dthi", txtDiemThi.Text));

                //thucthi
                if (cmdthemd.ExecuteNonQuery() > 0)
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
                LoadFrmDiem();
            }
        }
        //Click lên datagrid
        private void dgvDiem_Click(object sender, EventArgs e)
        {
            int dong = dgvDiem.CurrentCell.RowIndex;
            txtSTT.Text = dgvDiem.Rows[dong].Cells[0].Value.ToString();
            cboMaHS.SelectedValue = dgvDiem.Rows[dong].Cells[1].Value.ToString();
            cboMaMH.SelectedValue = dgvDiem.Rows[dong].Cells[2].Value.ToString();
            cboMaHK.SelectedValue = dgvDiem.Rows[dong].Cells[3].Value.ToString();
            cboMaHL.SelectedValue = dgvDiem.Rows[dong].Cells[4].Value.ToString();
            cboMaHM.SelectedValue = dgvDiem.Rows[dong].Cells[5].Value.ToString();
            txtDiemM.Text = dgvDiem.Rows[dong].Cells[6].Value.ToString();
            txtDiem15p.Text = dgvDiem.Rows[dong].Cells[7].Value.ToString();
            txtDiem45p.Text = dgvDiem.Rows[dong].Cells[8].Value.ToString();
            txtDiemThi.Text = dgvDiem.Rows[dong].Cells[9].Value.ToString();
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
                    SqlCommand cmdxoad = new SqlCommand();
                    cmdxoad.CommandType = CommandType.StoredProcedure;
                    cmdxoad.CommandText = "sp_XoaDIEM";
                    cmdxoad.Connection = connect;

                    cmdxoad.Parameters.Add(new SqlParameter("@stt", txtSTT.Text));

                    if (cmdxoad.ExecuteNonQuery() > 0)
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
                LoadFrmDiem();
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
                    SqlCommand cmdsuad = new SqlCommand();
                    cmdsuad.CommandType = CommandType.StoredProcedure;
                    cmdsuad.CommandText = "sp_SuaDIEM";
                    cmdsuad.Connection = connect;

                    cmdsuad.Parameters.Add(new SqlParameter("@stt", txtSTT.Text));
                    cmdsuad.Parameters.Add(new SqlParameter("@mahs", cboMaHS.SelectedValue.ToString()));
                    cmdsuad.Parameters.Add(new SqlParameter("@mamh", cboMaMH.SelectedValue.ToString()));
                    cmdsuad.Parameters.Add(new SqlParameter("@mahk", cboMaHK.SelectedValue.ToString()));
                    cmdsuad.Parameters.Add(new SqlParameter("@mahl", cboMaHL.SelectedValue.ToString()));
                    cmdsuad.Parameters.Add(new SqlParameter("@mahm", cboMaHM.SelectedValue.ToString()));
                    cmdsuad.Parameters.Add(new SqlParameter("@dmieng", txtDiemM.Text));
                    cmdsuad.Parameters.Add(new SqlParameter("@d15p", txtDiem15p.Text));
                    cmdsuad.Parameters.Add(new SqlParameter("@d45p", txtDiem45p.Text));

                    SqlParameter para = new SqlParameter("@dthi", txtDiemThi.Text);

                    cmdsuad.Parameters.Add(para);

                    if (cmdsuad.ExecuteNonQuery() > 0)
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
                LoadFrmDiem();
            }
        }
        //Thoát
        private void frm_Diem_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //Kiểm tra dữ liệu

        private void txtSTT_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.SetError(txtSTT, "Không phải số");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
        //Ưu tiên
        private void txtSTT_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtSTT, "Bạn phải nhập trước");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
        //Kiểm tra dữ liệu
        private void txtDiemM_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.SetError(txtDiemM, "Không phải số");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
        //Kiểm tra dữ liệu
        private void txtDiem15p_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.SetError(txtDiem15p, "Không phải số");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
        //Kiểm tra dữ liệu
        private void txtDiem45p_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.SetError(txtDiem45p, "Không phải số");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
        //Kiểm tra dữ liệu
        private void txtDiemThi_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))
            {
                this.errorProvider1.SetError(txtDiemThi, "Không phải số");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
    }
}
