using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Pradip.Areas.Identity.Data;
using Pradip.Data;
using Microsoft.AspNetCore.Identity;

namespace Pradip.Models
{
    public class clientRecord
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public String productName { get; set; }
        public string BuyerName { get; set; }
        public String Address { get; set; }
        public long Contact { get; set; }

      
    }
}
 