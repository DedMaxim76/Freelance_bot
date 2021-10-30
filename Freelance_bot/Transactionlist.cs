using System;
using System.Collections.Generic;

#nullable disable

namespace Freelance_bot
{
    public partial class Transactionlist
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int? TransactionId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
