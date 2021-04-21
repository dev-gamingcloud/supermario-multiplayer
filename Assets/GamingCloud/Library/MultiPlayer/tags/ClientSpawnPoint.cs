using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingCloud.Network
{

    public enum SpawnClientType
    {
        ByObjectName, ByTag
    };

    [DisallowMultipleComponent]
    [AddComponentMenu("GamingCloud/GC Client Spawn Point")]
    public class ClientSpawnPoint : MonoBehaviour
    {

        [Header("Spawn Point Options")]
        public SpawnClientType SearchType = SpawnClientType.ByObjectName;
        [Tooltip("if check this, we detect it as dynamic for spawn point")]
        public bool IsPrefix = true;
        public string SpawnPointName = string.Empty;
    }
}
