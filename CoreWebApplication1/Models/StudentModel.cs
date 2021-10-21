using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace CoreWebApplication1.Models
{


    public class StudentModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=student;Integrated Security=True;Pooling=False");
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(18, 30, ErrorMessage = "18-30")]
        public int Age { get; set; }
        [Required]
        [Range(1, 8)]
        public int Sem { get; set; }

        public bool Save(StudentModel stud)
        {


            SqlCommand cmd = new SqlCommand("insert into tbl_stud values(@name,@email,@age,@sem)", con);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@email", stud.Email);
            cmd.Parameters.AddWithValue("@age", stud.Age);
            cmd.Parameters.AddWithValue("@sem", stud.Sem);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<StudentModel> getData()
        {
            List<StudentModel> stud = new List<StudentModel>();

            SqlDataAdapter apt = new SqlDataAdapter("select * from tbl_stud ", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                stud.Add(new StudentModel { Name = dr["name"].ToString(), Email = dr["email"].ToString(), Age = Convert.ToInt32(dr["age"].ToString()), Sem = Convert.ToInt32(dr["sem"].ToString()) });
            }


            return stud;
        }




    }
}
