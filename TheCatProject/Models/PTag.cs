namespace TheCatProject.Models
{
    public partial class PTag
    {
        public int ID { get; set; }

        public int CID { get; set; }

        public int PID { get; set; }

        public virtual Cat Cat { get; set; }

        public virtual Personality Personality { get; set; }
    }
}
