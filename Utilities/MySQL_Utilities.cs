using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace Utilities
{
    public class MySQL_Utilities
    {
        MySqlCommand Query = new MySqlCommand();
        MySqlConnection Conexion;
        MySqlDataReader consultar;
        //public string sql = "Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
        //public string sql = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
        public string sql = ConfigurationManager.AppSettings["MySQLEnvironment"].ToString();

        private void testConnection()
        {
            try
            {
                Conexion = new MySqlConnection();
                Conexion.ConnectionString = sql;
                Conexion.Open();
                //MessageBox.Show("Conexion correcta","MySQL Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /*
        public void MySQL_Statement()
        {
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT idProyecto FROM tb_seguimiento";
            con.Open();
            cmd.ExecuteNonQuery();
        }
        */

        public void SelectAllFrom(string query, DataGridView dgv)
        {
            testConnection();

            DataTable _dataTable = new DataTable();
            _dataTable.Clear();

            try
            {
                MySqlConnection _conn = new MySqlConnection(sql);
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand
                {
                    Connection = _conn,
                    CommandText = query
                };
                _cmd.ExecuteNonQuery();

                MySqlDataAdapter _da = new MySqlDataAdapter(_cmd);
                _da.Fill(_dataTable);

                MySqlCommandBuilder _cb = new MySqlCommandBuilder(_da);

                dgv.DataSource = _dataTable;
                dgv.DataMember = _dataTable.TableName;
                dgv.AutoResizeColumns();

                _conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable MySQLData(string query)
        {
            DataTable temp = new DataTable();

            try
            {
                MySqlConnection MySQLconn = new MySqlConnection(sql);
                MySqlCommand cmd = MySQLconn.CreateCommand();
                //cmd.CommandText = "SELECT idProyecto FROM tb_seguimiento";
                MySQLconn.Open();
                //cmd.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(query,MySQLconn);
                adapter.Fill(temp);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception found: " + ex.Message,"MySQLException",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            return temp;
        }

        public void MySQLstatement(String proyecto,string concepto) //SQL insert, update or delete
        {
            if(concepto.Equals("correcto"))
            {
                string sentencia = ConfigurationManager.AppSettings["updProjects"].ToString() + proyecto + "%'; ";
                try
                {
                    MySqlConnection MySQLconn = new MySqlConnection(sql);
                    MySqlCommand cmd = MySQLconn.CreateCommand();

                    MySQLconn.Open();

                    MySqlCommand comando = new MySqlCommand(sentencia, MySQLconn);
                    comando.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Exception found " + error.Message, "Utilities SQLException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (concepto.Equals("error"))
            {
                string sentencia = ConfigurationManager.AppSettings["updErrorProjects"].ToString() + proyecto + "%'; ";
                try
                {
                    MySqlConnection MySQLconn = new MySqlConnection(sql);
                    MySqlCommand cmd = MySQLconn.CreateCommand();

                    MySQLconn.Open();

                    MySqlCommand comando = new MySqlCommand(sentencia, MySQLconn);
                    comando.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Exception found " + error.Message, "Utilities SQLException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
