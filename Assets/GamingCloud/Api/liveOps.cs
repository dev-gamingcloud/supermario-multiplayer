using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace gamingCloud
{

    public class LiveOps : HttpRequest
    {
        class tmp_event
        {
            public string name;
            public int code;
        }

        ///<summary>
        ///get Today Event
        ///</summary>
        public static async Task<CalendarEvent> GetCalendarEvent()
        {
            var resp = await GetRequestAsync("/liveOps/calendar/event");
            tmp_event _Event = JsonConvert.DeserializeObject<tmp_event>(resp.responseMessage);
            return new CalendarEvent(_Event.code, _Event.name);
        }

        ///<summary>
        ///get event of specific date
        ///<param name="day">your day</param>
        ///<param name="month">your month</param>
        ///</summary>
        public static async Task<CalendarEvent> GetCalendarEvent(int day, int month)
        {
            var resp = await GetRequestAsync("/liveOps/calendar/event?day=" + day + "&month=" + month);
            tmp_event _Event = JsonConvert.DeserializeObject<tmp_event>(resp.responseMessage);
            return new CalendarEvent(_Event.code, _Event.name);
        }
    }
}
