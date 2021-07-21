using MySql.Data.MySqlClient;
using Proyecto2.Database;
using Proyecto2.Models;
using System;
using System.Collections.Generic;

namespace Proyecto2.DAOs
{
    public class ProyeccionDAO : ProyectoDBContext
    {
        public List<Proyeccion>  GetAllProyecciones()
        {
            List<Proyeccion> listAll = new List<Proyeccion>();
            try
            {
                MySqlConnection connection = GetConnection();
                string query = "select * from proyecciones";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60;
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listAll.Add(
                            new Proyeccion(
                            Convert.ToInt32(reader["id"]),
                            Convert.ToInt32(reader["sala_id"]),
                            reader["fecha"].ToString(),
                            reader["hora"].ToString(),
                            Convert.ToInt32(reader["pelicula_id"])
                            ));
                    }
                    connection.Close();
                    return listAll;

                }
                else
                {
                    return null;

                }
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

        public Proyeccion GetProyeccionById(int _id)
        {
            try
            {


                MySqlConnection connection = GetConnection();
                string query = $"select * from proyecciones where id = '{_id}'";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60;
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Proyeccion u = new Proyeccion(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToInt32(reader["sala_id"]),
                            reader["fecha"].ToString(),
                            reader["hora"].ToString(),
                            Convert.ToInt32(reader["pelicula_id"])
                        );
                    return u;
                }
                return null;


            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySqlException: '{ex}'");
                return null;

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}