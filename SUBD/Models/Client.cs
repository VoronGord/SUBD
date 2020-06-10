using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Models
{
    [Table("client")]
    public class Client 
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Key]
        [Required]
        [Column("number")]
        public string Number { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }


        public List<Order> Orders { get; set; }

    }
}
