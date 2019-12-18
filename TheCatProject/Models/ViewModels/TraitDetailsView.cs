/* View model to gather all info needed to Traits Details page */

namespace TheCatProject.Models.ViewModels
{
    public class TraitDetailsView
    {
        public int CatID { get; set; }
        public string CatName { get; set; }
        public int ColorID { get; set; }
        public string CatColor { get; set; }
        public int BreedID { get; set; }
        public string CatBreed { get; set; }
    }
}