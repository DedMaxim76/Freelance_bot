using System;
using System.Collections.Generic;

#nullable disable

namespace Freelance_bot
{
    public partial class Card
    {
        public int Id { get; set; }
        public long? UserId { get; set; }
        public string CardNumber { get; set; }
        public int? DateCard { get; set; }
        public string PriorityCurrency { get; set; }
        public string CardCountry { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
