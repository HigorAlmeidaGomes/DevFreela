using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.DTOs
{
    public class PaymentInfoDto
    {
        public PaymentInfoDto(int id, string creditCarNumber, string cvv, string expiresAt, string fullName)
        {
            Id = id;
            CreditCarNumber = creditCarNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
        }

        public int Id { get; set; }
        public string CreditCarNumber { get; set; }

        public string Cvv { get; set; }

        public string ExpiresAt { get; set; }

        public string FullName { get; set; }
    }
}

