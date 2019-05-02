using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.Resolver
{
    public interface IPaymentsResolver
    {
        Task<bool> ResovlePayment(Payment payment, User user);

    }
}
