using System;
using System.Collections.Generic;

#nullable disable

namespace Freelance_bot
{
    public partial class User
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public decimal Balance { get; set; }
        public decimal Rating { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
