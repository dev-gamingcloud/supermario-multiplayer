using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingCloud
{

    public class CalendarEvent
    {

        public CalendarEvent()
        {

        }
        public CalendarEvent(int code, string fa_description)
        {
            this.fa_description = fa_description;
            this.key = (CalendarEvents)code;
        }

        public string fa_description;
        public CalendarEvents key;
    }
}
