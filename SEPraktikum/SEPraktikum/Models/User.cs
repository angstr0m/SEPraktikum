using System;
namespace Models {
    public abstract class User : Interfaces.Subject
    {
		private String name;
		private String eMail;
		private String surname;
		private String sessionID;
		private String password;
		private String id;

		public String GetPassword() {
			throw new System.Exception("Not implemented");
		}
		public void SetPassword(String password) {
			throw new System.Exception("Not implemented");
		}
		public String GetSurname() {
			throw new System.Exception("Not implemented");
		}
		public void SetSurname(String vorname) {
			throw new System.Exception("Not implemented");
		}
		public String GetEMail() {
			throw new System.Exception("Not implemented");
		}
		public void SetEMail(String eMail) {
			throw new System.Exception("Not implemented");
		}
		public String GetName() {
			throw new System.Exception("Not implemented");
		}
		public void SetName(String name) {
			throw new System.Exception("Not implemented");
		}
		public String GetSessionID() {
			throw new System.Exception("Not implemented");
		}
		public void SetSessionID(String sessionID) {
			throw new System.Exception("Not implemented");
		}

	}

}
