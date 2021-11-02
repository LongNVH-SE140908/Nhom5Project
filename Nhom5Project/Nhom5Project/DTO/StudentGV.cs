using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5Project.DTO
{
    // class này để lấy những thứ cần thiết để hiện gird view
    public class StudentGV
    {
        [DisplayName("Mã Môn Học")] // hàm này để khi code tự chạy nó sẽ lấy tên theo tên mình đặt, không có thì nó sẽ lấy tên theo tên vd "MaMh"
        public string MaMh { get; set; }
        [DisplayName("Tên Môn Học")]
        public string TenMh { get; set; }
        [DisplayName("Điểm Thi")]
        public double DiemThi{ get; set; }

        public StudentGV()
        {
        }

        public StudentGV(string maMh, string tenMh, double diemThi)
        {
            MaMh = maMh;
            TenMh = tenMh;
            DiemThi = diemThi;
        }
    }
}
