﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectB
{
    class Database_Connection
    {
        private static Database_Connection instance;
        public string connectionstring;
        private SqlConnection connection;

        Database_Connection()
        {

        }

        public static Database_Connection get_instance()
        {
            if (instance == null)
            {
                instance = new Database_Connection();
            }
            return instance;
        }


        public SqlConnection Getconnection()
        {
            connection = new SqlConnection(connectionstring);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        public void close()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        public SqlDataReader Getdata(string query)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader data = cmd.ExecuteReader();
            return data;

        }

        public int Executequery(string query)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(query, connection);
            int row = cmd.ExecuteNonQuery();
            return row;
        }
        public List<Student> ListofStudents(string commandText)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(commandText, connection);
            List<Student> emplist = new List<Student>();
            var reader = Getdata(commandText);
            while (reader.Read())
            {
                Student emp = new Student();
                emp.Id = reader.GetInt32(0);
                emp.FirstName = reader.GetString(1);
                emp.LastName = reader.GetString(2);
                emp.Contact = reader.GetString(3);
                emp.Email = reader.GetString(4);
                emp.RegistrationNo = reader.GetString(5);
                emp.Status = reader.GetInt32(6);
                emplist.Add(emp);
            }
            return emplist;
        }
        public void Closeconnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
