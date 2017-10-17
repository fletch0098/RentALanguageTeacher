using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace RentALanguageTeacher
{
    public partial class captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblResult.Text = "You Got It!";
                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Visible = true;
            }
            else
            {
                lblResult.Text = "Incorrect";
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Visible = true;
            }
        }
    }
}