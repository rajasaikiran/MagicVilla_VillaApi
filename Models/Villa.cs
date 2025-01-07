using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaApi.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //automaticallyy handle the id no need to take care of id 
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupency { get; set; }
        public string ImageUrl {  get; set; }   
    }
}
