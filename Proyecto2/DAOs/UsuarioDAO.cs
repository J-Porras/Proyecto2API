using MySql.Data.MySqlClient;
using Proyecto2.Database;
using Proyecto2.Models;
using System;
using System.Collections.Generic;

namespace Proyecto2.DAOs
{
    public class UsuarioDAO : ProyectoDBContext
    {
        public List<Usuario> GetAllUsuario() 
        {
            List<Usuario> listAll = new List<Usuario>();
            try
            {
                MySqlConnection connection = GetConnection();
                string query = "select * from usuarios";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60;
                connection.Open();


                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listAll.Add(
                            new Usuario(
                            reader["Id"].ToString(),
                            reader["nombre"].ToString(),
                            reader["contrasenna"].ToString(),
                            Convert.ToInt32(reader["rol"])
                            ));
                    }

                }
                else
                {
                    return null;

                }
                connection.Close();
                return listAll;


            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySqlException: '{ex.Code} - ' '{ex}'");

                return null;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public Usuario GetUsuarioById(string id)
        {
            MySqlConnection connection = GetConnection();
            string query = $"select * from Usuarios where id = '{id}'";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.CommandTimeout = 60;
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                return null;
            }
            while (reader.Read())
            {
                Usuario u = new Usuario(
                    reader["Id"].ToString(),
                    reader["nombre"].ToString(),
                    reader["contrasenna"].ToString(),
                    Convert.ToInt32(reader["rol"])

                    );
                return u;
            }
            return null;

        }
    }
}