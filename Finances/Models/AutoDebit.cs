using System;

namespace Finances.Models
{
    public class AutoDebit : PaymentInfo
    {
        private String accountNumber;
        private String bankCode;
        private String iBan;
        private String instituteName;
    }
}