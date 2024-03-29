using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ApplicationConstants
{
    public class ApplicationConstant
    {
    }

    public class CommonMessage {

        public const string RegisterSuccess = "RegisterUserSuccessFully";
        public const string RegisterFail = "RegisterUserFailed";

        public const string LoginSuccess = "Login SuccessFully";
        public const string LoginFail = "LoginFailed";

        public const string CreateOperationSuccess = "CreateOperationSuccess";
        public const string UpdateOperationSuccess = "UpdateOperationSuccess";
        public const string DeleteOperationSuccess = "DeleteOperationSuccess";

        public const string CreateOperationFailed = "CreateOperationFailed";
        public const string UpdateOperationFailed = "UpdateOperationFailed";
        public const string DeleteOperationFailed = "DeleteOperationFailed";


        public const string RecordNotFound = "RecordNotFound";
        public const string SystemError = "SomethingWentWrong";




    }
}
