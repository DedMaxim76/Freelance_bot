using System;
using System.Collections.Generic;

#nullable disable

namespace Freelance_bot
{
    public partial class ErrorTransaction
    {
        public int Id { get; set; }
        public int ErrorCode { get; set; }
        public string DescriptionError { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
