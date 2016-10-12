using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Common
/// </summary>
/// 

namespace GlobalSwapShop
{

        public class webAppCmd
        {
            private SqlCommand _command = new SqlCommand();

            public SqlCommand Command
            {
                get { return _command; }
                set { _command = value; }
            }

            public SqlConnection Connection
            {
                get { return _command.Connection; }
                set { _command.Connection = value; }
            }

            public webAppCmd(string CommandText, CommandType type)
            {
                String connStr = ConfigurationManager.ConnectionStrings["gss_backend"].ConnectionString;

                SqlConnection cxn = new SqlConnection(connStr);
                cxn.Open();

                _command.Connection = cxn;

                _command.CommandText = CommandText;
                _command.CommandType = type;
            }

            ~webAppCmd()
            {
                if (Command.Connection.State != ConnectionState.Closed)
                {
                    Command.Connection.Close();
                    Command.Connection.Dispose();
                }
            }

        }

        public class GlobalPage : System.Web.UI.Page
        {
            protected override void InitializeCulture()
            {
                base.InitializeCulture();

                string language = Request["ctl00$LanguageSelector"];

                if (language != null)
                {
                    UICulture = language;
                    Culture = language;
                }
            }

        }

        public static class Utilities
        {
            public static System.Object
            FindControl(System.Web.UI.ControlCollection collection, String controlID)
            {
                System.Object returnValue = null;

                foreach (System.Web.UI.Control ctl in collection)
                {
                    if (ctl.ID == controlID)
                    {
                        returnValue = ctl;
                        break;
                    }
                    if (ctl.Controls.Count > 0)
                        returnValue = FindControl(ctl.Controls, controlID);

                    if (returnValue != null)
                        return returnValue;
                }

                return returnValue;

            }


        }

} //namespace GlobalSwapShop

