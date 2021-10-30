using System;
using System.Collections.Generic;

#nullable disable

namespace Freelance_bot
{
    public partial class TransactionsView
    {
        public long? UserId { get; set; }
        public string UserName { get; set; }
        public decimal? Balance { get; set; }
        public int? TransactionId { get; set; }
        public char? Status { get; set; }
        public decimal? Amount { get; set; }
    }
}
