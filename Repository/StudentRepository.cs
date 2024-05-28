using MegaExam.Models;
using Microsoft.Data.SqlClient;

namespace MegaExam.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _conn;

        public StudentRepository(IConfiguration configuration)
        {
            _conn = configuration.GetConnectionString("DefaultConnection");
        }
        //Student Insert Method
        public bool StudInsert(StudentModel stud)
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                try
                {
                    conn.Open();
                    //var cmd = new SqlCommand("insert into t_student(c_name,c_email,c_phone,c_address,c_state,c_city) values(@c_name,@c_email,@c_phone,@c_address,@c_state,@c_city)", conn);
                    var cmd = new SqlCommand("InsertStudent", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@c_name", stud.c_name);
                    cmd.Parameters.AddWithValue("@c_email", stud.c_email);
                    cmd.Parameters.AddWithValue("@c_phone", stud.c_phone);
                    cmd.Parameters.AddWithValue("@c_address", stud.c_address);
                    cmd.Parameters.AddWithValue("@c_state", stud.c_state);
                    cmd.Parameters.AddWithValue("@c_city", stud.c_city);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while insert record:" + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //Student Update Method
        public bool StudUpdate(StudentModel stud)
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                try
                {
                    conn.Open();
                    //var cmd = new SqlCommand("update t_student set c_name=@c_name,c_email=@c_email,c_phone=@c_phone,c_address=@c_address,c_state=@c_state,c_city=@c_city where c_sid=@c_sid", conn);
                    var cmd = new SqlCommand("UpdateStudent", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@c_sid", stud.c_sid);
                    cmd.Parameters.AddWithValue("@c_name", stud.c_name);
                    cmd.Parameters.AddWithValue("@c_email", stud.c_email);
                    cmd.Parameters.AddWithValue("@c_phone", stud.c_phone);
                    cmd.Parameters.AddWithValue("@c_address", stud.c_address);
                    cmd.Parameters.AddWithValue("@c_state", stud.c_state);
                    cmd.Parameters.AddWithValue("@c_city", stud.c_city);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while update record:" + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //Student Delete Method
        public bool StudDelete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                try
                {
                    conn.Open();
                    //var cmd = new SqlCommand("delete from t_student where c_sid=@c_sid", conn);
                    var cmd = new SqlCommand("DeleteStudent", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@c_sid", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while delete record:" + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //Student GetAll Method
        public List<StudentModel> GetAllStud()
        {
            var studList = new List<StudentModel>();
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                try
                {
                    conn.Open();
                    //var cmd = new SqlCommand("select * from t_student", conn);
                    var cmd = new SqlCommand("GetAllStudents", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var stud = new StudentModel
                        {
                            c_sid = Convert.ToInt32(dr["c_sid"]),
                            c_name = dr["c_name"].ToString(),
                            c_email = dr["c_email"].ToString(),
                            c_phone = Convert.ToInt64(dr["c_phone"]),
                            c_address = dr["c_address"].ToString(),
                            c_state = dr["c_state"].ToString(),
                            c_city = dr["c_city"].ToString(),

                        };
                        studList.Add(stud);
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetch record:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return studList;
        }
        //Student fetch particular Method
        public StudentModel FetchbyId(int id)
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                try
                {
                    conn.Open();
                    //var cmd = new SqlCommand("select * from t_student where c_sid=@c_sid", conn);
                    var cmd = new SqlCommand("GetStudentById", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@c_sid", id);
                    var dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        var stud = new StudentModel
                        {
                            c_sid = Convert.ToInt32(dr["c_sid"]),
                            c_name = dr["c_name"].ToString(),
                            c_email = dr["c_email"].ToString(),
                            c_phone = Convert.ToInt64(dr["c_phone"]),
                            c_address = dr["c_address"].ToString(),
                            c_state = dr["c_state"].ToString(),
                            c_city = dr["c_city"].ToString(),

                        };
                        return stud;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetch by id record:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return null;
        }
    }
}
