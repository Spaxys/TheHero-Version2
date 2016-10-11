using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hero2.Entities
{
    [Table("GameTemplate")]
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual IEnumerable<Slide> Views { get; set; }
        public int StartView { get; set; }
        public int EndView { get; set; }
    }
}