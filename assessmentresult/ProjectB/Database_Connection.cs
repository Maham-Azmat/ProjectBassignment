using System;
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
        public List<attendence> Listofclassattendance(string commandText)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(commandText, connection);
            List<attendence> clolist = new List<attendence>();
            var reader = Getdata(commandText);
            while (reader.Read())
            {
                attendence c = new attendence();
                c.Attenid = reader.GetInt32(0);
                c.Date = reader.GetDateTime(1);
                clolist.Add(c);
            }
            return clolist;
        }
        public List<asscomp> Listofassessmentcomp(string commandText)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(commandText, connection);
            List<asscomp> clolist = new List<asscomp>();
            var reader = Getdata(commandText);
            while (reader.Read())
            {
                asscomp c = new asscomp();
                c.Id = reader.GetInt32(0);
                c.Name = reader.GetString(1);
                c.Rubricid = reader.GetInt32(2);
                c.Totalmarks = reader.GetInt32(3);
                c.Datecreated = reader.GetDateTime(4);
                c.Dateupdated = reader.GetDateTime(5);
                c.Assessmentid = reader.GetInt32(6);
                clolist.Add(c);
            }
            return clolist;
        }
        public List<assesment> Listofassessment(string commandText)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(commandText, connection);
            List<assesment> clolist = new List<assesment>();
            var reader = Getdata(commandText);
            while (reader.Read())
            {
                assesment c = new assesment();
                c.Id = reader.GetInt32(0);
                c.Title = reader.GetString(1);
                c.Datecreated = reader.GetDateTime(2);
                c.Totalmarks = reader.GetInt32(3);
                c.Totalweightage = reader.GetInt32(4);
                clolist.Add(c);
            }
            return clolist;
        }
        public List<rubriclevel> Listoflevel(string commandText)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(commandText, connection);
            List<rubriclevel> clolist = new List<rubriclevel>();
            var reader = Getdata(commandText);
            while (reader.Read())
            {
                rubriclevel c = new rubriclevel();
                c.Id = reader.GetInt32(0);
                c.Rubricid = reader.GetInt32(1);
                c.Details = reader.GetString(2);
                c.Measurementlevel = reader.GetInt32(3);
                

                clolist.Add(c);
            }
            return clolist;
        }
        public List<CLO> ListofClos(string commandText)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(commandText, connection);
            List<CLO> clolist = new List<CLO>();
            var reader = Getdata(commandText);
            while (reader.Read())
            {
                CLO c = new CLO();
                c.Id = reader.GetInt32(0);
                c.Name = reader.GetString(1);
                c.Datecreated = reader.GetDateTime(2);
                c.Dateupdated = reader.GetDateTime(3);
                
                clolist.Add(c);
            }
            return clolist;
        }
        public List<Addrubrics> Listofrubric(string commandText)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(commandText, connection);
            List<Addrubrics> clolist = new List<Addrubrics>();
            var reader = Getdata(commandText);
            while (reader.Read())
            {
                Addrubrics c = new Addrubrics();
                c.Id = reader.GetInt32(0);
                c.Detail = reader.GetString(1);
                c.Cloid = reader.GetInt32(2);

                clolist.Add(c);
            }
            return clolist;
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
