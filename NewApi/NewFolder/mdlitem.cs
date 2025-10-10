using System.ComponentModel.DataAnnotations;

namespace NewApi.NewFolder
{
    public class mdlitem
    {


        [MaxLength(100)]
        public string Name { get; set; }
        public double price { get; set; }

        public IFormFile image { get; set; }
        public int categoryid { get; set; }

    }
}
