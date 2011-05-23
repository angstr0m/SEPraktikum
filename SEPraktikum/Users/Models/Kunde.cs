using System;
using System.Collections.Generic;
using Finances.Models;
using Users.Interfaces;

namespace Users.Models {
	public class Kunde : Benutzer, IKunde
	{
	    private int id;
		private int customerID;
	    private string name;
		private List<Adress> adress;
		private DateTime birthDateTime;
		private String phone;
		private float discount;
		private Account account;

        public Kunde(int customerID ,string name, List<Adress> adress, DateTime birthDateTime, string phone, float discount, Account account)
        {
            this.name = name;
            this.customerID = customerID;
	        this.adress = adress;
	        this.birthDateTime = birthDateTime;
	        this.phone = phone;
	        this.discount = discount;
	        this.account = account;
	    }

	    public Account Account
	    {
	        get { return account; }
	    }

	    public float Discount
	    {
	        get { return discount; }
	    }

	    public string Phone
	    {
	        get { return phone; }
	    }

	    public DateTime BirthDateTime
	    {
	        get { return birthDateTime; }
	    }

	    public List<Adress> Adress
	    {
	        get { return adress; }
	    }

	    public string Name
	    {
	        get { return name; }
	    }

	    public int CustomerId
	    {
	        get { return customerID; }
	    }

	    public int Id
	    {
	        get { return id; }
	    }

		public void AddAdress(Adress newAdress) {
			throw new System.Exception("Not implemented");
		}
		public void RemoveAdress(Adress adress) {
			throw new System.Exception("Not implemented");
		}

        public void SetIdentifier(int id)
        {
            this.id = id;
        }

        public int GetIdentifier()
        {
            return id;
        }
    }

}
