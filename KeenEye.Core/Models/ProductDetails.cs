
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KeenEye.Core.Models
{
    public class ProductDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Category { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ImageIdentifier { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? MinimumQuantity { get; set; }
        public decimal? DiscountRate { get; set; }

    }
}
