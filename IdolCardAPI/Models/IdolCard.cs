using System;

namespace IdolCardAPI.Models
{
    public class IdolCard
    {
        public int IdolId { get; set; }
        public string IdolName { get; set; }
        public string IdolGroup { get; set; }
        public string PhotoCardSet { get; set; }
        public DateTime DateAdded { get; set; }
        public string PhotoFileName { get; set; }
    }
}
