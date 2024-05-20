using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RestaurantSystem.Models.Data
{
    public class Account : IdentityUser
    {
        public string Address { get; set; }
        public ICollection<Orders> OrderHistory { get; set; }
    }
}
