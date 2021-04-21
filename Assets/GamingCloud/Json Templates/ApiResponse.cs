using System.Collections.Generic;

namespace gamingCloud.templates
{

    public class ApiResponse
    {
        public Dictionary<string, dynamic> response= new Dictionary<string, dynamic>();
        public RestfulMessages status = RestfulMessages.successful;
        public bool isSuccessful = true;

        public ApiResponse(bool isSuccessful, int status, Dictionary<string,dynamic> resp = null)
        {
            if (isSuccessful)
                response = resp;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }
                
        }
    }
}
