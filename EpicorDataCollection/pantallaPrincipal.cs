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
        public string dataValues = "Data Source=192.168.1.18;Initial Catalog=ERP10DB;User Id=sa;Password=Epicor123;";

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
            
            //obj.updateUD39();
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            int indice =0;
            mysql = new MySQL_Utilities();
            DataTable dt = new DataTable();
            string query = ConfigurationManager.AppSettings["getProyects"].ToString();
            dt = mysql.MySQLData(query);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //foreach (DataGridViewRow fila in dataGridView1.Rows)
            //{
                getRecordsPerProject(dataGridView1.Rows[1].Cells[0].Value.ToString(), dataGridView1.Rows[1].Cells[1].Value.ToString(), dataGridView1.Rows[1].Cells[2].Value.ToString(), dataGridView1.Rows[1].Cells[3].Value.ToString(), dataGridView1.Rows[1].Cells[4].Value.ToString());

                //dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.LightGreen;
                //indice++;
            //}
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Base obj = new Base("rarroyo", "vorkelball", "TT");
            //obj.insertUD01("T44516Z");
            obj.InsertUD39();
            MessageBox.Show("Tarea Completada");
            
        }

        //Recorrido del datagridview
        private void getDataGridCells()
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
                MessageBox.Show("Id del Proyecto: " + fila.Cells[0].Value,"MySQL Information",MessageBoxButtons.OK);

            MessageBox.Show("Fila1 \n IdProyecto: " + dataGridView1.Rows[1].Cells[0].Value + " Fecha: " + dataGridView1.Rows[1].Cells[1].Value);
        }

        private void getRecordsPerProject(string idProyecto, string fechaInicio, string fechaPreparacion, string fechaSurcado, string fechaEncamado)
        {
            sql = new utilities();
            DataTable dtEpicor = new DataTable();
            string consulta = ConfigurationManager.AppSettings["getEpicorProjects"].ToString();
            string project = idProyecto;
            int index = 0;

            dtEpicor = sql.SQLGetData(consulta, project);
            dgvEpicor.DataSource = dtEpicor;
            
            Base obj = new Base("rarroyo", "vorkelball", "TT");
            obj.updateUD39(dgvEpicor.Rows[0].Cells[1].Value.ToString(), dgvEpicor.Rows[0].Cells[2].Value.ToString(), dgvEpicor.Rows[0].Cells[3].Value.ToString(), dgvEpicor.Rows[0].Cells[4].Value.ToString(), dgvEpicor.Rows[0].Cells[5].Value.ToString(),fechaInicio,fechaPreparacion,fechaSurcado,fechaEncamado);
            
            MessageBox.Show("Datos Modificados");
        }
    }
}
