using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewApi.Models
{
    public class item
    {
        public int id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public double price { get; set; } 

        public byte[]? image { get; set; }

        [ForeignKey("category")]
        public int categoryid { get; set; }

        //navigation properity
        public Category category { get; set; }



    }
}
