using MagicVilla_VillaApi.Models.Dto;

namespace MagicVilla_VillaApi.Data
{
    public static class VillaStore
    { 
        public static List<VillaDTO> villaList =  new List<VillaDTO> {
                new VillaDTO { Id = 1, Name = "Pool View" , sqft = 1400 , occupency = 10},
                new VillaDTO { Id = 2, Name = "Beach View", sqft =1500 , occupency = 50}
            }; 
    }
}
