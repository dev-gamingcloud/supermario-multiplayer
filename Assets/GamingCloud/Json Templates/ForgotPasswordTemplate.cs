using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingCloud.templates
{
    public class ForgotPasswordTemplate
    {
        public string mask;
        public RestfulMessages status;

        public ForgotPasswordTemplate(string _mask, RestfulMessages _status)
        {
            this.mask = _mask;
            this.status = _status;
        }
    }



}