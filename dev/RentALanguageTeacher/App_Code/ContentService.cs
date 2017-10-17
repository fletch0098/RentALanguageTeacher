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
    public class ContentService
    {

        //Use reflection and set up log4net log
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static content GetObjectByUserId(int UserId)
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
                    var MyObject = (from s in ctx.contents
                                    where s.author_user_id == UserId
                                    select s).FirstOrDefault<content>();

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

        public static int SaveObject(content MyObject)
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

                    if (MyObject.content_id == 0)
                    {
                        if ((from s in ctx.contents where s.category == MyObject.category && s.title == MyObject.title select s).Count() == 0)
                        {
                            //Add new object
                            ctx.contents.Add(MyObject);
                            log.Debug(MethodName + "() - New object added");

                            //save context changes
                            ctx.SaveChanges();
                        }

                        else
                        {
                            throw new Exception("Content with this Category and Title Already Exsists");
                        }
                    }

                    else
                    {
                        //Update object
                        ctx.Entry(MyObject).State = System.Data.EntityState.Detached;
                        ctx.Entry(MyObject).State = System.Data.EntityState.Modified;
                       // log.Debug(MethodName + "() - The object for ID " + MyObject.quick_registration_id + " was updated");
                    }

                    //save context changes
                    ctx.SaveChanges();

                    //return?
                    return MyObject.content_id;

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

        public static int DeleteObject(content MyObject)
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

                   foreach (contentmarkup x in MyObject.contentmarkups.ToList<contentmarkup>())
                   {

                       ctx.contentmarkups.Remove(x);
                       ctx.SaveChanges();
                   
                   }

                    ctx.Entry(MyObject).State = System.Data.EntityState.Deleted;

                    //Delete user
                    ctx.contents.Remove(MyObject);

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

        public static content GetObjectByTitle(string Title)
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

                    ctx.Configuration.LazyLoadingEnabled = true;

                    // get user
                    var MyObject = (from s in ctx.contents
                                    where s.title == Title

                                    select s).FirstOrDefault<content>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for Title " + Title + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for Title " + Title + " returned 0 results");
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

        public static content DeleteObjectByTitle(string Title)
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

                    ctx.Configuration.LazyLoadingEnabled = true;

                    // get user
                    var MyObject = (from s in ctx.contents
                                    where s.title == Title

                                    select s).Include("contentmarkups").FirstOrDefault<content>();

                    foreach (contentmarkup x in MyObject.contentmarkups.ToList<contentmarkup>())
                    {

                        ctx.contentmarkups.Remove(x);
                        //ctx.SaveChanges();

                    }

                    ctx.contents.Remove(MyObject);
                    ctx.SaveChanges();


                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for Title " + Title + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for Title " + Title + " returned 0 results");
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

        public static List<ContentCategory> GetObjects()
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
                    var MyObject = (from s in ctx.contentcategories

                                    select new ContentCategory() { Category = s.category});

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + " returned 0 results");
                    }

                    return MyObject.ToList();

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

        public static List<contentmarkup> GetMarkupByLanguage(int ContentId, string Language)
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
                    var MyObject = (from s in ctx.contentmarkups
                                    where s.content_id == ContentId && s.language == Language
                                    select s).ToList<contentmarkup>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + " returned 0 results");
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

        public static List<contentmarkup> GetPublishedMarkupByLanguage(int ContentId, string Language)
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
                    var MyObject = (from s in ctx.contentmarkups
                                    where s.content_id == ContentId && s.language == Language && s.published == true
                                    select s).ToList<contentmarkup>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + " returned 0 results");
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

        public static int SaveContent(contentmarkup MyObject)
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

                    if (MyObject.contentmarkup_id == 0)
                    {
                        //Add new object
                        ctx.contentmarkups.Add(MyObject);
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
                    ctx.SaveChanges();

                    //return?
                    return MyObject.contentmarkup_id;

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

        public static contentmarkup GetCurrentContentVersion(int ContentId, string Language)
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

                    ctx.Configuration.LazyLoadingEnabled = true;

                    // get user
                    var MyObject = (from s in ctx.contentmarkups
                                    where s.content_id == ContentId && s.language == Language
                                    orderby s.content_id
                                    select s).FirstOrDefault<contentmarkup>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                       // log.Debug(MethodName + "() - The item for Title " + Title + " was returned");
                    }

                    else
                    {
                        //log.Debug(MethodName + "() - The item for Title " + Title + " returned 0 results");
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

        public static contentmarkup GetContentVersionById(int VersionId)
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

                    ctx.Configuration.LazyLoadingEnabled = true;

                    // get user
                    var MyObject = (from s in ctx.contentmarkups
                                    where s.contentmarkup_id == VersionId
                                    select s).FirstOrDefault<contentmarkup>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        // log.Debug(MethodName + "() - The item for Title " + Title + " was returned");
                    }

                    else
                    {
                        //log.Debug(MethodName + "() - The item for Title " + Title + " returned 0 results");
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

        public static List<ContentVersionDDL> ListContentVersions(int ContentId)
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

                    ctx.Configuration.LazyLoadingEnabled = true;

                    // get user
                    var MyObject = (from s in ctx.contentmarkups
                                    where s.content_id == ContentId
                                    orderby s.content_id
                                    select new ContentVersionDDL() { DisplayName = s.language + " - " + Convert.ToString(s.content_id) + " - " + s.time_stamp.ToString(), VersionNumber=s.contentmarkup_id });

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        // log.Debug(MethodName + "() - The item for Title " + Title + " was returned");
                    }

                    else
                    {
                        //log.Debug(MethodName + "() - The item for Title " + Title + " returned 0 results");
                    }

                    return MyObject.ToList();

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

        public static List<contentlanguage> GetContentLanguageList()
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
                    var MyObject = (from s in ctx.contentlanguages
                                    select s).ToList<contentlanguage>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        //log.Debug(MethodName + "() - The item for ID " + UserId + " was returned");
                    }

                    else
                    {
                        // log.Debug(MethodName + "() - The item for ID " + UserId + " returned 0 results");
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

        public static void SaveObject(contentlanguage MyObject)
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

                    if ((from s in ctx.contentlanguages where s.language == MyObject.language select s).Count() == 0)
                    {
                        //Add new object
                        ctx.contentlanguages.Add(MyObject);
                        log.Debug(MethodName + "() - New object added");

                        //save context changes
                        ctx.SaveChanges();
                    }

                    else
                    {
                        throw new Exception("Language Already Exsists");
                    }

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

        public static void SaveCategory(contentcategory MyObject)
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

                    if ((from s in ctx.contentcategories where s.category == MyObject.category select s).Count() == 0)
                    {
                        //Add new object
                        ctx.contentcategories.Add(MyObject);
                        log.Debug(MethodName + "() - New object added");

                        //save context changes
                        ctx.SaveChanges();
                    }

                    else
                    {
                        throw new Exception("Category Already Exsists");
                    }



                    

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

        public static List<ContentView> ListContent()
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

                    ctx.Configuration.LazyLoadingEnabled = true;

                    var query = (from s in ctx.contents
                                 select new {
                                     Content = s,
                                     initialMarkup = s.contentmarkups
                                     .OrderBy(t => t.time_stamp)
                                     .FirstOrDefault(),
                                     LastUpdate = s.contentmarkups
                                     .OrderByDescending(u => u.time_stamp)
                                     
                                     .FirstOrDefault()
                                 });

                       


                    // get user
                    var MyObject = (from s in query
                                    orderby s.Content.category
                                    select new App_Code.ContentView() { Category=s.Content.category,
                                                                        Title = s.Content.title,
                                                                        InitialLanguage = s.initialMarkup.language,
                                                                        ModDate=s.Content.createdate, Author=s.Content.user.my_aspnet_users.name
                                    });

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        // log.Debug(MethodName + "() - The item for Title " + Title + " was returned");
                    }

                    else
                    {
                        //log.Debug(MethodName + "() - The item for Title " + Title + " returned 0 results");
                    }

                    return MyObject.ToList();

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

        public static List<contentmarkup> GetLinks(string Language, string MyCategory)
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

                    ctx.Configuration.LazyLoadingEnabled = true;

                    var me = (from m in ctx.contentmarkups
                              where m.language == Language && m.published == true
                              orderby m.time_stamp descending
                              select m).Include("Content").Include("Content.User");

                    var me2 = (from x in me
                                   where x.content.category == MyCategory
                               select x).ToList<contentmarkup>();
                              

                    return me2;

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

        public static contentcategory GetCategory(string Category)
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

                    ctx.Configuration.LazyLoadingEnabled = true;

                    // get user
                    var MyObject = (from s in ctx.contentcategories
                                    where s.category == Category

                                    select s).FirstOrDefault<contentcategory>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                      //  log.Debug(MethodName + "() - The item for Title " + Title + " was returned");
                    }

                    else
                    {
                     //   log.Debug(MethodName + "() - The item for Title " + Title + " returned 0 results");
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

        public static content GetRandomContent(int Rand, string Language)
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

                    contentmarkup MyContentMarkup = null;
                    content MyObject;

                    do
                    {
                    // get user
                     MyObject = (from s in ctx.contents
                                    where s.content_id == Rand && s.category != "RALT"
                                    select s).SingleOrDefault<content>();

                    MyContentMarkup = (from c in ctx.contentmarkups
                                           where c.content_id == MyObject.content_id && c.language == Language && c.published == true

                                           select c).OrderByDescending(x => x.time_stamp).FirstOrDefault<contentmarkup>();

                    } while (object.ReferenceEquals(MyContentMarkup, null));

                   //List<contentmarkup> MyList = new List<contentmarkup>();

                   //MyList.Add(MyContentMarkup);

                   MyObject.contentmarkups.Add(MyContentMarkup);


                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + " returned 0 results");
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

        public static int GetContentCount()
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
                    var MyObject = ctx.contents.Count();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + " returned 0 results");
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

        public static List<int> GetContentIDList(string Language)
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
                    List<int> MyObject = (from c in ctx.contentmarkups
                                          where c.content.category != "RALT" && c.language == Language && c.published == true
                                        select (int)c.content_id).ToList<int>();

                    //log 
                    if (!object.ReferenceEquals(MyObject, null))
                    {
                        log.Debug(MethodName + "() - The item for ID " + " was returned");
                    }

                    else
                    {
                        log.Debug(MethodName + "() - The item for ID " + " returned 0 results");
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

    public class ContentCategory
    {
        public String Category { get; set; }
    }

    public class ContentVersionDDL
    {
        public String DisplayName  { get; set; }
        public int VersionNumber { get; set; }
    }

    public class ContentView
    {
        public String Category { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String InitialLanguage { get; set; }
        public DateTime ModDate { get; set; }
        public int Versions { get; set; }
        public int Languages { get; set; }

        public int CompareTo(ContentView b)
        {
            // Alphabetic sort name[A to Z]
            if (this.Title == null && b == null)
                return 0;
            else if (this.Title == null)
                return -1;
            else if (b == null)
                return 1;
            else
                return this.Title.CompareTo(b.Title);
        }

        public class SortOnTitleASC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return (a.Title.CompareTo(b.Title));
            }
        }

        public class SortOnTitleDSC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return -(a.Title.CompareTo(b.Title));
            }
        }

        public class SortOnCategoryASC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a.Category == null || b.Category == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return a.Category.CompareTo(b.Category);
            }
        }

        public class SortOnCategoryDSC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return -(a.Category.CompareTo(b.Category));
            }
        }

        public class SortOnAuthorASC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return a.Author.CompareTo(b.Author);
            }
        }

        public class SortOnAuthorDSC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return -(a.Author.CompareTo(b.Author));
            }
        }

        public class SortOnLanguagesASC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return a.Languages.CompareTo(b.Languages);
            }
        }

        public class SortOnLanguagesDSC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return -(a.Languages.CompareTo(b.Languages));
            }
        }

        public class SortOnVersionASC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return a.Versions.CompareTo(b.Versions);
            }
        }

        public class SortOnVersionsDSC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return -(a.Versions.CompareTo(b.Versions));
            }
        }

        public class SortOnDateASC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return a.ModDate.CompareTo(b.ModDate);
            }
        }

        //public class SortOnDateASC : IComparer<DateTime?>
        //{
        //    #region IComparer<DateTime?> Members

        //    public int Compare(DateTime? x, DateTime? y)
        //    {
        //        DateTime nx = x ?? DateTime.MaxValue;
        //        DateTime ny = y ?? DateTime.MaxValue;

        //        return nx.CompareTo(ny);
        //    }

        //    #endregion
        //}

        //public class SortOnDateDSC : IComparer<DateTime?>
        //{
        //    #region IComparer<DateTime?> Members

        //    public int Compare(DateTime? x, DateTime? y)
        //    {
        //        DateTime nx = x ?? DateTime.MaxValue;
        //        DateTime ny = y ?? DateTime.MaxValue;

        //        return -(nx.CompareTo(ny));
        //    }

        //    #endregion
        //}

        public class SortOnDateDSC : IComparer<ContentView>
        {
            public int Compare(ContentView a, ContentView b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                    return -(a.ModDate.CompareTo(b.ModDate));
            }
        }

    }

    public class ContentLink
    {
        public String Category { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String Language { get; set; }
        public DateTime PubDate { get; set; }
        public String ImageURL { get; set; }
        public String Description { get; set; }
        public int ID { get; set; }
    }

}