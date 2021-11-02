using Nhom5Project.DAO;
using Nhom5Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5Project
{
    public partial class Form1 : Form
    {
        StuManager stu;
        public Form1()
        {
            InitializeComponent();
            stu = new StuManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // lúc load form thì gọi hàm lấy danh sách id sinh viên để vào combobox
            comboBox1.Items.AddRange(stu.GetListID().Cast<object>().ToArray()); // do add vào combobox hệ thống bắt buộc là kiểu array object nên mình phải ép kiểu
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // xử lí khi chọn comobox
            var idSl = comboBox1.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(idSl))//check khac null hoac "" thi lam
            {
                var student = stu.getSVByID(int.Parse(idSl));
                if (student != null)
                {
                    string hoSv = student.TEN.Split(' ')[0]; // cắt khoảng trắng của tên và lấy chữ đầu
                    string tenSv = student.TEN.Replace(hoSv,"").Trim();// bỏ họ đi ta đc tên sv
                    string ngaySinh = DateTime.Parse(student.NAMSINH.ToString()).ToString("dd/MM/yyyy");
                    string gioiTinh = (bool)student.GIOITINH ? "Nam" : "Nữ"; // true là nam , flase là nữ
                    string maKhoa = student.KHOA.MAKHOA;
                    textBox1.Text = hoSv;
                    textBox2.Text = tenSv;
                    textBox3.Text = ngaySinh;
                    textBox4.Text = gioiTinh;
                    textBox5.Text = maKhoa;

                    // phần này của gird view

                    var lst = new List<StudentGV>();
                    foreach (var item in student.KQUAs.Select(x=>x.HPHAN)) // chay ds hoc phan trong ket qua cua svien
                    {
                        string maMh = item.MAMH;
                        string tenMh = item.MHOC.TENMH;
                        double diem = (double)item.KQUAs.Where(x => x.MAHP == item.MAHP).FirstOrDefault().DIEM;
                        var stukq = new StudentGV()
                        {
                            MaMh = maMh,
                            TenMh = tenMh,
                            DiemThi = diem
                        };
                        lst.Add(stukq);
                        
                    }
                    BindingSource binding = new BindingSource();
                    binding.DataSource = lst;

                    //bind datagridview to binding source
                    dataGridView1.DataSource = binding;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = textBox6.Text;
            var studendF = stu.findSv(data);
            ClearAll();
             if(studendF.Any())
            {
                comboBox1.Items.AddRange(studendF.Select(x=>x.MASV).ToArray().Cast<object>().ToArray());
                comboBox1.Text = studendF[0].MASV.ToString();
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Sinh Viên Nào");
            }
        }
        private void ClearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            dataGridView1.DataSource = null;
        }
    }
}
