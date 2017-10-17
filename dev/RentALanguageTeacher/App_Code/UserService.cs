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



namespace RentALanguageTeacher
{
    public static class UserService
    {
        //Use reflection and set up log4net log
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //retrieve the user by userid
        public static user GetUserById(int UserId)
        {
            //get method name
            string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            //initialize entities
            var ctx = new   rentalanguageteacherEntities();
            {

                try
                {
                    log.Debug(MethodName + "**********************************************************************************************************");
                    log.Debug(MethodName + "() - Start");

                    // get user
                    var MyUser = (from s in ctx.users
                                  where s.user_id == UserId
                                  select s).FirstOrDefault<user>();

                    //log 
                    if (!MyUser.Equals(null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + MyUser.user_id + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + MyUser.user_id + " returned 0 results");
                    }

          
                    return MyUser;

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

        public static int SaveNewUser(user MyUser)
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
                   
                    if (MyUser.user_id == 0)
                    {
                        //Add new object
                        ctx.users.Add(MyUser);
                        log.Debug(MethodName + "() - New object added");
                    }

                    else
                    {
                        
                        //Update object
                       // ctx.users.Attach(MyUser);
                       
                        //ctx.ObjectStateManager.ChangeObjectState(stud, System.Data.EntityState.Modified);

                        ctx.Entry(MyUser).State = System.Data.EntityState.Detached;
                        ctx.Entry(MyUser).State = System.Data.EntityState.Modified;
                        // log.Debug(MethodName + "() - The object for ID " + MyUser.user_id + " was updated");
                    }

                    //save context changes
                   ctx.SaveChanges();
                    
                    //return?
                    return MyUser.user_id;
         
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

        public static int DeleteUser(user MyUser)
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

                    ctx.Entry(MyUser).State = System.Data.EntityState.Deleted;

                    //Delete user
                    ctx.users.Remove(MyUser);

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

        //retrieve the user by userid
        public static user GetUserByMemberId(int MemberId)
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
                    user MyUser = new user();

                     MyUser = (from s in ctx.users
                                  where s.member_id == MemberId
                                  select s).FirstOrDefault<user>();

                    //log 
                    if (object.ReferenceEquals(MyUser,null))
                    {
                        log.Debug(MethodName + "() - The item for MemberID " + MemberId + " was returned");
                        return null;
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for MemberID " + MyUser.member_id + " returned 0 results");
                    return (user)MyUser;
                    }

                    

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

        public static void AccountStatusVerified(int UserId)
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

                    ctx.Configuration.ProxyCreationEnabled = false;

                    // get user
                    var MyUser = (from s in ctx.users
                                  where s.user_id == UserId
                                  select s).FirstOrDefault<user>();

                    MyUser.account_status = "Verified";

                    SaveNewUser(MyUser);

                    //log 
                    if (!MyUser.Equals(null))
                    {
                        log.Debug(MethodName + "() - The User with ID " + MyUser.user_id + " was verified");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + MyUser.user_id + " returned 0 results");
                    }

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

        public static void AccountStatusPaid(int UserId)
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

                    ctx.Configuration.ProxyCreationEnabled = false;

                    // get user
                    var MyUser = (from s in ctx.users
                                  where s.user_id == UserId
                                  select s).FirstOrDefault<user>();

                    if (MyUser.account_status != "First Class")
                    {

                        MyUser.account_status = "Paid";

                        SaveNewUser(MyUser);
                    
                    }

                    //log 
                    if (!MyUser.Equals(null))
                    {
                        log.Debug(MethodName + "() - The User with ID " + MyUser.user_id + " was verified");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + MyUser.user_id + " returned 0 results");
                    }

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