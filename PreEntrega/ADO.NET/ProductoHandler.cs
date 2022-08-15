using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PreEntrega.Modelo;

namespace PreEntrega

{
    class ProductoHandler : DbHandler
    {
        public Producto TraerProducto(int id)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.Connection.Open();
                        sqlCommand.CommandText = "SELECT * FROM Producto WHERE Id = @id;";

                        sqlCommand.Parameters.AddWithValue("@id", id);

                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = sqlCommand;
                        DataTable table = new DataTable();
                        dataAdapter.Fill(table);
                        sqlCommand.Connection.Close();
                        foreach (DataRow row in table.Rows)
                        {
                            Producto producto = new Producto();
                            producto.Id = Convert.ToInt32(row["Id"]);
                            producto.Descripciones = row["Descripciones"]?.ToString();
                            producto.Costo = Convert.ToDouble(row["Costo"]);
                            producto.PrecioVenta = Convert.ToDouble(row["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(row["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(row["IdUsuario"]);

                            productos.Add(producto);
                        }
                    }
                }
            }
            catch (Exception e)
            { 
            }
            return productos?.FirstOrDefault();
        }



        public Producto TraerProductoVendido(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            try 
            {
                

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.Connection.Open();
                        sqlCommand.CommandText = "select p.Id, p.Descripciones, p.Costo, p.PrecioVenta, p.Stock, p.IdUsuario" +
                                                " from Venta v" +
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
                            Producto producto = new Producto();
                            producto.Id = Convert.ToInt32(row["Id"]);
                            producto.Descripciones = row["Descripciones"]?.ToString();
                            producto.Costo = Convert.ToDouble(row["Costo"]);
                            producto.PrecioVenta = Convert.ToDouble(row["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(row["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(row["IdUsuario"]);

                            productos.Add(producto);
                        }
                    }
                }
                

            } 
            catch (Exception e)
            {
                
            }
            return productos?.FirstOrDefault();

        }

    }
}