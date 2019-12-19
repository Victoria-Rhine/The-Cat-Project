using System.Collections.Generic;

namespace TheCatProject.Models.ViewModels
{
    public class PersonalityDetailsView
    {
        public int CatID { get; set; }
        public string CatName { get; set; }
        public int pTagID { get; set; }
        public int PersonalityID { get; set; }
        public string PersonalityType { get; set; }

        // not sure if this is needed but maybe for future features idk
        public virtual ICollection<PTag> PTags { get; set; }
    }
}