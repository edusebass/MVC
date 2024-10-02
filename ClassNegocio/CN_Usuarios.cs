using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace ClassNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDato = new CD_Usuarios();

        public List<Usuario> Listar()
        {
            try
            {
                List<Usuario> lista = objCapaDato.Listar();
                Console.WriteLine($"CN_Usuarios: Se obtuvieron {lista.Count} usuarios");
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CN_Usuarios.Listar: {ex.Message}");
                throw; // Re-lanza la excepción para que pueda ser manejada en niveles superiores
            }
        }
    }
}