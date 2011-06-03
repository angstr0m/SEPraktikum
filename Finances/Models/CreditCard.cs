using System;

namespace Finances.Models
{
    public class CreditCard : PaymentInfo
    {
        private String cardNr;
        private DateTime expirationDateTime;
        private String securityCode;
    }
}