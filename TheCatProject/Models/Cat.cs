namespace TheCatProject.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Cat
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Cat name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cat age is required")]
        public double Age { get; set; }

        [Required(ErrorMessage = "Sex selection is required")]
        [StringLength(50)]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Temperament is required")]
        public int AnimalFriendID { get; set; }

        [Required(ErrorMessage = "Breed is required")]
        public int BreedID { get; set; }

        [Required(ErrorMessage = "Environment is required")]
        public int LifestyleID { get; set; }

        [Required(ErrorMessage = "Color is required")]
        public int ColorID { get; set; }

        [Required(ErrorMessage = "Play style is required")]
        public int PlayID { get; set; }

        [Required(ErrorMessage = "First trait is required")]
        public int TraitsID_1 { get; set; }

        [Required(ErrorMessage = "Second trait is required")]
        public int TraitsID_2 { get; set; }

        [Required(ErrorMessage = "Third trait is required")]
        public int TraitsID_3 { get; set; }

        [Required(ErrorMessage = "Temperament is required")]
        public int PeopleFriendID { get; set; }

        [Required(ErrorMessage = "Water response is required")]
        public int WaterID { get; set; }

        public virtual AnimalFriendliness AnimalFriendliness { get; set; }

        public virtual Breed Breed { get; set; }

        public virtual Color Color { get; set; }

        public virtual Lifestyle Lifestyle { get; set; }

        public virtual PeopleFriendliness PeopleFriendliness { get; set; }

        public virtual Play Play { get; set; }

        public virtual Trait Trait { get; set; }

        public virtual Trait Trait1 { get; set; }

        public virtual Trait Trait2 { get; set; }

        public virtual Water Water { get; set; }
    }
}
