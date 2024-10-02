using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT * FROM USUARIO";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Nombres = dr["Nombres"] != DBNull.Value ? dr["Nombres"].ToString() : string.Empty,
                                Apellidos = dr["Apellidos"] != DBNull.Value ? dr["Apellidos"].ToString() : string.Empty,
                                Correo = dr["Correo"] != DBNull.Value ? dr["Correo"].ToString() : string.Empty,
                                Clave = dr["Clave"] != DBNull.Value ? dr["Clave"].ToString() : string.Empty,
                                Reestablecer = dr["Reestablecer"] != DBNull.Value ? Convert.ToBoolean(dr["Reestablecer"]) : false,
                                Activo = dr["Activo"] != DBNull.Value ? Convert.ToBoolean(dr["Activo"]) : false
                            });
                        }
                    }
                }
            }catch (SqlException ex)
            {
                Console.WriteLine($"SqlException: {ex.Message}");
                Console.WriteLine($"Error Number: {ex.Number}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
            return lista;
        }
    }
}
