using UnityEditor;

public class GcDashboard : EditorWindow
{
    [MenuItem("GamingCloud/Go To Dashboard")]
    static void Init()
    {

        Help.BrowseURL("https://dev.gamingcloud.ir");
    }
}
