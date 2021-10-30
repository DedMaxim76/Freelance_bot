using System;
using System.Collections.Generic;

#nullable disable

namespace Freelance_bot
{
    public partial class Transaction
    {
        public Transaction()
        {
            Transactionlists = new HashSet<Transactionlist>();
        }

        public int Id { get; set; }
        public int TransactionId { get; set; }
        public char TypeOfTransaction { get; set; }
        public char Status { get; set; }
        public long? OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<Transactionlist> Transactionlists { get; set; }
    }
}
