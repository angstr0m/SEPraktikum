using System;
using System.Collections.Generic;
namespace Models {
	public class Account : Interfaces.Subject {
		private float balance;
		private List<PaymentInfo> paymentInfo;

		public bool ChargeAccount(float amount) {
			throw new System.Exception("Not implemented");
		}
		public bool IsBalanced() {
			throw new System.Exception("Not implemented");
		}
		public bool PayInto(float amount) {
			throw new System.Exception("Not implemented");
		}
		public float Balance() {
			throw new System.Exception("Not implemented");
		}
		public void AddPaymentInfo(PaymentInfo paymentInfo) {
			throw new System.Exception("Not implemented");
		}
		public PaymentInfo RemovePaymentInfo(PaymentInfo paymentInfo) {
			throw new System.Exception("Not implemented");
		}

	}

}
