using System.Collections.Generic;
using Base.AbstractClasses;

namespace Finances.Models {
	public class Zahlungsinformationen : Subject {
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
