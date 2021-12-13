/*Họ tên:Trần Văn Hậu
 *Công việc:Màn hình tìm lớp
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
    public partial class frm_TimLop : Form
    {
        public frm_TimLop()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source =.; Initial Catalog = QLDHS; Integrated Security = True");
        //Tìm dữ liệu
        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dtlop = new DataTable();
            try
            {
                //ket noi
                connect.Open();
                //command
                SqlCommand cmdTimLop = new SqlCommand("sp_LaydsLOP", connect);
                cmdTimLop.CommandText = "sp_TimLOP";
                cmdTimLop.CommandType = CommandType.StoredProcedure;

                cmdTimLop.Parameters.Add(new SqlParameter("@malop", txtLop.Text));

                //khai bao adapter
                SqlDataAdapter dalop = new SqlDataAdapter(cmdTimLop);
                //khai bao datatable

                dalop.Fill(dtlop);
                dgvLop.DataSource = dtlop;
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
            txtLop.Clear();
            txtLop.Focus();
            dgvLop.Columns.Clear();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Thoát
        private void frm_TimLop_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //Ưu tiên
        private void txtLop_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtLop, "Bạn phải nhập");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void frm_TimLop_Load(object sender, EventArgs e)
        {

        }
    }
}
