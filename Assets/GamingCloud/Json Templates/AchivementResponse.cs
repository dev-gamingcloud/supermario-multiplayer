using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingCloud.templates
{
    public class AchivementResponse
    {
        public bool isSuccessful = true;
        public List<AchivementTemplate> data = new List<AchivementTemplate>() ;
        public RestfulMessages status = RestfulMessages.successful;
    }
}
