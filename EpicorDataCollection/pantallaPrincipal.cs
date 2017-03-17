using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using EpicorConnection;
using Utilities;

namespace EpicorDataCollection
{
    public partial class pantallaPrincipal : Form
    {
        Login userData;
        utilities sql;
        MySQL_Utilities mysql;
        protected string obtUser;
        protected string obtPass;
        public string dataValues = "Data Source=TISERVER\\sqlexpress;Initial Catalog=RecursosTI;Integrated Security=True;User ID=sa;Password=Epicor123;";

        public pantallaPrincipal()
        {
            InitializeComponent();
        }

        private void pantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Base obj = new Base("rarroyo", "vorkelball", "TT");
            
            obj.updateUD01("T44516Z", "JAGUIRRE");
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string query = ConfigurationManager.AppSettings["getProyects"].ToString();
            mysql = new MySQL_Utilities();
            dt = mysql.MySQLData(query);
            dataGridView1.DataSource = dt;

            getDataGridCells();
            //sql = new utilities();
            //DataTable dt = sql.SQLdata("SELECT TOP 10 * FROM Ice.UD01",null,dataValues);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Base obj = new Base("rarroyo", "vorkelball", "TT");
            obj.insertUD01("T44516Z");
            MessageBox.Show("Tarea Completada");
            Application.Exit();
        }






        //Recorrido del datagridview
        private void getDataGridCells()
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
                MessageBox.Show("Id del Proyecto: " + fila.Cells[0].Value.ToString(),"MySQL Information",MessageBoxButtons.OK);
        }
    }
}
