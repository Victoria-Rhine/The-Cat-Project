namespace TheCatProject.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cat
    {
        public Cat()
        {
            PTags = new HashSet<PTag>();
            Traits = new HashSet<Trait>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Sex { get; set; }

        public virtual ICollection<PTag> PTags { get; set; }

        public virtual ICollection<Trait> Traits { get; set; }
    }
}
