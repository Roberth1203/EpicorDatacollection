using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpicorConnection;
using Ice.Core;
using Erp.Common;
using Ice.Lib;
using System.Configuration;

namespace EpicorDataCollection
{
    public partial class Login : Form
    {
        public string uName, uPass, rutaConfig;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogOn_Click(object sender, EventArgs e)
        {
            uName = inputUser.Text;
            uPass = inputPass.Text;
            rutaConfig = @"C:\Epicor\ERP10.0ClientTest\Client\config\Epicor10.sysconfig";
            
            if (!isEmpty())
            {
                try
                {
                    Session epiSession = new Session(uName, uPass, Session.LicenseType.DataCollection,rutaConfig); //Consumo una licencia de tipo DataCollection

                    if (epiSession != null)
                    {
                        Base pattern = new Base(uName, uPass, "TT"); //Hago el cambio de compañia según sea necesario
                        pantallaPrincipal screen = new pantallaPrincipal();
                        this.Hide();
                        screen.Show();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool isEmpty()
        {
            bool vacio = false;
            if(inputUser.Text == "" || inputUser.Text == string.Empty || inputPass.Text == "" || inputPass.Text == string.Empty)
            {
                MessageBox.Show("El usuario o contraseña no pueden estar vacíos","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                vacio = true;
            }
            return vacio;
        }
    }
}
