using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5Project.DAO
{

    public class StuManager
    {
        QLSVienEntities ql = new QLSVienEntities();

        public int[] GetListID()
        {
            try
            {
                //lấy danh sách id sinh viên
                return ql.SVIENs.Select(x => x.MASV).ToArray();
            }
            catch (Exception)
            {
                // lỗi thì return List id trống
                return new int[] { };
            }

        }
        public SVIEN getSVByID(int id)
        {
            try
            {
                return ql.SVIENs.Where(x => x.MASV == id).FirstOrDefault(); // first or default nghĩa là chỉ lấy 1 cái nếu get lên được nhiều
            }
            catch (Exception)
            {
                // lỗi thì return null
                return null;
            }
        }
        public List<SVIEN> findSv(string data = "")
        {
            data= data.ToLower();
            return ql.SVIENs.Where(x =>
                x.TEN.Contains(data) ||
                x.MASV.ToString().Contains(data) ||
                x.NAMSINH.ToString().Contains(data) ||
                x.KHOA.MAKHOA.ToLower().Contains(data)||
                x.KHOA.TENKHOA.ToLower().Contains(data)
                ).ToList();
        }
    }
}
