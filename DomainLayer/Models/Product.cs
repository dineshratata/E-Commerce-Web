using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Product : BaseModel
    {
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public int BrandId { get; set; }    

        public Brand Brand { get; set; }


        public string Name { get; set; }    

        public string Specification  { get; set; }



        public string Price { get; set; }   




    }
}
