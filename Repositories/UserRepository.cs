﻿using D3___Avaliação.Interfaces;
using D3___Avaliação.Models;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace D3___Avaliação.Repositories
{
    internal class UserRepository : IUser
    {
        private readonly string stringConexao = "Server=labsoft.pcs.usp.br; Initial Catalog=db_3; User id=usuario_3; pwd=46210566898;";
        public Boolean Login(User user)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string query = "SELECT * FROM Users WHERE Email=@Email AND PWD=@Pwd";

                SqlDataReader queryResult;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Pwd", user.Pwd);

                    con.Open();

                    queryResult = cmd.ExecuteReader();

                    if (queryResult.HasRows)
                    {
                        
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
