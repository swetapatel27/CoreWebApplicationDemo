using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CoreWebApplication1.Models
{
    public class EmployeeModel
    {

        SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=employee;Integrated Security=True;Pooling=False");

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Dept")]
        public string Department { get; set; }
        [Required(ErrorMessage = "please enter salary")]
        [Range(5000, 50000, ErrorMessage = "Value should be between 5k to 50k")]
        public int Salary { get; set; }


        public List<EmployeeModel> getData()
        {
            List<EmployeeModel> lstEmp = new List<EmployeeModel>();

            SqlDataAdapter apt = new SqlDataAdapter("select * from tbl_emp", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new EmployeeModel { Id = Convert.ToInt32(dr["Id"].ToString()), Name = dr["Name"].ToString(), Department = dr["Dept"].ToString(), Salary = Convert.ToInt32(dr["Salary"].ToString()) });
            }

            return lstEmp;
        }


        public bool AddEmp(EmployeeModel Emp)
        {

            SqlCommand cmd = new SqlCommand("insert into tbl_emp values(@name,@dept,@salary)", con);
            cmd.Parameters.AddWithValue("@name", Emp.Name);
            cmd.Parameters.AddWithValue("@dept", Emp.Department);
            cmd.Parameters.AddWithValue("@salary", Emp.Salary);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }


            return false;
        }


        public EmployeeModel getData(string Id)
        {
            EmployeeModel emp = new EmployeeModel();
            SqlCommand cmd = new SqlCommand("select * from tbl_emp where id='" + Id + "'", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["Id"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Department = dr["Dept"].ToString();
                    emp.Salary = Convert.ToInt32(dr["Salary"].ToString());
                }
            }
            con.Close();
            return emp;
        }


        //[Required(ErrorMessage = "Please enter Name")]
        //[Display(Name = "Enter Name:")]
        //public string Name { get; set; }
        //[Required]
        //public string Department { get; set; }
        //[Required(ErrorMessage = "Please enter Salary")]
        //[Range(2000, 10000, ErrorMessage = "Salary must be between 2k to 10K")]
        //public int Salary { get; set; }
    }
}
