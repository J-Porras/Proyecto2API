using MySql.Data.MySqlClient;
using Proyecto2.Database;
using Proyecto2.Models;
using System;
using System.Collections.Generic;

namespace Proyecto2.DAOs
{
    public class PeliculaDAO : ProyectoDBContext
    {
        public List<Pelicula> getAllPeliculas()
        {
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
                    List<Pelicula> listAll = new List<Pelicula>();

                    while (reader.Read())
                    {
                        listAll.Add(
                            new Pelicula(
                                Convert.ToInt32(reader["id"]),
                                reader["nombre"].ToString(),
                                Convert.ToInt32(reader["precio"]),
                                Convert.ToBoolean(reader["cartelera"])
                                 
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
            catch (Exception e)
            {

                return null;
            }


        }


        public Pelicula getPeliculabyId(int _id)
        {
            try
            {

                MySqlConnection connection = GetConnection();
                string query = $"select * from salas where id = '{_id}'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60;
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return new Pelicula(
                         Convert.ToInt32(reader["id"]),
                         reader["nombre"].ToString(),
                         Convert.ToInt32(reader["precio"]),
                         Convert.ToBoolean(reader["cartelera"])
                    );

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
    }
}