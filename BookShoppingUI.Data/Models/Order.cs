using System.ComponentModel.DataAnnotations;

namespace BookShoppingUI.Models
{
	public class Order
	{
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        public int OrderStatusId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
