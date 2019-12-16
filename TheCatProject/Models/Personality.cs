namespace TheCatProject.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Personality
    {
        public Personality()
        {
            PTags = new HashSet<PTag>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        public virtual ICollection<PTag> PTags { get; set; }
    }
}
