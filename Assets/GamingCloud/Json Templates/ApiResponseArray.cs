using System.Collections.Generic;

namespace gamingCloud.templates
{

    public class ApiResponseArray
    {
        public List<Dictionary<string, dynamic> >response = new List<Dictionary<string, dynamic>>();
        public RestfulMessages status = RestfulMessages.successful;
        public bool isSuccessful = true;

        public ApiResponseArray(bool isSuccessful, int status, List<Dictionary<string, dynamic> >resp = null)
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
