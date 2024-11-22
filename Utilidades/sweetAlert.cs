using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Cliente_WS.Utilidades
{
    public class sweetAlert
    {
        public static void Sweet_Alert(string title, string msg, string type, Page pg, Object ob)
        {

            string sa = "<script languaje='javascript'>" +
                "Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + msg + "', " +
                "icon:'" + type + "'});" +
                "</script>";
            Type cstype = ob.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, sa, sa);
        }
        public static void Sweet_Alert(string title, string msg, string type, Page pg, Object ob, string dir)
        {

            string sa = "<script languaje='javascript'>" +
                "Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + msg + "', " +
                "icon:'" + type + "'}).then((result)=>{" +
                "if(result.isConfirmed){" +
                "window.location.href='" + dir + "'" +
                "}" +
                "});" +
                "</script>";
            Type cstype = ob.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, sa, sa);
        }
    }
}