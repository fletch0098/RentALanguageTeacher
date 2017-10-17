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

namespace RentALanguageTeacher.App_Code
{
    public class LocationService


    {
        //Use reflection and set up log4net log
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static  RentALanguageTeacher.location GetUserById(int UserId)
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
                    var MyObject = (from s in ctx.locations
                                  where s.user_id == UserId
                                  select s).FirstOrDefault<location>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + UserId + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + UserId + " returned 0 results");
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


        public static int SaveObject(location MyObject)
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

                    if (MyObject.location_id == 0)
                    {
                        //Add new object
                        ctx.locations.Add(MyObject);
                        log.Debug(MethodName + "() - New object added");
                    }

                    else
                    {
                        //Update object
                        ctx.Entry(MyObject).State = System.Data.EntityState.Modified;
                        log.Debug(MethodName + "() - The object for ID " + MyObject.location_id + " was updated");
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

        public static int DeleteObject(location MyObject)
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

                    ctx.Entry(MyObject).State = System.Data.EntityState.Deleted;

                    //Delete user
                    ctx.locations.Remove(MyObject);

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
    }
}