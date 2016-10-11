using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hero2.Entities
{
    [Table("ViewTemplate")]
    public class Slide
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public virtual IEnumerable<ContentItem> Items { get; set; }
        [Required]
        public int ViewType { get; set; }
    }
}