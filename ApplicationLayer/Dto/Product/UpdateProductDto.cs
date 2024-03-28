using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dto.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; } 

        public int CategoryId {  get; set; }    

         

        public int BrandId { get; set; }    


        


        public string Name { get; set; }

        public string Specification { get; set; }



        public string Price { get; set; } 



    }
}
