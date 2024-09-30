
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Configuration;

namespace Sistema_scan_codigo_barras.Logica
{
    public class ProductoDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        private static ProductoDAO _instancia = null;

        public ProductoDAO() { }

        public static ProductoDAO Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ProductoDAO();
                }
                return _instancia;
            }
        }

        public byte[] ConvertirImagenABytes(string rutaImagen)
        {
            if (string.IsNullOrEmpty(rutaImagen))
            {
                return null;
            }

            try
            {
                using (FileStream fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    return br.ReadBytes((int)fs.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al convertir la imagen a bytes: " + ex.Message);
                return null;
            }
        }

        public bool guardarYactualizarProductos(Producto producto, bool isUpdate)
        {
            string sql = isUpdate
                ? "UPDATE Producto SET descripcion = @descripcion, categoriaProducto = @categoriaProducto, precio = @precio, marcaProducto = @marcaProducto, rutaImg = @rutaImg WHERE codigoBarras = @codigoBarras"
                : "INSERT INTO Producto (codigoBarras, descripcion, categoriaProducto, precio, marcaProducto, rutaImg) VALUES (@codigoBarras, @descripcion, @categoriaProducto, @precio, @marcaProducto, @rutaImg)";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(cadena))
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@codigoBarras", producto.codigoBarras);
                    cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                    cmd.Parameters.AddWithValue("@categoriaProducto", producto.categoriaProducto);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@marcaProducto", producto.marcaProducto);

                    if (producto.imagenBytes != null)
                    {
                        cmd.Parameters.AddWithValue("@rutaImg", producto.imagenBytes);
                    }
                    else
                    {
                        cmd.Parameters.Add("@rutaImg", DbType.Binary).Value = DBNull.Value;
                    }

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar o actualizar el producto: " + ex.Message);
                return false;
            }
        }

        public bool eliminarProducto(string codigoBarras)
        {
            string sql = "DELETE FROM Producto WHERE codigoBarras = @codigoBarras";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(cadena))
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigoBarras", codigoBarras);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el producto: " + ex.Message);
                return false;
            }
        }

        public byte[] buscarImgProducto(string codigoBarras)
        {
            string sql = "SELECT rutaImg FROM Producto WHERE codigoBarras = @codigoBarras";
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(cadena))
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigoBarras", codigoBarras);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? reader["rutaImg"] != DBNull.Value ? (byte[])reader["rutaImg"] : null : null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar la imagen del producto: " + ex.Message);
                return null;
            }
        }

        public Producto buscarProducto(string codigoBarras)
        {
            string sql = "SELECT * FROM Producto WHERE codigoBarras = @codigoBarras";
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(cadena))
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigoBarras", codigoBarras);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Producto
                            {
                                id_producto = int.Parse(reader["id_producto"].ToString()),
                                codigoBarras = reader["codigoBarras"].ToString(),
                                descripcion = reader["descripcion"].ToString(),
                                categoriaProducto = reader["categoriaProducto"].ToString(),
                                precio = float.Parse(reader["precio"].ToString()),
                                marcaProducto = reader["marcaProducto"].ToString(),
                                imagenBytes = reader["rutaImg"] != DBNull.Value ? (byte[])reader["rutaImg"] : null
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el producto: " + ex.Message);
                return null;
            }
        }
    }
}
