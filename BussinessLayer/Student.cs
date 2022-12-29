using System;
using System.Data;
using CRUD.DataAccessLayer;

namespace CRUD.BussinessLayer
{
    class Student
    {
        public static int Insert(string name, string gender, DateTime dob, string contact, string address, string city)
        {
            return DAL.ExecuteNonQuery(
                    "SP_Insert", CommandType.StoredProcedure,
                    DAL.CreateParameter("@name", SqlDbType.VarChar, name),
                    DAL.CreateParameter("@gender", SqlDbType.VarChar, gender),
                    DAL.CreateParameter("@dob", SqlDbType.DateTime, dob),
                    DAL.CreateParameter("@contact", SqlDbType.VarChar, contact),
                    DAL.CreateParameter("@address", SqlDbType.VarChar, address),
                    DAL.CreateParameter("@city", SqlDbType.VarChar, city)
                );
        }

        public static int Update(int id, string name, string gender, DateTime dob, string contact, string address, string city)
        {
            return DAL.ExecuteNonQuery(
                    "SP_Update", CommandType.StoredProcedure,
                    DAL.CreateParameter("@id", SqlDbType.Int, id),
                    DAL.CreateParameter("@name", SqlDbType.VarChar, name),
                    DAL.CreateParameter("@gender", SqlDbType.VarChar, gender),
                    DAL.CreateParameter("@dob", SqlDbType.DateTime, dob),
                    DAL.CreateParameter("@contact", SqlDbType.VarChar, contact),
                    DAL.CreateParameter("@address", SqlDbType.VarChar, address),
                    DAL.CreateParameter("@city", SqlDbType.VarChar, city)
                );
        }

        public static int Delete(int id)
        {
            return DAL.ExecuteNonQuery("SP_Delete", CommandType.StoredProcedure, DAL.CreateParameter("@id", SqlDbType.Int, id));
        }

        public static DataTable SelectAll()
        {
            return DAL.ExecuteTable("SP_SelectAll", CommandType.StoredProcedure);
        }

        public static DataTable Search(string search)
        {
            return DAL.ExecuteTable("SP_Search", CommandType.StoredProcedure, DAL.CreateParameter("@search", SqlDbType.VarChar, search));
        }


    }
}