using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Services;
using RentALanguageTeacher.App_Code;

namespace RentALanguageTeacher.App_Code
{
    public static class NotificationService
    {
        public static void SendNotification(string MsgName, string Msg, string MsgType)
        {

            var http = System.Web.HttpContext.Current;
            if ((http != null))
            {
                var page = http.CurrentHandler as System.Web.UI.Page;
                if (page != null)
                {
                   // var scriptManager = System.Web.UI.ScriptManager.GetCurrent(page);

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(page, page.GetType(), MsgName, "StickyNotification('" + Msg + "','" + MsgType + "');", true);
                }
            }

        }

        public static void SendNotification(string MsgName, string Msg, string MsgType, string TimeOut)
        {

            var http = System.Web.HttpContext.Current;
            if ((http != null))
            {
                var page = http.CurrentHandler as System.Web.UI.Page;
                if (page != null)
                {
                 //   var scriptManager = System.Web.UI.ScriptManager.GetCurrent(page);

                   ScriptManager.RegisterClientScriptBlock(page, page.GetType(), MsgName , "Notification('" + Msg + "','" + MsgType + "','" + TimeOut + "');", true);
                }
            }

        }

                public static void SendCBNotification(string MsgName, string Msg, string MsgType, string CallBack)
        {

            var http = System.Web.HttpContext.Current;
            if ((http != null))
            {
                var page = http.CurrentHandler as System.Web.UI.Page;
                if (page != null)
                {
                 //   var scriptManager = System.Web.UI.ScriptManager.GetCurrent(page);

                   ScriptManager.RegisterClientScriptBlock(page, page.GetType(), MsgName , "Notification('" + Msg + "','" + MsgType + "','" + CallBack + "');", true);
                }
            }

        }
    

    }


}