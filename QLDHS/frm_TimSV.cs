/*Họ tên:Trần Văn Hậu
 *Công việc:Màn hình tìm học sinh
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
    public partial class frm_TimSV : Form
    {
        public frm_TimSV()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source =.; Initial Catalog = QLDHS; Integrated Security = True");
        //Tìm dữ liệu
        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dths = new DataTable();
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand cmdTimHS = new SqlCommand("sp_LaydsHS", connect);
                cmdTimHS.CommandText = "sp_TimHS";
                cmdTimHS.CommandType = CommandType.StoredProcedure;

                cmdTimHS.Parameters.Add(new SqlParameter("@mahs", txtMaHS.Text));

                //khai bao adapter
                SqlDataAdapter dahs = new SqlDataAdapter(cmdTimHS);
                //khai bao datatable

                dahs.Fill(dths);
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
        //Reset
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaHS.Clear();
            txtMaHS.Focus();
            dgvHS.Columns.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_TimSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //Ưu tiên
        private void txtMaHS_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtMaHS, "Bạn phải nhập");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void frm_TimSV_Load(object sender, EventArgs e)
        {

        }
    }
}
