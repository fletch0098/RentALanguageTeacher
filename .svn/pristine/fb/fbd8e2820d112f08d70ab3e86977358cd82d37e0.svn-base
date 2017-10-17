using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentALanguageTeacher.App_Code;
using System.Data;

namespace RentALanguageTeacher.Pages.Administrator
{
    public partial class ViewStudents : System.Web.UI.Page
    {
        string Sort_Direction = "UserName ASC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;
                BindStudents();
            }
            
        }

        protected void BindStudents()
        {
           

            List<Student> students = new List<Student>();

            if (GridStudents.DataSource == null)
            {
                students = App_Code.StudentService.GetStudents();
            }
            else
            {
                students = (List<Student>)GridStudents.DataSource;
            }

            

            string[] SortExp = ViewState["SortExpr"].ToString().Split(' ');

            if (SortExp[0] == "Name")
            {

                if (SortExp[1] == "ASC")
                {
                    App_Code.Student.SortOnNameASC SON = new Student.SortOnNameASC();
                    students.Sort(SON);
                }
                else
                {
                    App_Code.Student.SortOnNameDSC SON = new Student.SortOnNameDSC();
                    students.Sort(SON);
                }
                
            }
            else if (SortExp[0] == "UserName")
            {

                if (SortExp[1] == "ASC")
                {
                    //App_Code.Student.SortOnNameASC SON = new Student.SortOnNameASC();
                    students.Sort();
                }
                else
                {
                    App_Code.Student.SortOnUserNameDSC SON = new Student.SortOnUserNameDSC();
                    students.Sort(SON);
                }

            }
            else if (SortExp[0] == "Email")
            {

                if (SortExp[1] == "ASC")
                {
                    App_Code.Student.SortOnEmail SON = new Student.SortOnEmail();
                    students.Sort(SON);
                }
                else
                {
                    App_Code.Student.SortOnEmailDSC SON = new Student.SortOnEmailDSC();
                    students.Sort(SON);
                }

            }
            else if (SortExp[0] == "Status")
            {

                if (SortExp[1] == "ASC")
                {
                    App_Code.Student.SortOnStatus SON = new Student.SortOnStatus();
                    students.Sort(SON);
                }
                else
                {
                    App_Code.Student.SortOnStatusDSC SON = new Student.SortOnStatusDSC();
                    students.Sort(SON);
                }

            }

            GridStudents.DataSource = students;
            GridStudents.DataBind();

        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridStudents.PageIndex = e.NewPageIndex;
            BindStudents();
        }

        protected void Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
            BindStudents();
        }
    }
}