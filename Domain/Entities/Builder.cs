using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Builder: Base
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Cnpj { get; set; }
        public string Segment { get; set; }
        public DateTime FoundationDate { get; set; }

    }
}
