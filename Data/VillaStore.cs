using MagicVilla_VillaApi.Models.Dto;

namespace MagicVilla_VillaApi.Data
{
    public static class VillaStores
    { 
        public static List<VillaDTO> villaList =   new List<VillaDTO> {
                new VillaDTO { Id = 1, Name = "Pool View" , Sqft = 1400 , Occupency = 10},
                new VillaDTO { Id = 2, Name = "Beach View", Sqft =1500 , Occupency = 50}
            }; 
    }
}
