using hero2.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hero2.Entities
{
    [Table("ContentItem")]
    public class ContentItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }
        [Required]
        [DisplayName("ViewPosition")]
        public int ViewPosition { get; set; }
        [Required]
        [DisplayName("ViewTemplateId")]
        public int SlideId { get; set; }
        [Required]
        [DisplayName("ContentType")]
        public ContentType ContentType { get; set; }
        [DisplayName("Text")]
        [MaxLength(300)]
        public string Text { get; set; }
        [DisplayName("ImageUrl")]
        [MaxLength(100)]
        public string ImageURL { get; set; }
        [DisplayName("URL")]
        public string URL { get; set; }
    }
}