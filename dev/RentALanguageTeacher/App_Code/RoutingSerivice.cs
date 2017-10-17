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
using System.Web.Routing;

namespace RentALanguageTeacher.App_Code
{
    public class RoutingService
    {

        //Use reflection and set up log4net log
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<route_table> GetRoutes()
        {

            //get method name
            string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            //initialize entities
            var ctx = new rentalanguageteacherEntities();
            {
                ctx.Configuration.ProxyCreationEnabled = false;

                try
                {
                    log.Debug(MethodName + "**********************************************************************************************************");
                    log.Debug(MethodName + "() - Start");

                    // get user
                    var MyObject = (from s in ctx.route_table
                                    select s).ToList<route_table>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                       // log.Debug(MethodName + "() - The item for ID " + UserId + " was returned");
                    }

                    else
                    {
                      //  log.Debug(MethodName + "() - The item for ID " + UserId + " returned 0 results");
                    }

                    return MyObject;

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

        public static int SaveObject(route_table MyObject)
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

                    //Check object state, add or update

                    if (MyObject.route_id == 0)
                    {
                        //Add new object
                        ctx.route_table.Add(MyObject);
                        log.Debug(MethodName + "() - New object added");
                    }

                    else
                    {
                        //Update object
                        ctx.Entry(MyObject).State = System.Data.EntityState.Detached;
                        ctx.Entry(MyObject).State = System.Data.EntityState.Modified;
                        // log.Debug(MethodName + "() - The object for ID " + MyObject.quick_registration_id + " was updated");
                    }

                    //save context changes
                    int num = ctx.SaveChanges();

                    //return?
                    return num;

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

        public static void RegisterRoutes()
        {
            try
            {

                List<route_table> MyRoutes = GetRoutes();

                foreach (route_table Route in MyRoutes)
                {

                    RouteTable.Routes.MapPageRoute("" + Route.rout_name + "-Route", Route.rout_url, Route.physical_file);

                }
            }

            catch (Exception ex)
            {

                throw ex;

            }

        }

    }
}