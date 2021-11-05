using DAL_QuanLy;
using DTO_QuanLy;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            return dalNhanVien.NhanVienDangNhap(nv);
        }
        public bool NhanVienQuenMatKhau(string email)
        {
            return dalNhanVien.NhanVienQuenMatKhau(email);
        }
        public bool NhanVienQuenMatKhau(string email, string oldPassWord, string newPassWord)
        {
            return dalNhanVien.NhanVienDoiMatKhau(email,oldPassWord, newPassWord);
        }
        public bool InsertNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.InsertNhanVien(nv);
        }
        public bool UpdateNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.UpdateNhanVien(nv);
        }
        public bool DeleteNhanVien(string email)
        {
            return dalNhanVien.DeleteNhanVien(email);
        }
        public DataTable SearchNhanVien(string name)
        {
            return dalNhanVien.SearchNhanVien(name);
        }
    }
}
