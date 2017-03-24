using System;
using System.IO;
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
        fileIO fileStream;
        protected string obtUser;
        protected string obtPass;
        public string dataValues = ConfigurationManager.AppSettings["connectionEpicor"].ToString();

        public pantallaPrincipal()
        {
            InitializeComponent();
            fileStream = new fileIO();
            fileStream.createFolder();
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
            //int indice = 0;
            mysql = new MySQL_Utilities();
            DataTable dt = new DataTable();
            string query = ConfigurationManager.AppSettings["getProyects"].ToString();
            dt = mysql.MySQLData(query);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int indice = 0;

            // Validación si no se encuentran registros
            if(dataGridView1.RowCount < 1)
            {
                using (StreamWriter sw = File.AppendText(ConfigurationManager.AppSettings["filePath"].ToString()))
                {
                    sw.WriteLine("No se detectaron modificaciones en los Proyectos del Master.");
                    sw.WriteLine("Ningún proyecto que sincronizar en Epicor");
                }
            }
            else
            {
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    //Se ejecuta el proceso para actualizar la fecha de entrega
                    getRecordsPerProject(dataGridView1.Rows[indice].Cells[0].Value.ToString(), dataGridView1.Rows[indice].Cells[1].Value.ToString());

                    dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.LightGreen;
                    indice++;
                }

                writeLogFooter(ConfigurationManager.AppSettings["filePath"].ToString());
            }

            Application.Exit();
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

        private void getRecordsPerProject(string idProyecto, string fechaEstacas)
        {
            sql = new utilities();
            DataTable dtEpicor = new DataTable();
            string consulta = ConfigurationManager.AppSettings["getEpicorProjects"].ToString();
            string project = idProyecto;
            int index = 0;


            try
            {
                dtEpicor = sql.SQLGetData(consulta, project);
                dgvEpicor.DataSource = dtEpicor;
                
                if (dgvEpicor.RowCount < 1)
                {
                    MessageBox.Show("No hay ninguna coincidencia con el proyecto: " + idProyecto,"Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    writeLog(idProyecto,ConfigurationManager.AppSettings["filePath"].ToString());
                    mysql.MySQLstatement(idProyecto, "error");
                }
                else
                {
                    foreach (DataGridViewRow row in dgvEpicor.Rows)
                    {
                        if ((dgvEpicor.Rows[index].Cells[6].Value.ToString() == "Estaca") && (dgvEpicor.Rows[index].Cells[3].Value.ToString() == "1"))
                        {
                            Base obj = new Base("rarroyo", "vorkelball", "TT");
                            obj.updateUD39(dgvEpicor.Rows[index].Cells[1].Value.ToString(), dgvEpicor.Rows[index].Cells[2].Value.ToString(), dgvEpicor.Rows[index].Cells[3].Value.ToString(), dgvEpicor.Rows[index].Cells[4].Value.ToString(), dgvEpicor.Rows[index].Cells[5].Value.ToString(), fechaEstacas);
                            dgvEpicor.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        index++;
                    }
                    mysql.MySQLstatement(idProyecto,"correcto"); //Cambio el status del proyecto a sincronizado
                }
            }
            catch(ArgumentOutOfRangeException exx)
            { 
                MessageBox.Show("Se capturó la siguiente excepción \n" + exx.Message + "\n Número de filas del grid: " + dgvEpicor.RowCount, "Exception Found: ArgumentOutOfRangeException" ,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void writeLog(string proyectoActual,string rutaArchivo)
        {
            string path = rutaArchivo;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("El proyecto " + proyectoActual + " no se encontró en Epicor (Marcado con status 3 al sincronizar).");

            }
        }
        private void writeLogFooter(string ruta)
        {
            string path = ruta;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("===============================================================================================");
                sw.WriteLine("Se terminó la ejecución de la aplicación ...");
                sw.WriteLine("===============================================================================================");
            }
        }
    }
}
