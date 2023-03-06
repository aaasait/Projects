using TodoWebApi.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoWebApi.Data
{
    public  class TodoDal
    {
         //SqlConnection con = new SqlConnection(ConnectingString.GetConnectingString);
         SqlCommand cmd;
        public async Task<List<TodoDto>> GetTodo()
        {
            string sql = "SELECT id,name,complated FROM Todos";

             List<TodoDto> todos = new List<TodoDto>();

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectingString.GetConnectingString))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlDataReader dr = await cmd.ExecuteReaderAsync();
                        while (dr.Read())
                        {

                            var todos1 = new TodoDto
                            {

                                Id = dr.GetInt32(dr.GetOrdinal("id")),
                                Name = dr.GetString(dr.GetOrdinal("name")),
                                Complated = dr.GetInt32(dr.GetOrdinal("complated"))


                            };

                            todos.Add(todos1);

                        }
                    }

                }
            }
            catch
            {
                throw;
            }
            
            return todos;
        }
        public async Task<List<TodoDto>> GetTodo(int id)
        {
            string sql = "SELECT id,name,complated FROM Todos WHERE id="+id;

            List<TodoDto> todos = new List<TodoDto>();

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectingString.GetConnectingString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlDataReader dr = await cmd.ExecuteReaderAsync();
                        while (dr.Read())
                        {

                            var todos1 = new TodoDto
                            {

                                Id = dr.GetInt32(dr.GetOrdinal("id")),
                                Name = dr.GetString(dr.GetOrdinal("name")),
                                Complated = dr.GetInt32(dr.GetOrdinal("complated"))


                            };

                            todos.Add(todos1);

                        }
                    }
                                  
                }
            }
            catch
            {
                throw;
            }

            return todos;
        }

        public async Task<bool> DeleteTodo(int id)
        {
           
            try
            {
                bool resultBool =false;
                using (SqlConnection con = new SqlConnection(ConnectingString.GetConnectingString))
                {
                   
                    string sql = "DELETE FROM Todos WHERE id = " + id;
                    using(SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        int result = await cmd.ExecuteNonQueryAsync();
                        if (result > 0)
                        {
                            resultBool = true;
                        }
                        else
                        {
                            resultBool = false;
                        }
                        return resultBool;
                    }
                    
                   
                }
            }
            catch
            {
                throw;
            }
       
            
        }

        public  async Task<bool> InsertTodo(TodoDto Todo)
        {
            try
            {
                string sql = "INSERT INTO Todos(name,complated) VALUES(@Name,@Complated)";
                using (SqlConnection con = new SqlConnection(ConnectingString.GetConnectingString))
                {

                    using (SqlCommand cmd=new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", Todo.Name);
                        cmd.Parameters.AddWithValue("@Complated", Todo.Complated);
                        con.Open();
                        int result=  await cmd.ExecuteNonQueryAsync();

                        if (result > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> UpdateTodo(TodoDto Todo)
        {
            try
            {
                string sql = "UPDATE Todos SET name=@Name,complated=@Complated WHERE id=@ID";
                using (SqlConnection con = new SqlConnection(ConnectingString.GetConnectingString))
                {

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", Todo.Id);
                        cmd.Parameters.AddWithValue("@Name", Todo.Name);
                        cmd.Parameters.AddWithValue("@Complated", Todo.Complated);
                        con.Open();
                        int result = await cmd.ExecuteNonQueryAsync();

                        if (result > 0)
                        {
                            return  true;
                        }
                        return false;
                    }
                }
            }
            catch
            {

                throw;
            }
        }
    }
}
