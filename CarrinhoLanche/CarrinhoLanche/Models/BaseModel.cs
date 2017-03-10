using System;

namespace CarrinhoLanche.Models
{
    public class BaseModel
    {
        public string Id { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public bool Deleted { get; set; }

        public byte[] Version { get; set; }
    }
}
