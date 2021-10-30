using System;
using System.Collections.Generic;

#nullable disable

namespace Freelance_bot
{
    public partial class Order
    {
        public Order()
        {
            Transactions = new HashSet<Transaction>();
        }

        public long OrderId { get; set; }
        public long CreatorId { get; set; }
        public long? WorkerId { get; set; }
        public long? ChatId { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaMessageUrl { get; set; }
        public int? CostValue { get; set; }
        public int? BetCost { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
