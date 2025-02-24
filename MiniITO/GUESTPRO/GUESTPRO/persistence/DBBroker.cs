using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.persistence
{
    internal class DBBroker
    {
        private static DBBroker instancia;
        private static MySql.Data.MySqlClient.MySqlConnection conexion;
        private const String cadenaConexion = "server=localhost;database=mydb;uid=root;pwd=oracle";

        private DBBroker()
        {
            conexion = new MySql.Data.MySqlClient.MySqlConnection(cadenaConexion);
        }

        public static DBBroker getInstancia()
        {
            if (instancia == null)
            {
                instancia = new DBBroker();
            }
            return instancia;
        }

        public void conectar()
        {
            if (DBBroker.conexion.State == System.Data.ConnectionState.Closed)
            {
                DBBroker.conexion.Open();
            }
        }

        public void desconectar()
        {
            if (DBBroker.conexion.State == System.Data.ConnectionState.Open)
            {
                DBBroker.conexion.Close();
            }
        }

        public List<Object> select(String query)
        {
            List<Object> resultado = new List<Object>();
            List<Object> fila;
            MySql.Data.MySqlClient.MySqlDataReader reader;
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, DBBroker.conexion);

            conectar();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                fila = new List<Object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    fila.Add(reader[i].ToString());
                }
                resultado.Add(fila);
            }
            desconectar();
            return resultado;
        }

        public int update(String query)
        {
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, DBBroker.conexion);
            int resultado;

            conectar();
            resultado = command.ExecuteNonQuery();
            desconectar();

            return resultado;

        }
    }
}
