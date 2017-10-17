using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Spatial;
using log4net;
using RentALanguageTeacher.App_Code;
using RentALanguageTeacher;
using System.Data;
using System.ComponentModel;

namespace RentALanguageTeacher.App_Code
{
    public class StudentService
    {
        //Use reflection and set up log4net log
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<Student> GetStudents()
        {

            //get method name
            string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            //initialize entities
            var ctx = new rentalanguageteacherEntities();
            {

                try
                {
                    log.Debug(MethodName + "**********************************************************************************************************");
                    log.Debug(MethodName + "() - Start");

                    // get user
                    var Query = (from s in ctx.users
                                     orderby s.member_id
                                         select s).Include(s => s.my_aspnet_membership).Include(s => s.my_aspnet_users).Include(s => s.locations);

                    var MyObjects = (from s in Query
                                     select new RentALanguageTeacher.App_Code.Student() { UserName = s.my_aspnet_users.name, Name = s.first_name + " " + s.last_name, Status = s.account_status, Email=s.my_aspnet_membership.Email });
                    //select new RentALanguageTeacher.App_Code.Student() { UserName = s.my_aspnet_users.name, Name = s.first_name + " " + s.last_name, Status=s.account_status, TimeZone=s.locations.OfType<location>().FirstOrDefault().zone.zone_name });
                        //.Include(s => s.my_aspnet_membership).Include(s => s.my_aspnet_users).Include(s => s.locations);

                    //log 
                    if (!object.ReferenceEquals(MyObjects, null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + "null" + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + "null" + " returned 0 results");
                    }

                    return MyObjects.ToList();

                }

                catch (NullReferenceException e)
                {
                    log.Error(MethodName + "() - " + e.Message);
                    log.Debug(MethodName + "() - " + e.StackTrace);
                    throw (e);
                }

                catch (Exception e)
                {
                    log.Error(MethodName + "() - " + e.Message);
                    log.Debug(MethodName + "() - " + e.StackTrace);
                    throw (e);
                }

                finally
                {
                    log.Debug(MethodName + "() - Finish");
                    log.Debug(MethodName + "**********************************************************************************************************");

                }
            }
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
    }
}