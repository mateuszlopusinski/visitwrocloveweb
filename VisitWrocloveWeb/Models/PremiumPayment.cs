using System;

namespace VisitWrocloveWeb.Models
{
    public class PremiumPayment
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}