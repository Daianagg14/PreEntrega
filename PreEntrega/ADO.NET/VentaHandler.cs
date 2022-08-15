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
    class VentaHandler:DbHandler
    {
        public Venta TraerVenta(int idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.Connection.Open();
                        sqlCommand.CommandText = "select v.Id, v.Comentarios from Venta v" +
                                                " join ProductoVendido pv on v.Id = pv.IdVenta" +
                                                " join Producto p on pv.IdProducto = p.Id" +
                                                " where p.IdUsuario = @id;";

                        sqlCommand.Parameters.AddWithValue("@id", idUsuario);

                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = sqlCommand;
                        DataTable table = new DataTable();
                        dataAdapter.Fill(table);
                        sqlCommand.Connection.Close();
                        foreach (DataRow row in table.Rows)
                        {
                            Venta venta = new Venta();
                            venta.Id = Convert.ToInt32(row["Id"]);
                            venta.Comentarios = row["Comentarios"]?.ToString();


                            ventas.Add(venta);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }

            return ventas?.FirstOrDefault();
        }
    }
}
