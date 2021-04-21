using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingCloud.templates
{
    public class PlayerStorageResponseJson
    {
        public RestfulMessages status = RestfulMessages.successful;
        public Dictionary<string, dynamic> value;
        public bool isSuccessful = true;

        public PlayerStorageResponseJson(bool isSuccessful, int status, Dictionary<string, dynamic> value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseInt
    {
        public RestfulMessages status = RestfulMessages.successful;
        public int? value;
        public bool isSuccessful = true;

        public PlayerStorageResponseInt(bool isSuccessful, int status, int? value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseString
    {
        public RestfulMessages status = RestfulMessages.successful;
        public string value;
        public bool isSuccessful = true;

        public PlayerStorageResponseString(bool isSuccessful, int status, string value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseBool
    {
        public RestfulMessages status = RestfulMessages.successful;
        public bool? value;
        public bool isSuccessful = true;

        public PlayerStorageResponseBool(bool isSuccessful, int status, bool? value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseDouble
    {
        public RestfulMessages status = RestfulMessages.successful;
        public double? value;
        public bool isSuccessful = true;

        public PlayerStorageResponseDouble(bool isSuccessful, int status, double? value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseFloat
    {
        public RestfulMessages status = RestfulMessages.successful;
        public float? value;
        public bool isSuccessful = true;

        public PlayerStorageResponseFloat(bool isSuccessful, int status, float? value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }

    public class PlayerStorageResponseLong
    {
        public RestfulMessages status = RestfulMessages.successful;
        public long? value;
        public bool isSuccessful = true;

        public PlayerStorageResponseLong(bool isSuccessful, int status, long? value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseLongArray
    {
        public RestfulMessages status = RestfulMessages.successful;
        public long[] value;
        public bool isSuccessful = true;

        public PlayerStorageResponseLongArray(bool isSuccessful, int status, long[] value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseBoolArray
    {
        public RestfulMessages status = RestfulMessages.successful;
        public bool[] value;
        public bool isSuccessful = true;

        public PlayerStorageResponseBoolArray(bool isSuccessful, int status, bool[] value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseIntArray
    {
        public RestfulMessages status = RestfulMessages.successful;
        public int[] value;
        public bool isSuccessful = true;

        public PlayerStorageResponseIntArray(bool isSuccessful, int status, int[] value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseStringArray
    {
        public RestfulMessages status = RestfulMessages.successful;
        public string[] value;
        public bool isSuccessful = true;

        public PlayerStorageResponseStringArray(bool isSuccessful, int status, string[] value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseFloatArray
    {
        public RestfulMessages status = RestfulMessages.successful;
        public float[] value;
        public bool isSuccessful = true;

        public PlayerStorageResponseFloatArray(bool isSuccessful, int status, float[] value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }
    public class PlayerStorageResponseDoubleArray
    {
        public RestfulMessages status = RestfulMessages.successful;
        public double[] value;
        public bool isSuccessful = true;

        public PlayerStorageResponseDoubleArray(bool isSuccessful, int status, double[] value = null)
        {
            if (isSuccessful)
                this.value = value;
            else
            {
                this.status = (RestfulMessages)status;
                this.isSuccessful = false;
            }

        }
    }


}
