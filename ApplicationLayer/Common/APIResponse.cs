using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Common
{
    partial class APIResponse
    {
        public HttpStatusCode StatusCodes { get; set; }

        public bool Issuccess { get; set; }  = false;

        public object Result { get; set; } 

        public string DisplayMessage { get; set; } = "";

        public List<APIError> Errors { get; set; } = new();

        public List<APIWarning> Warnings { get; set; } = new();


       public void AddError(string erroMessage)
        {
            
           APIError Error = new APIError(description:erroMessage );
            Errors.Add(Error);


        }


        public void AddWarning(string warningMessage)
        {


           APIWarning warning = new APIWarning(description:warningMessage );

            Warnings.Add(warning);




        }
        


         



    }
}
