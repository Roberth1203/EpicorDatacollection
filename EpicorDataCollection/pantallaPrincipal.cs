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
            
            obj.updateUD39();
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            mysql = new MySQL_Utilities();
            DataTable dt = new DataTable();
            string query = ConfigurationManager.AppSettings["getProyects"].ToString();
            dt = mysql.MySQLData(query);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            getRowsPerProject();
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

        private void getRowsPerProject()
        {
            sql = new utilities();
            DataTable dtEpicor = new DataTable();
            string selectProjects = ConfigurationManager.AppSettings["getEpicorProjects"].ToString();
            string project;
            int index = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                dataGridView1.Rows[index].Selected = true;
                project = dataGridView1.Rows[index].Cells[0].Value.ToString();
                dtEpicor = sql.SQLGetData(selectProjects, project);
                dgvEpicor.DataSource = dtEpicor;
                MessageBox.Show("Registros Obtenidos","Tarea Correcta",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                
                index++;
            }
        }
    }
}
