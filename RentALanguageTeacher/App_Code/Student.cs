using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentALanguageTeacher.App_Code
{
    public class Student:IComparable<Student>
    {
        public String UserName { get; set; }
        public String Name { get; set; }
        public String TimeZone { get; set; }
        public String Status { get; set; }
        public String Email { get; set; }

        public int CompareTo(Student b)
        {
            // Alphabetic sort name[A to Z]
            if (this.UserName == null && b == null)
                return 0;
            else if (this.UserName == null)
                return -1;
            else if (b == null)
                return 1;
            else
            return this.UserName.CompareTo(b.UserName);
        }

        public class SortOnNameASC : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                return a.Name.CompareTo(b.Name);
            }
        }
        public class SortOnNameDSC : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                return -(a.Name.CompareTo(b.Name));
            }
        }
        public class SortOnTimeZone : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                return a.TimeZone.CompareTo(b.TimeZone);
            }
        }
        public class SortOnTimeZoneDSC : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                return -(a.TimeZone.CompareTo(b.TimeZone));
            }
        }
        public class SortOnEmail : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                return a.Email.CompareTo(b.Email);
            }
        }
        public class SortOnEmailDSC : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                return -(a.Email.CompareTo(b.Email));
            }
        }
        public class SortOnStatus : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a.Status == null && b.Status == null)
                    return 0;
                else if (a.Status == null)
                    return -1;
                else if (b.Status == null)
                    return 1;
                else
                return a.Status.CompareTo(b.Status);
            }
        }
        public class SortOnStatusDSC : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a.Status == null && b.Status == null)
                    return 0;
                else if (a.Status == null)
                    return -1;
                else if (b.Status == null)
                    return 1;
                else
                return -(a.Status.CompareTo(b.Status));
            }
        }
        public class SortOnUserNameDSC : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                else
                return -(a.UserName.CompareTo(b.UserName));
            }
        }
    }
}