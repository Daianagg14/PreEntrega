using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PreEntrega.Modelo;

namespace PreEntrega
{
    class UsuarioHandler:DbHandler
    {
        public Usuario TraerUsuario (string nombreUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario";

                    sqlCommand.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table); //Se ejecuta el Select
                    sqlCommand.Connection.Close();
                    foreach (DataRow row in table.Rows)
                    {
                        Usuario usuario = new Usuario();
                        usuario.Nombre = row["Nombre"]?.ToString();
                        usuario.Apellido = row["Apellido"]?.ToString();
                        usuario.NombreUsuario = row["NombreUsuario"]?.ToString();
                        usuario.Mail = row["Mail"]?.ToString();
                        usuario.Contraseña = row["Contraseña"]?.ToString();

                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios?.FirstOrDefault();
        }

        public static Usuario Login()
        {
            Usuario usuario = new Usuario();
            UsuarioHandler uh = new UsuarioHandler();

            Console.WriteLine("Ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();


            if (uh.TraerUsuario(nombreUsuario) != null)
            {
                Console.WriteLine("Ingrese su contraseña:");
                string contraseña = Console.ReadLine();
                if (contraseña == uh.TraerUsuario(nombreUsuario).Contraseña)
                {
                    usuario.Nombre = uh.TraerUsuario(nombreUsuario).Nombre;
                    usuario.Apellido = uh.TraerUsuario(nombreUsuario).Apellido;
                    usuario.NombreUsuario = uh.TraerUsuario(nombreUsuario).NombreUsuario;
                    usuario.Mail = uh.TraerUsuario(nombreUsuario).Mail;
                    usuario.Contraseña = uh.TraerUsuario(nombreUsuario).Contraseña;
                }
            }

            return usuario;
        }
    }


    
}
