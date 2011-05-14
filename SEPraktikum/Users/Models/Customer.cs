using System;
using System.Collections.Generic;
using Finances.Models;

namespace Users.Models {
	public class Customer : User, ICustomer
	{
		private int customerID;
		private List<Adress> adress;
		private DateTime birthDateTime;
		private String phone;
		private float discount;
		private Account account;

		public int CustomerID() {
			throw new System.Exception("Not implemented");
		}
		public void AddAdress(Adress newAdress) {
			throw new System.Exception("Not implemented");
		}
		public void RemoveAdress(Adress adress) {
			throw new System.Exception("Not implemented");
		}
		public DateTime BirthDateTime() {
			throw new System.Exception("Not implemented");
		}
		public void BirthDateTime(DateTime birthDateTime) {
			throw new System.Exception("Not implemented");
		}
		public String Phone() {
			throw new System.Exception("Not implemented");
		}
		public void Phone(String phone) {
			throw new System.Exception("Not implemented");
		}
		public float Discount() {
			throw new System.Exception("Not implemented");
		}
		public void Discount(float discount) {
			throw new System.Exception("Not implemented");
		}
		public Account Account() {
			throw new System.Exception("Not implemented");
		}

	}

}
