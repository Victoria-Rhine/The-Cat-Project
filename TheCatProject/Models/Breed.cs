namespace TheCatProject.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Breed
    {
        public Breed()
        {
            Traits = new HashSet<Trait>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CatBreed { get; set; }

        public virtual ICollection<Trait> Traits { get; set; }
    }
}
