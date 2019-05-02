using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.Resolver
{
    public class PaymentsResolver : IPaymentsResolver
    {
        public async Task<bool> ResovlePayment(Payment payment, User user)
        {
            bool result = true;
            string username = "mateusz.lopusinski2@gmail.com";
            string password = "123QWEasd";
            var authValue = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
            HttpClient client = new HttpClient
            {
                DefaultRequestHeaders = { Authorization = authValue }
            };
            client.BaseAddress = new Uri("https://ssl.dotpay.pl/test_seller/api/v1");
            var dotpayResult = await client.GetAsync("/payments");

            return result;
        }
    }
}
