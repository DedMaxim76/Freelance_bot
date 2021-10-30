using System;
using System.Collections.Generic;

#nullable disable

namespace Freelance_bot
{
    public partial class Chat
    {
        public Chat()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public long ChatId { get; set; }
        public int Status { get; set; }
        public string MediaMessageUrl { get; set; }
        public long? TakenOrderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
