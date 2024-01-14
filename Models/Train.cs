using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicket.Models
{
    public class Train
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FromStation { get; set; }

        public string? ToStation { get; set; }

        public DateTime? date { get; set; }
        
        public DateTime time { get; set; }

        public string? trainName { get; set; }

        public int? Cost { get; set; }
    }

}
