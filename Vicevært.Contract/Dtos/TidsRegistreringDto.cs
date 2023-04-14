using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedelApp.Contract.Dtos
{
    public class TidsRegistreringDto
    {
        public int TidsRegistreringsId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int PedelId { get; set; }
        public int RekvisitionsId { get; set; }
    }
}
