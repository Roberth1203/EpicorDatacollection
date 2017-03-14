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

        public void setCompany(string currentCompany)
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
    }
}
