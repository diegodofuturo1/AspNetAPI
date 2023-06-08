using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enterprise: Base
    {
        public long IdBuilder { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public short ProfitabilityPerYear { get; set; }
        public int TermInMonths { get; set; }

        public PaymentType PaymentType { get; set; }
    }

    public enum PaymentType {
        Empty, Bullet, AmortizedInstallment
    }
}
