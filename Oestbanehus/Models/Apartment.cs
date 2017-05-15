namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Apartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartment()
        {
            ConditionsOfItems = new HashSet<ConditionsOfItem>();
            Persons = new HashSet<Person>();
            Requests = new HashSet<Request>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int BuildingId { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public int NumberOfRooms { get; set; }

        public int Floor { get; set; }

        [Required]
        [StringLength(1)]
        public string Side { get; set; }

        public int ApartmentNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Street { get; set; }

        public virtual Building Building { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConditionsOfItem> ConditionsOfItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Persons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
