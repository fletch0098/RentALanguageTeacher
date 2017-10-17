using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace RentALanguageTeacher.App_Code
{

    public class RALTProfile
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Language { get; set; }
        public int SpanishLevel { get; set; }
        public Boolean CopyFlag { get; set; }
        public String UserName { get; set; }
        public Boolean IsAnonymous { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime LastVisitedDate { get; set; }
        public String ProfileType { get; set; }

        public RALTProfile GetRALTProfile()
        {
            try
            {
                //Get the profile data from HTTPContext
                dynamic profile = GetProfileCommon();

                //RALT strongly typed profile
                RALTProfile MyRALTProfile = new RALTProfile();

                //Fill typed data
                MyRALTProfile.CopyFlag = profile.CopyFlag;
                MyRALTProfile.Email = profile.Email;
                MyRALTProfile.FirstName = profile.FirstName;
                MyRALTProfile.IsAnonymous = profile.IsAnonymous;
                MyRALTProfile.Language = profile.Language;
                MyRALTProfile.LastName = profile.LastName;
                MyRALTProfile.LastUpdatedDate = profile.LastUpdatedDate;
                MyRALTProfile.SpanishLevel = profile.SpanishLevel;
                MyRALTProfile.UserName = profile.UserName;
                MyRALTProfile.LastVisitedDate = profile.LastVisitDate;
                MyRALTProfile.ProfileType = profile.ProfileType;

                //return strongly typed profile
                return MyRALTProfile;

            }

            catch (Exception ex)
            {
                //Return Null error
                return null;
            }

        }

        public RALTProfile GetRALTProfile(string UserName)
        {
            try
            {
                //Get the profile data from HTTPContext
                dynamic profile = GetProfileCommon(UserName);

                //RALT strongly typed profile
                RALTProfile MyRALTProfile = new RALTProfile();

                //Fill typed data
                MyRALTProfile.CopyFlag = profile.CopyFlag;
                MyRALTProfile.Email = profile.Email;
                MyRALTProfile.FirstName = profile.FirstName;
                MyRALTProfile.IsAnonymous = profile.IsAnonymous;
                MyRALTProfile.Language = profile.Language;
                MyRALTProfile.LastName = profile.LastName;
                MyRALTProfile.LastUpdatedDate = profile.LastUpdatedDate;
                MyRALTProfile.SpanishLevel = profile.SpanishLevel;
                MyRALTProfile.UserName = profile.UserName;
                MyRALTProfile.LastVisitedDate = profile.LastVisitDate;
                MyRALTProfile.ProfileType = profile.ProfileType;

                //return strongly typed profile
                return MyRALTProfile;

            }

            catch (Exception ex)
            {
                //Return Null error
                return null;
            }

        }

        public void SaveRALTProfile(RALTProfile MyRALTProfile)
        {
            //Save the strongly type RALTProfile in the profileCommon
            try
            {

                //get the profileCommon
                dynamic profile = GetProfileCommon(MyRALTProfile.UserName);

                //Transfer Data to profileCommon
                profile.ProfileType = MyRALTProfile.ProfileType;
                profile.Email = MyRALTProfile.Email;
                profile.FirstName = MyRALTProfile.FirstName;
                profile.CopyFlag = MyRALTProfile.CopyFlag;
                profile.Language = MyRALTProfile.Language;
                profile.LastName = MyRALTProfile.LastName;
                profile.LastVisitDate = MyRALTProfile.LastVisitedDate;
                profile.SpanishLevel = MyRALTProfile.SpanishLevel;

                //Save
                profile.Save();

            }

            catch (Exception ex)
            {
                //Throw exception
                throw ex;
            }

        }

        public dynamic GetProfileCommon()
        {

            //Get the Profile Cooomin data from HTTP Context
            try
            {
                string UserName = HttpContext.Current.Profile.UserName;
                dynamic profile = ProfileBase.Create(UserName, false);

                return profile;
            }

            //Throw any error
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dynamic GetProfileCommon(string UserName)
        {

            //Get the Profile Cooomin data from HTTP Context
            try
            {

                dynamic profile = ProfileBase.Create(UserName, false);

                return profile;
            }

            //Throw any error
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}