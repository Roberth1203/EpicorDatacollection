using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Epicor.ServiceModel.StandardBindings;
using Ice.BO;
using Ice.Lib;
using Ice.Proxy.BO;
using System.ServiceModel.Channels;
using Ice.Core;
using static Ice.BO.UD01DataSet;


namespace EpicorConnection
{
    public class Base
    {
        Credenciales cred;
        
        protected string fileSys;
        protected string getcompany;

        public Base(string environment, string company, string user, string pass)
        {
            getcompany = company;
            fileSys = string.Format("{0}{1}.sysconfig", "C:\\Epicor\\ERP10.0ClientTest\\Client\\config\\", environment);
            cred.userName = user;
            cred.password = pass;
        }

        public Base(string user, string pass, string company)
        {
            cred = new Credenciales();
            getcompany = company;
            fileSys = "C:\\Epicor\\ERP10.0ClientTest\\Client\\config\\Epicor10.sysconfig";
            
            cred.userName = user;
            cred.password = pass;

            setCompany(getcompany);
        }

        public Base(string user, string pass)
        {
            cred = new Credenciales();
            getcompany = ConfigurationManager.AppSettings["company"].ToString();
            fileSys = ConfigurationManager.AppSettings["archivoConfig"].ToString();
            cred.userName = user;
            cred.password = pass;
        }

        public Base(string company)
        {
            getcompany = company;
            fileSys = "C:\\Epicor\\ERP10.0ClientTest\\Client\\config\\Epicor10.sysconfig";
            cred.userName = "manager";
            cred.password = "!15LiveTI";
        }

        private void setCompany(string currentCompany)
        {
            string appServerUrl = string.Empty;

            EnvironmentInformation.ConfigurationFileName = fileSys;
            appServerUrl = AppSettingsHandler.AppServerUrl;
            CustomBinding wcfBinding = NetTcp.UsernameWindowsChannel();
            Uri CustSvcUri = new Uri(String.Format("{0}/Ice/BO/{1}.svc", appServerUrl, "UserFile"));

            using (UserFileImpl US = new UserFileImpl(wcfBinding, CustSvcUri))
            {
                US.ClientCredentials.UserName.UserName = cred.userName;
                US.ClientCredentials.UserName.Password = cred.password;

                US.SaveSettings(cred.userName, true, getcompany, true, false, true, true, true, true, true, true, true,
                                       false, false, -2, 0, 1456, 886, 2, "MAINMENU", "", "", 0, -1, 0, "", false);
                US.Close();
                US.Dispose();
            }
        }

        public void insertUD01(string partID)
        {
            DateTime fechaHoy = DateTime.Now;
            bool Res = true;
            string appServerUrl = string.Empty;

            EnvironmentInformation.ConfigurationFileName = fileSys;
            appServerUrl = AppSettingsHandler.AppServerUrl;
            CustomBinding wcfBinding = new CustomBinding();
            wcfBinding = NetTcp.UsernameWindowsChannel();
            Uri CustSvcUri = new Uri(string.Format("{0}/Ice/BO/{1}.svc", appServerUrl, "UD01"));
            using (UD01Impl OB = new UD01Impl(wcfBinding, CustSvcUri))
            {
                OB.ClientCredentials.UserName.UserName = cred.userName;
                OB.ClientCredentials.UserName.Password = cred.password;
                UD01DataSet dt = new UD01DataSet();
                OB.GetaNewUD01(dt);

                dt.Tables["UD01"].Rows[0]["Company"] = getcompany;
                dt.Tables["UD01"].Rows[0]["key1"] = partID;
                dt.Tables["UD01"].Rows[0]["key2"] = "";
                dt.Tables["UD01"].Rows[0]["key3"] = "";
                dt.Tables["UD01"].Rows[0]["key4"] = "";
                dt.Tables["UD01"].Rows[0]["key5"] = "";
                dt.Tables["UD01"].Rows[0]["character01"] = fechaHoy;

                OB.Update(dt);
            }
            
        }

        public void updateUD01(string Parte,string Dato)
        {
            bool Res = true;
            bool existe = false;
            string appServerUrl = string.Empty;

            EnvironmentInformation.ConfigurationFileName = fileSys;
            appServerUrl = AppSettingsHandler.AppServerUrl;
            CustomBinding wcfBinding = new CustomBinding();
            wcfBinding = NetTcp.UsernameWindowsChannel();
            Uri CustSvcUri = new Uri(string.Format("{0}/Ice/BO/{1}.svc", appServerUrl, "UD01"));
            using (UD01Impl OB = new UD01Impl(wcfBinding, CustSvcUri))
            {
                OB.ClientCredentials.UserName.UserName = cred.userName;
                OB.ClientCredentials.UserName.Password = cred.password;
                UD01DataSet dt = new UD01DataSet();

                try
                {
                    dt = OB.GetByID(Parte, "", "", "", "");
                }
                catch (Exception e)
                {
                    existe = false;

                }
                if (!existe)
                {
                    OB.GetaNewUD01(dt);

                    dt.Tables["UD01"].Rows[0]["Company"] = getcompany;
                    dt.Tables["UD01"].Rows[0]["key1"] = Parte;
                    dt.Tables["UD01"].Rows[0]["key2"] = "";
                    dt.Tables["UD01"].Rows[0]["key3"] = "";
                    dt.Tables["UD01"].Rows[0]["key4"] = "";
                    dt.Tables["UD01"].Rows[0]["key5"] = "";
                }

                dt.Tables["UD01"].Rows[0]["character01"] = Dato;

                OB.Update(dt);
            }
        }

        

    }
}
