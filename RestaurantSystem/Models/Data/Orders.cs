using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantSystem.Models.Data
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public string OrderOwnerId { get; set; }
        public ICollection<Menu> Positions { get; set; } = new List<Menu>();

        public DateTime OrderDate { get; set; } 
        public bool Status { get; set; }
    }
}
