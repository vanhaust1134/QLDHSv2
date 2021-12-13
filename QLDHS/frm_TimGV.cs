/*Họ tên:Trần Văn Hậu
 *Công việc:Màn hình tìm giáo viên
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
    public partial class frm_TimGV : Form
    {
        public frm_TimGV()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source =.; Initial Catalog = QLDHS; Integrated Security = True");
        //tìm dữ liệu
        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dtgv = new DataTable();
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand cmdTimGV = new SqlCommand("sp_LaydsGV", connect);
                cmdTimGV.CommandText = "sp_TimGV";
                cmdTimGV.CommandType = CommandType.StoredProcedure;

                cmdTimGV.Parameters.Add(new SqlParameter("@ma", txtGV.Text));

                //khai bao adapter
                SqlDataAdapter dagv = new SqlDataAdapter(cmdTimGV);
                //khai bao datatable

                dagv.Fill(dtgv);
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
        //Reset
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtGV.Clear();
            txtGV.Focus();
            dgvGV.Columns.Clear();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Thoát
        private void frm_TimGV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //Ưu tiên
        private void txtGV_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtGV, "Bạn phải nhập");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void frm_TimGV_Load(object sender, EventArgs e)
        {

        }
    }
}
