using ApplicationLayer.ApplicationConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Common
{
    public class APIResponse
    {


        public HttpStatusCode StatusCodes { get; set; }

        public bool Issuccess { get; set; } = false;

        public object Result { get; set; }

        public string DisplayMessage { get; set; } = "";

        public List<APIError> Errors { get; set; } = new();

        public List<APIWarning> Warnings { get; set; } = new();



        public void AddError(string erroMessage)
        {

            APIError Error = new APIError(description: erroMessage);
            Errors.Add(Error);


        }


        public void AddWarning(string warningMessage)
        {


            APIWarning warning = new APIWarning(description: warningMessage);

            Warnings.Add(warning);




        }


        public APIResponse badrequest(HttpStatusCode statusCode)
        {

            
            if (statusCode == HttpStatusCode.BadRequest)
            {
                this.StatusCodes = HttpStatusCode.BadRequest;



            }

            else if (statusCode == HttpStatusCode.InternalServerError) 
            {
                this.StatusCodes = HttpStatusCode.InternalServerError;

            }

            else
            {
                this.StatusCodes = HttpStatusCode.NotFound;


            }
            this.Issuccess = false;
            this.DisplayMessage = CommonMessage.UpdateOperationFailed;

            return this;

        }







    }
}