using System.Windows.Forms;
using System;

public partial class FormQuanLySuKien : Form
{
    public FormQuanLySuKien()
    {
        InitializeComponent();
    }

    private void btnTaoSuKien_Click(object sender, EventArgs e)
    {
        string tenSuKien = txtTenSuKien.Text;
        DateTime thoiGian = dtpThoiGian.Value;
        string diaDiem = txtDiaDiem.Text;
        string hinhThuc = rbtnOnline.Checked ? "Online" : "Offline";

        MessageBox.Show("Tạo sự kiện thành công!");
    }

    private void btnSuaSuKien_Click(object sender, EventArgs e)
    {
        
    }

    private void btnXoaSuKien_Click(object sender, EventArgs e)
    {
        // Chức năng xóa sự kiện đã tạo
    }
}
