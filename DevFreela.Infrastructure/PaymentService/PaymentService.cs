using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _paymentBaseUrl;
        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _paymentBaseUrl = configuration.GetSection("Services:Payments").Value;
        }
        public async Task<bool> ProcessPayment(PaymentInfoDto paymentInfoDto)
        {
            var url = $"{_paymentBaseUrl}/api/payments";

            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);

            var paymentInfoContent = new StringContent(paymentInfoJson,
                                                        Encoding.UTF8,
                                                        "application/json");

            var httpClientPayment = _httpClientFactory.CreateClient("Payments");

            var response = await httpClientPayment.PostAsync(url, paymentInfoContent);

            return response.IsSuccessStatusCode;
        }
    }
}
