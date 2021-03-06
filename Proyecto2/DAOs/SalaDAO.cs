using MySql.Data.MySqlClient;
using Proyecto2.Database;
using Proyecto2.Models;
using System;
using System.Collections.Generic;

namespace Proyecto2.DAOs
{
    public class SalaDAO : ProyectoDBContext
    {
        public List<Sala> GetAllSalas()
        {
            try
            {
                List<Sala> listAll = new List<Sala>();
            
                MySqlConnection connection = GetConnection();
                string query = "select * from salas";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60;
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listAll.Add(
                            new Sala(
                            Convert.ToInt32(reader["id"]),
                            reader["nombre"].ToString()
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

        public Sala GetSalaById(int _id)
        {
            try
            {

                MySqlConnection connection = GetConnection();
                string query = $"select * from salas where id = '{_id}'";
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
                    return new Sala(
                        Convert.ToInt32(reader["Id"]),
                        reader["nombre"].ToString()
                    );
                }
                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySqlException: '{ex.Code} - ' '{ex.Message}'");
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool addNewSala(Sala sala)
        {
            try
            {
                MySqlConnection connection = GetConnection();
                string query = "insert into salas (nombre) values(@nombre)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", sala.Nombre);
                cmd.CommandTimeout = 60;
                connection.Open();
                int rowCount  = cmd.ExecuteNonQuery();

                if (rowCount == 1)//Successful
                {
                    return true;
                }
                else//Unsuccessfull
                {
                    return false;
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySqlException: '{ex.Code} - ' '{ex.Message}'");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MySqlException: '{ex.ToString()} --- ' '{ex.Message}'");

                return false; ;
            }
        }
    }
}
