namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ApartmentId { get; set; }

        public int PersonId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(255)]
        public string PublishedDate { get; set; }

        public virtual Person Person { get; set; }
    }
}
