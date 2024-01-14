using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicket.Models
{
    public class TrainSchudule
    {
        [Required(ErrorMessage = "FromStation is require")]
        public string? FromStation { get; set; }

        [Required(ErrorMessage = "ToStation is require")]
        public string? ToStation { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime? date { get; set; }

        [Required(ErrorMessage ="Time is requried")]
        public DateTime time { get; set; }

        [Required(ErrorMessage = "TrainName is required")]
        public string? trainName { get; set; }

        [Required(ErrorMessage ="Cost is requried")]
        public int? Cost { get; set; }
    }

}
