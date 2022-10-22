using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MVCMovies.Models;

namespace MVCMovies.DatabaseHelper
{
    public class DatabaseHelper
    {
        const string servidor = @"DESKTOP-DLLS4QS";
        const string baseDatos = "MVCMovies";
        const string strConexion = "Data Source=" + servidor + ";Initial Catalog=" + baseDatos + ";Integrated Security=True";

        public static List<Movies> GetMovies()
        {
            DataTable ds = ExecuteStoreProcedure("spGetMovies", null);

            List<Movies> movies = new List<Movies>();

            foreach (DataRow dr in ds.Rows)
            {
                movies.Add(new Movies()
                {
                    IdMovie = Convert.ToInt32(dr["IdMovie"]),
                    Name = dr["Name"].ToString(),
                    Genere = dr["Genere"].ToString(),
                    Date = dr["Date"].ToString(),
                    Photo = dr["Photo"].ToString()
                });
            }
            return movies;

        }

        public static List<Movies> GetIDMovies(int IdMovie)
        {
            List<SqlParameter> param = new List<SqlParameter>()
                {
                    new SqlParameter("@IdMovie", IdMovie)
                };

            DataTable ds = ExecuteStoreProcedure("spGetIDMovie", param);

            List<Movies> movies = new List<Movies>();

            foreach (DataRow dr in ds.Rows)
            {
                movies.Add(new Movies()
                {
                    IdMovie = Convert.ToInt32(dr["IdMovie"]),
                    Name = dr["Name"].ToString(),
                    Genere = dr["Genere"].ToString(),
                    Date = dr["Date"].ToString(),
                    Photo = dr["Photo"].ToString()
                });
            }
            return movies;

        }

        public static bool CreateMovie(Movies movies)
        {
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
                {
                    new SqlParameter("@IdMovie", movies.IdMovie),
                    new SqlParameter("@Name", movies.Name),
                    new SqlParameter("@Genere", movies.Genere),
                    new SqlParameter("@Date", movies.Date),
                    new SqlParameter("@Photo", movies.Photo)
                };

                ExecStoreProcedure("spCreateMovie", param);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool EditMovie(Movies movies)
        {
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
                {
                    new SqlParameter("@IdMovie", movies.IdMovie),
                    new SqlParameter("@Name", movies.Name),
                    new SqlParameter("@Genere", movies.Genere),
                    new SqlParameter("@Date", movies.Date)
                };

                ExecStoreProcedure("spUpdateMovie", param);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(int IdMovie)
        {
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
                {
                    new SqlParameter("@IdMovie", IdMovie)
                };

                ExecStoreProcedure("spDeleteMovie", param);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdatePhoto(int IdMovie, IFormFile photo)
        {
            try
            {
                string PhotoMovie = Path.Combine("/images/", IdMovie + new FileInfo(photo.FileName).Extension);

                using (var stream = new FileStream(Directory.GetCurrentDirectory() + "\\wwwroot\\" + PhotoMovie, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }

                List<SqlParameter> param = new List<SqlParameter>()
                {
                    new SqlParameter("@IdMovie", IdMovie),
                    new SqlParameter("@Photo", PhotoMovie)
                };

                ExecStoreProcedure("spUpdatePhoto", param);

                return true;
            }
            catch
            {
                return false;
            }
        }



        public static bool DeletePhoto(int IdMovie, string Photo)
        {
            try
            {
                string photo = "/images/0.jpg";

                List<SqlParameter> param = new List<SqlParameter>()
                {
                    new SqlParameter("@IdMovie", IdMovie),
                    new SqlParameter("@Photo", photo)
                };

                ExecStoreProcedure("spUpdatePhoto", param);

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Para select 
        public static DataTable ExecuteStoreProcedure(string procedure, List<SqlParameter> param)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConexion))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (SqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }

        public static void ExecStoreProcedure(string procedure, List<SqlParameter> param)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConexion))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (SqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}