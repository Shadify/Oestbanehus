namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Author { get; set; }

        public int ApartmentId { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public string Picture { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
