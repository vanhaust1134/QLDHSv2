/*Họ tên:Trần Văn Hậu
 *Công việc:Màn hình chính(menu)
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDHS
{
    public partial class frm_QuanLyDiem : Form
    {
        public frm_QuanLyDiem()
        {
            InitializeComponent();
        }
        //Kiểm tra form con
        public Boolean Kiemtra(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(name))
                {
                    frm.Focus();
                    return true;
                }
            }
            return false;
        }
        //frm Học sinh
        private void mnuHS_Click(object sender, EventArgs e)
        {
            frmHocSinh frm = new frmHocSinh();
            if (Kiemtra("frmHocSinh"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm report học sinh
        private void mnuDSHS_Click(object sender, EventArgs e)
        {
            frmDSHS frm = new frmDSHS();
            if (Kiemtra("frmDSHS"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm khối lớp
        private void mnuKhoiLop_Click(object sender, EventArgs e)
        {
            frm_KhoiLop frm = new frm_KhoiLop();
            if (Kiemtra("frm_KhoiLop"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm môn học
        private void mnuMH_Click(object sender, EventArgs e)
        {
            frmMonHoc frm = new frmMonHoc();
            if (Kiemtra("frmMonHoc"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm giáo viên
        private void mnuGV_Click(object sender, EventArgs e)
        {
            frm_GiaoVien frm = new frm_GiaoVien();
            if (Kiemtra("frm_GiaoVien"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm điểm
        private void mnuDiem_Click(object sender, EventArgs e)
        {
            frm_Diem frm = new frm_Diem();
            if (Kiemtra("frm_Diem"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm lớp
        private void mnuLop_Click(object sender, EventArgs e)
        {
            frm_Lop frm = new frm_Lop();
            if (Kiemtra("frm_Lop"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm năm học
        private void mnuNamHoc_Click(object sender, EventArgs e)
        {
            frm_NamHoc frm = new frm_NamHoc();
            if (Kiemtra("frm_NamHoc"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm học kỳ
        private void mnuHocKy_Click(object sender, EventArgs e)
        {
            frm_HocKy frm = new frm_HocKy();
            if (Kiemtra("frm_HocKy"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        private void frm_QuanLyDiem_Load(object sender, EventArgs e)
        {
            //frm_QuanLyDiem frm = new frm_QuanLyDiem();
            //ActivateMdiChild(frm);
        }
        //Lấy name tài khoản
        private string layname()
        {
            string name = lbNameTK.Text;
            return name;
        }
        //Gọi tên tài khoản
        public string TenTK(string s)
        {
            string Name = s;
            lbNameTK.Text =Name.ToString();
            return Name;
        }
        //Phân quyền người dùng
        public void anmnMain(string s)
        {
            if (s.ToLower().Contains("student") == true)
            {
                mnuHS.Enabled = false;
                mnuKhoiLop.Enabled = false;
                mnuMH.Enabled = false;
                mnuGV.Enabled = false;
                mnuLop.Enabled = false;
                mnuNamHoc.Enabled = false;
                mnuHocKy.Enabled = false;
                mnuDSHS.Enabled = false;
                mnuDSDiem.Enabled = false;
                mnuDSHS.Enabled = false;
            }
            else if (s.ToLower().Contains("teacher") == true)
            {
                mnuKhoiLop.Enabled = false;
                mnuMH.Enabled = false;
                mnuLop.Enabled = false;
                mnuNamHoc.Enabled = false;
                mnuHocKy.Enabled = false;
                mnuDSHS.Enabled = false;
            }
            else if (s.ToLower().Contains("school") == true)
            {
            }
        }
        //frm người dùng
        private void mnuNguoiDung_Click(object sender, EventArgs e)
        {
            frm_NguoiDung frm = new frm_NguoiDung();
            if (Kiemtra("frm_NguoiDung"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm thay đổi mật khẩu
        private void mnuThayDoiMK_Click(object sender, EventArgs e)
        {
            frm_ThayDoiMK frm = new frm_ThayDoiMK();
            if (Kiemtra("frm_ThayDoiMK"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.TenTK(layname());
                frm.Show();
            }
            frm.TaiKhoanND(layname());
        }
        //frm report điểm
        private void mnuDSDiem_Click(object sender, EventArgs e)
        {
            frm_DSDiem frm = new frm_DSDiem();
            if (Kiemtra("frm_DSDiem"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //Đăng xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frm_DangNhap fDN = new frm_DangNhap();
            Close();
            fDN.Focus();
        }

        private void btnThoát_Click(object sender, EventArgs e)
        {
            Close();
        }
        //frm tìm hs
        private void mnuTimHS_Click(object sender, EventArgs e)
        {
            frm_TimSV frm = new frm_TimSV();
            if (Kiemtra("frm_TimSV"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm tìm giáo viên
        private void mnuTimGV_Click(object sender, EventArgs e)
        {
            frm_TimGV frm = new frm_TimGV();
            if (Kiemtra("frm_TimGV"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm tìm lớp
        private void mnuTimLop_Click(object sender, EventArgs e)
        {
            frm_TimLop frm = new frm_TimLop();
            if (Kiemtra("frm_TimLop"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        private void frm_QuanLyDiem_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát chương trình hay không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //đăng xuất
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            frm_DangNhap fDN = new frm_DangNhap();
            Close();
            fDN.Focus();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //frm học lực
        private void mnuHocLuc_Click(object sender, EventArgs e)
        {
            frm_HocLuc frm = new frm_HocLuc();
            if (Kiemtra("frm_HocLuc"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        //frm hạnh kiểm
        private void mnuHanhKiem_Click(object sender, EventArgs e)
        {
            frm_HanhKiem frm = new frm_HanhKiem();
            if (Kiemtra("frm_HanhKiem"))
            {
                frm.Focus();
                frm.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
