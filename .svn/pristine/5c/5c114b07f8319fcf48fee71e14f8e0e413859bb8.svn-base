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
    public class TimeZoneService
    {
        //Use reflection and set up log4net log
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static zone GetObjectByUserId(int ID)
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
                    var MyObject = (from s in ctx.zones
                                    where s.zone_id == ID
                                    select s).FirstOrDefault<zone>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + ID + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + ID + " returned 0 results");
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

    }
}