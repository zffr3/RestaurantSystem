using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantSystem.Models.Data
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public string OrderOwnerId { get; set; }
        public Table SelectedTable { get; set; }    

        public DateTime BookingDate { get; set; }

        public bool Status {  get; set; }
    }
}
