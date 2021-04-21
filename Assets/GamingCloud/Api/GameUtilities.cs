using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using gamingCloud.templates;
using Newtonsoft.Json.Linq;

namespace gamingCloud
{
    public class DBaaSResponse
    {
        public Dictionary<string, dynamic> response;
        public RestfulMessages status;
        public DBaaSResponse(Dictionary<string, dynamic> _response, RestfulMessages _status)
        {
            response = _response;
            status = _status;
        }
    }
    class dataTMP
    {
        public string schema_id;
        public Dictionary<string, dynamic> body = new Dictionary<string, dynamic>();
    }
    class dataTMPEdit
    {
        public string schema_id;
        public string document_id;
        public Dictionary<string, dynamic> body = new Dictionary<string, dynamic>();
    }
    public class GameUtilities : HttpRequest
    {

        /// <summary>
        /// use this method to get your Achivement that are set before.
        /// </summary>
        ///  <param name="mode"> the mode of Achivement for getting data </param>
        public static async Task<AchivementResponse> GetAchivementData(AchivementMode mode)
        {
            AchivementResponse temp = new AchivementResponse();
            ServerResponse req = await HttpRequest.GetRequestAsync("/game/achievments?mode=" + (int)mode);
            JArray data = JArray.Parse(req.responseMessage);
            if (req.IsSuccess == true)
            {
                foreach (JObject Adata in data)
                {
                    AchivementTemplate Achivedata = new AchivementTemplate();
                    Achivedata.achivId = Adata["_id"].ToString();
                    Achivedata.title = Adata["title"].ToString();
                    Achivedata.points = Adata["points"].ToObject<int>();
                    Achivedata.description = Adata["description"].ToString();
                    Achivedata.done = Adata["done"].ToObject<bool>();
                    temp.data.Add(Achivedata);
                    temp.isSuccessful = true;
                    temp.status = RestfulMessages.successful;
                }

                return temp;
            }
            return new AchivementResponse();


        }

        /// <summary>
        /// this method is used for getting your table's data from server
        /// </summary>
        ///  <param name="TableName"> the name of table </param>
        public static async Task<ApiResponseArray> GetTableDataByName(string TableName)
        {

            ServerResponse req = await HttpRequest.GetRequestAsync("/DBaaS/byName/" + TableName);
            var resp = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(req.responseMessage);
            if (req.IsSuccess)
            {

                return new ApiResponseArray(true, req.responseStatusCode, resp);
            }
            else if (req.responseStatusCode == 200)
            {
                return new ApiResponseArray(true, (int)RestfulMessages.tableNotFound, null);

            }
            return new ApiResponseArray(false, req.responseStatusCode);



        }

        /// <summary>
        /// this method is used for getting your table's data from server
        /// </summary>
        ///  <param name="TableId"> the id of table </param>        
        public static async Task<ApiResponseArray> GetTableDataById(string TableId)
        {
            ServerResponse req = await HttpRequest.GetRequestAsync("/DBaaS/byId/" + TableId);

            var resp = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(req.responseMessage);
            if (req.IsSuccess)
            {

                return new ApiResponseArray(true, req.responseStatusCode, resp);
            }
            else if (req.responseStatusCode == 200)
            {
                return new ApiResponseArray(true, (int)RestfulMessages.tableNotFound, null);

            }
            return new ApiResponseArray(false, req.responseStatusCode);


        }

        /// <summary>
        /// this method is called for doing (using ) your achivement.
        /// </summary>
        ///  <param name="id"> the id for doing Achivement </param>
        public static async Task<ApiResponse> DoAchivement(string id)
        {
            ServerResponse req = await HttpRequest.PutRequestAsync("/game/achievments/use", new Dictionary<string, dynamic> { { "achivId", id } });
            var resp = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(req.responseMessage);
            if (req.IsSuccess == true)
            {
                return new ApiResponse(true, req.responseStatusCode, resp);
            }
            else if (req.responseStatusCode == 300)
                return new ApiResponse(false, req.responseStatusCode);

            return new ApiResponse(false, req.responseStatusCode);


        }
        
        /// <summary>
        /// this method is used for add document in DBaaS
        /// </summary>
        ///  <param name="tableId"> DBaaS Collection Id </param>
        ///  <param name="data"> your data </param>
        public static async Task<DBaaSResponse> AddDocumentToDBaaS<T>(string tableId, T data)
        {
            var stringJSON = JsonConvert.SerializeObject(data);
            dataTMP tmp = new dataTMP();
            tmp.body = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(stringJSON);
            tmp.schema_id = tableId;
            var values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(tmp));
            ServerResponse req = await PostRequestAsync("/DBaaS/document", values);

            if (req.IsSuccess == true)
            {
                return new DBaaSResponse(JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(req.responseMessage), RestfulMessages.successful);
            }
            else if (req.responseMessage == "4043")
            {
                return new DBaaSResponse(null, RestfulMessages.SchemaIdNotFound);

            }
            else if (req.responseMessage == "4011")
            {
                return new DBaaSResponse(null, RestfulMessages.NoAnyRow);

            }
            return new DBaaSResponse(null, RestfulMessages.failure);
        }
        
        /// <summary>
        /// this method is used for add document in DBaaS
        /// </summary>
        ///  <param name="recordId"> Document Id </param>
        ///  <param name="tableId"> DBaaS Collection Id </param>
        ///  <param name="data"> your new data </param>
        public static async Task<DBaaSResponse> EditDBaaSDocument<T>(string recordId, string tableId, T data)
        {
            var stringJSON = JsonConvert.SerializeObject(data);
            dataTMPEdit tmp = new dataTMPEdit();
            tmp.body = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(stringJSON);
            tmp.schema_id = tableId;
            tmp.document_id = recordId;
            var values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(tmp));
            ServerResponse req = await PutRequestAsync("/DBaaS/document", values);

            if (req.IsSuccess == true)
            {
                var resp = (JObject)JsonConvert.DeserializeObject(req.responseMessage);
                var res = resp["newDocument"];
                return new DBaaSResponse(JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(res)), RestfulMessages.successful);
            }
            else if (req.responseMessage == "4043")
            {
                return new DBaaSResponse(null, RestfulMessages.SchemaIdNotFound);

            }
            else if (req.responseMessage == "4011")
            {
                return new DBaaSResponse(null, RestfulMessages.NoAnyRow);

            }
            return new DBaaSResponse(null, RestfulMessages.failure);
        }
        
        /// <summary>
        /// this method is used for add document in DBaaS
        /// </summary>
        ///  <param name="recordId"> Document Id </param>
        ///  <param name="tableId"> DBaaS Collection Id </param>
        public static async Task<bool> DeleteDocumentFromDBaaS(string recordId, string tableId)
        {
            ServerResponse req = await DeleteRequestAsync("/DBaaS/document/" + tableId + "/" + recordId);
            var resp = (JObject)JsonConvert.DeserializeObject(req.responseMessage);
            var res = resp["delete"];

            if (res.ToObject<bool>() == true)
            {
                return true;
            }
            return false;
        }


    }


}
