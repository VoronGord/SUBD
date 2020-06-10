using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Models
{
    [Table("department")]
    public class DType
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("type")]
        public string Types { get; set; }
        [Required]
       
        public List<Product> Products { get; set; }
    }
}
