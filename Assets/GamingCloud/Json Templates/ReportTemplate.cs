using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingCloud.templates
{
    public class ReportTemplate 
    {
        public string title;
        public string description;
        public string api;
        public string model;
        public string os;
        public string deviceId;
        public string gameVersion;
        public string devicename;

        public ReportTemplate(string _title , string _description)
        {
            this.description = _description;
            this.title= _title;
            this.gameVersion= Application.version;
            this.deviceId = SystemInfo.deviceUniqueIdentifier;
            this.model = SystemInfo.deviceModel;
            if (Application.platform == RuntimePlatform.Android)
            {
                string[] splitData = SystemInfo.operatingSystem.Split('/');
                this.os =  splitData[0];
                using (var version = new AndroidJavaClass("android.os.Build$VERSION"))
                {
                    this.api = version.GetStatic<int>("SDK_INT").ToString();
                }
            }
            else
            {
                this.os = SystemInfo.operatingSystem;

                this.api = null;
            }

        }

    }
}
