namespace TheCatProject.Models
{
    public partial class Trait
    {
        public int ID { get; set; }

        public int CatID { get; set; }

        public int ColorID { get; set; }

        public int BreedID { get; set; }

        public virtual Breed Breed { get; set; }

        public virtual Cat Cat { get; set; }

        public virtual Color Color { get; set; }
    }
}
