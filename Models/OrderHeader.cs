using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_website.Models
{
    public class OrderHeader
    {

        [Key]
        public int Id { get; set; }


        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }


        public DateTime OrderDate { get; set; }

        public double OrderTotal { get; set; }

        public string OrderStatus { get; set; }
    }
}
