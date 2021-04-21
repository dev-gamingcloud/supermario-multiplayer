using System.Collections;
using System.Collections.Generic;


namespace gamingCloud.Network
{

    [System.Serializable]
    public class PlayerModel
    {
        [ShowOnly] public string netId;
        [ShowOnly] public string name;

        // Dictionary<string, dynamic> _model;

        // public Dictionary<string, dynamic> model
        // {
        //     set { return; }
        //     get { return _model; }
        // }

        public PlayerModel(/* Dictionary<string, dynamic> model,  */string netId, string name)
        {
            this.netId = netId;
            this.name = name;
            // this._model = model;
        }

        // public T getPlayerModel<T>()
        // {
        //     return JsonParser.ConvertDictionaryToSchema<T>(this._model);
        // }
    }
}