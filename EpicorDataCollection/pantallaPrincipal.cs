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
        protected int counter = 0;
        public string dataValues = ConfigurationManager.AppSettings["connectionEpicor"].ToString();
        private string server = ConfigurationManager.AppSettings["ConnectionString"].ToString().Substring(12, 12);


        public pantallaPrincipal()
        {
            InitializeComponent();
            fileStream = new fileIO();
            fileStream.createFolder();

            counter = 0;
            timer1.Interval = 600;
            timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            lblServerOrigen.Text = "INTRTISERVER";
            lblServerDestino.Text = server;
        }

        private void pantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        private void btnSQL_Click(object sender, EventArgs e)
        { }

        private void SincronizarProyectos() {
            //int indice = 0;
            mysql = new MySQL_Utilities();
            DataTable dt = new DataTable();
            string query = ConfigurationManager.AppSettings["getProyects"].ToString();
            dt = mysql.MySQLData(query);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int indice = 0;

            // Validación si no se encuentran registros
            if (dataGridView1.RowCount < 1)
            {
                using (StreamWriter sw = File.AppendText(ConfigurationManager.AppSettings["filePath"].ToString()))
                {
                    sw.WriteLine("No se detectaron modificaciones en los Proyectos del Master.");
                    sw.WriteLine("Ningún proyecto que sincronizar en Epicor");
                }
            }
            else
            {
                foreach (DataGridViewRow fila in dataGridView1.Rows) // Por cada fila en el grid del master se buscaran las coincidencias en el grid de proyectos Epicor
                {
                    string cleanDate = dataGridView1.Rows[indice].Cells[1].Value.ToString();
                    string cleanArco = dataGridView1.Rows[indice].Cells[2].Value.ToString();
                    string cleanAccesorio = dataGridView1.Rows[indice].Cells[3].Value.ToString();
                    string cleanPlastico = dataGridView1.Rows[indice].Cells[4].Value.ToString();
                    
                    getRecordsPerProject(dataGridView1.Rows[indice].Cells[0].Value.ToString(), cleanDate, cleanArco, cleanAccesorio, cleanPlastico);

                    dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.LightGreen;
                    indice++;   
                }
            }
            WriteEndOfProccess(ConfigurationManager.AppSettings["filePath"].ToString());
            Application.Exit();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
        }

        //Recorrido del datagridview
        private void getDataGridCells()
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
                MessageBox.Show("Id del Proyecto: " + fila.Cells[0].Value, "MySQL Information", MessageBoxButtons.OK);

            MessageBox.Show("Fila1 \n IdProyecto: " + dataGridView1.Rows[1].Cells[0].Value + " Fecha: " + dataGridView1.Rows[1].Cells[1].Value);
        }

        private void getRecordsPerProject(string idProyecto, string cleanDate, string cleanArco, string cleanAccesorio, string cleanPlastico)
        {
            sql = new utilities();
            DataTable dtEpicor = new DataTable();
            string consulta = ConfigurationManager.AppSettings["getEpicorProjects"].ToString();
            string project = idProyecto;
            int index = 0;


            try
            {
                // Consulto los proyectos en la UD39 con referencia al id de Proyecto
                dtEpicor = sql.SQLGetData(consulta, project);
                dgvEpicor.DataSource = dtEpicor;

                if (dgvEpicor.RowCount < 1) // Valido si el grid no contiene filas
                {
                    // Si el proyecto no existe en Epicor escribo en el log y cambio el status a 3(No encontrado)
                    writeLog(idProyecto, ConfigurationManager.AppSettings["filePath"].ToString());
                    listaNoEncontrados.Items.Add(idProyecto);
                    mysql.MySQLstatement(idProyecto, "error");
                }
                else
                {
                    // En caso de recuperar registros se revisa el grupo de parte para impactar las fechas en Epicor
                    foreach (DataGridViewRow row in dgvEpicor.Rows)
                    {
                        // Se realiza la validación para impactar una fecha de acuerdo al grupo de parte al que pertenece
                        // si el grupo de parte es vacío será contemplado como Estaca
                        if (((dgvEpicor.Rows[index].Cells[6].Value.ToString() == "Estaca") && (dgvEpicor.Rows[index].Cells[3].Value.ToString() == "1")) || ((dgvEpicor.Rows[index].Cells[6].Value.ToString() == "") && (dgvEpicor.Rows[index].Cells[3].Value.ToString() == "1")))
                        {
                            Base obj = new Base("rarroyo", "vorkelball", "TT");
                            obj.updateUD39(dgvEpicor.Rows[index].Cells[1].Value.ToString(), dgvEpicor.Rows[index].Cells[2].Value.ToString(), dgvEpicor.Rows[index].Cells[3].Value.ToString(), dgvEpicor.Rows[index].Cells[4].Value.ToString(), dgvEpicor.Rows[index].Cells[5].Value.ToString(),cleanDate);
                            dgvEpicor.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        else if (((dgvEpicor.Rows[index].Cells[6].Value.ToString() == "Arco") && (dgvEpicor.Rows[index].Cells[3].Value.ToString() == "1")))
                        {
                            Base obj = new Base("rarroyo", "vorkelball", "TT");
                            obj.updateUD39(dgvEpicor.Rows[index].Cells[1].Value.ToString(), dgvEpicor.Rows[index].Cells[2].Value.ToString(), dgvEpicor.Rows[index].Cells[3].Value.ToString(), dgvEpicor.Rows[index].Cells[4].Value.ToString(), dgvEpicor.Rows[index].Cells[5].Value.ToString(), cleanArco);
                            dgvEpicor.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        else if (((dgvEpicor.Rows[index].Cells[6].Value.ToString() == "Accesorios") && (dgvEpicor.Rows[index].Cells[3].Value.ToString() == "1")))
                        {
                            Base obj = new Base("rarroyo", "vorkelball", "TT");
                            obj.updateUD39(dgvEpicor.Rows[index].Cells[1].Value.ToString(), dgvEpicor.Rows[index].Cells[2].Value.ToString(), dgvEpicor.Rows[index].Cells[3].Value.ToString(), dgvEpicor.Rows[index].Cells[4].Value.ToString(), dgvEpicor.Rows[index].Cells[5].Value.ToString(), cleanAccesorio);
                            dgvEpicor.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        else if (((dgvEpicor.Rows[index].Cells[6].Value.ToString() == "Plastico") && (dgvEpicor.Rows[index].Cells[3].Value.ToString() == "1")   ))
                        {
                            Base obj = new Base("rarroyo", "vorkelball", "TT");
                            obj.updateUD39(dgvEpicor.Rows[index].Cells[1].Value.ToString(), dgvEpicor.Rows[index].Cells[2].Value.ToString(), dgvEpicor.Rows[index].Cells[3].Value.ToString(), dgvEpicor.Rows[index].Cells[4].Value.ToString(), dgvEpicor.Rows[index].Cells[5].Value.ToString(), cleanPlastico);
                            dgvEpicor.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        index++;
                    }
                    WriteCorrect(idProyecto, ConfigurationManager.AppSettings["filePath"].ToString());
                    mysql.MySQLstatement(idProyecto, "correcto"); //Cambio el status del proyecto a sincronizado
                }
            }
            catch (ArgumentOutOfRangeException exx)
            {
                MessageBox.Show("Se capturó la siguiente excepción \n" + exx.Message + "\n Número de filas del grid: " + dgvEpicor.RowCount, "Exception Found: ArgumentOutOfRangeException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void writeLog(string proyectoActual, string rutaArchivo)
        {
            string path = rutaArchivo;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("El proyecto " + proyectoActual + " no se encontró en Epicor (Marcado con status 3 al sincronizar).");

            }
        }

        private void WriteCorrect(string proyectoActual, string rutaArchivo)
        {
            string path = rutaArchivo;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("El proyecto " + proyectoActual + " ha sido actualizado exitosamente (Se ha marcado con 1 en la sincronización).");

            }
        }

        private void WriteEndOfProccess(string rutaArchivo)
        {
            string path = rutaArchivo;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Se ha terminado la sincronización ...");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter >= 10)
            {
                // Exit loop code.
                timer1.Enabled = false;
                counter = 0;

                SincronizarProyectos();
            }
            else
            {
                // Incremento contador
                counter = counter + 1;
            }
        }
    }
}
