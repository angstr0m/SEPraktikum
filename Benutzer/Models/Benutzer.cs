using System;
using Base.AbstractClasses;

namespace Users.Models
{
    public abstract class Benutzer : Subject
    {
        private String eMail;
        private String id;
        private String name;
        private String password;
        private String sessionID;
        private String surname;

        public String GetPassword()
        {
            throw new Exception("Not implemented");
        }

        public void SetPassword(String password)
        {
            throw new Exception("Not implemented");
        }

        public String GetSurname()
        {
            throw new Exception("Not implemented");
        }

        public void SetSurname(String vorname)
        {
            throw new Exception("Not implemented");
        }

        public String GetEMail()
        {
            throw new Exception("Not implemented");
        }

        public void SetEMail(String eMail)
        {
            throw new Exception("Not implemented");
        }

        public String GetName()
        {
            throw new Exception("Not implemented");
        }

        public void SetName(String name)
        {
            throw new Exception("Not implemented");
        }

        public String GetSessionID()
        {
            throw new Exception("Not implemented");
        }

        public void SetSessionID(String sessionID)
        {
            throw new Exception("Not implemented");
        }
    }
}