namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ConditionsOfItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ApartmentId { get; set; }

        public int ConditionType { get; set; }

        [Required]
        public string Description { get; set; }

        public string Picture { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        public virtual Apartment Apartment { get; set; }

        public virtual ConditionType ConditionType1 { get; set; }
    }
}
