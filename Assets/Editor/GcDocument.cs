using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GCDocument : EditorWindow
{
    [MenuItem("GamingCloud/Go To Document")]
    static void Init()
    {

        Help.BrowseURL("https://dev.gamingcloud.ir/documnet");
    }





}