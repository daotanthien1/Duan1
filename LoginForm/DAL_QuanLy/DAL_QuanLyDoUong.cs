﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_QuanLyDoUong : DBConnect
    {

        public bool InsertDoUong(DTO_QuanLyDoUong du)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BeverageInsert";
                cmd.Parameters.AddWithValue("Name", du.Name);
                cmd.Parameters.AddWithValue("Price", du.Price);
                cmd.Parameters.AddWithValue("id_type", du.Id_Type);
                cmd.Parameters.AddWithValue("image", du.Image);
               
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool UpdateDoUong(DTO_QuanLyDoUong du)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BeverageUpdate";
                cmd.Parameters.AddWithValue("Name", du.Name);
                cmd.Parameters.AddWithValue("Price", du.Price);
                cmd.Parameters.AddWithValue("id_type", du.Id_Type);
                cmd.Parameters.AddWithValue("image", du.Image);
                cmd.Parameters.AddWithValue("id_beverage", du.Id_Beverage);
                cmd.Connection = _conn;
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool DeleteDoUong(string name)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BeverageDelete";
                cmd.Parameters.AddWithValue("Name", name);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public DataTable SearchDoUong(string name)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BeverageSearch";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Connection = _conn;
                DataTable dtDoUong = new DataTable();
                dtDoUong.Load(cmd.ExecuteReader());
                return dtDoUong;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
