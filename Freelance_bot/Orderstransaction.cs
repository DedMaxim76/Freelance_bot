using System;
using System.Collections.Generic;

#nullable disable

namespace Freelance_bot
{
    public partial class Orderstransaction
    {
        public long? OrderId { get; set; }
        public long? UserId { get; set; }
        public string FullName { get; set; }
        public char? TypeOfTr { get; set; }
        public char? StatusOfTr { get; set; }
    }
}
