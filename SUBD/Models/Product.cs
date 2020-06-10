using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public int Name { get; set; }
        [Required]
        [Column("count")]
        public int Count { get; set; }

        [Required]
        [Column("price")]
        public int Price { get; set; }

        [Required] 
        [Column("type_id")]
        public int typeId { get; set; }
        [Required]
        [Column("provider_id")]
        public int ProviderId { get; set; }
       
        [ForeignKey("type_Id")]
        public int Type { get; set; }
        [ForeignKey("provider_id")]
        public int Provider { get; set; }

        public List<Order> Orders { get; set; }
    }
}
