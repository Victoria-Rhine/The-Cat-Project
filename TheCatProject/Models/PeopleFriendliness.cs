namespace TheCatProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PeopleFriendliness")]
    public partial class PeopleFriendliness
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PeopleFriendliness()
        {
            Cats = new HashSet<Cat>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Response { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cat> Cats { get; set; }
    }
}
