namespace TheCatProject.Models
{
    public partial class PTag
    {
        public int ID { get; set; }

        public int CID { get; set; }

        public int FirstTrait { get; set; }

        public int SecondTrait { get; set; }

        public int ThirdTrait { get; set; }

        public virtual Cat Cat { get; set; }

        public virtual Personality Personality { get; set; }

        public virtual Personality Personality1 { get; set; }

        public virtual Personality Personality2 { get; set; }
    }
}
