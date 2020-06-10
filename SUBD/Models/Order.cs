using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("client_id")]
        public int clientId { get; set; }
        [Required]
        [Column("product_id")]
        public int ProductId { get; set; }

        [ForeignKey("client_Id")]
        public int Client { get; set; }
        [ForeignKey("product_id")]
        public int Product { get; set; }
    }
}
 
