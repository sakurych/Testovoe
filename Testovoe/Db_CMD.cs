﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    internal class Db_CMD
    {
        public static int sumRKK = 0;
        public static int sumObr = 0;
        public static int total = 0;
        public static int count = 0;

        public void addRKK(string otv_)
        {
            DbConnect db = new DbConnect();
            db.ConnectSql();
            db.sqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Table] WHERE  Otv= @Otv", db.sqlConnection);
            command.Parameters.AddWithValue("Otv", otv_);
            if ((int)command.ExecuteScalar() != 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Table] SET RKK = RKK + 1 WHERE Otv=@Otv", db.sqlConnection);
                cmd.Parameters.AddWithValue ("Otv", otv_);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Table] (Otv, RKK, Obrach) VALUES (@Otv, 1, 0)", db.sqlConnection);
                cmd.Parameters.AddWithValue("Otv", otv_);
                cmd.ExecuteNonQuery();
            }
            db.sqlConnection.Close();
        }

        public void addObr(string otv_)
        {
            DbConnect db = new DbConnect();
            db.ConnectSql();
            db.sqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Table] WHERE Otv=@Otv", db.sqlConnection);
            command.Parameters.AddWithValue("Otv", otv_);
            if ((int)command.ExecuteScalar() != 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Table] SET Obrach = Obrach + 1 WHERE Otv=@Otv", db.sqlConnection);
                cmd.Parameters.AddWithValue("Otv", otv_);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Table] (Otv, Obrach, RKK) VALUES (@Otv, 1, 0)", db.sqlConnection);
                cmd.Parameters.AddWithValue("Otv", otv_);
                cmd.ExecuteNonQuery();
            }
            db.sqlConnection.Close();
        }

        public void setSum()
        {
            List<int> list = new List<int>();
            List<int> list1 = new List<int>();
            DbConnect db = new DbConnect();
            db.ConnectSql();
            db.sqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT RKK FROM [Table]", db.sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add((int)(reader.GetValue(0)));
                    sumRKK += (int)reader.GetValue(0);
                }
            }
            reader.Close();

            SqlCommand command1 = new SqlCommand("SELECT Obrach FROM [Table]", db.sqlConnection);
            SqlDataReader reader1 = command1.ExecuteReader();

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    list1.Add((int)(reader1.GetValue(0)));
                    sumObr += (int)(reader1.GetValue(0));
                }
            }
            reader1.Close();

            for(int i =0; i < list.Count; i++)
            {
                list[i] = list[i] + list1[i];
                total += list[i];
            }

            count = list.Count + 1;

            for (int i = 0; i < list.Count; i++)
            {
                int id = i + 1;
                SqlCommand command2 = new SqlCommand("UPDATE [Table] SET Kolvo = @Kolvo WHERE Id = @Id", db.sqlConnection);
                command2.Parameters.AddWithValue("Kolvo", list[i]);
                command2.Parameters.AddWithValue("Id", id);
                command2.ExecuteNonQuery();
            }
            db.sqlConnection.Close();
        }

        public void clearTable()
        {
            DbConnect db = new DbConnect();
            db.ConnectSql();
            db.sqlConnection.Open();

            SqlCommand command = new SqlCommand("TRUNCATE TABLE [Table]", db.sqlConnection);
            command.ExecuteNonQuery();

            db.sqlConnection.Close();
        }

        public void selectAll()
        {
            DbConnect db = new DbConnect();
            db.ConnectSql();
            db.sqlConnection.Open();

            SqlDataAdapter command = new SqlDataAdapter("SELECT * FROM [Table]", db.sqlConnection);

            db.sqlConnection.Close();
        }
    }
}