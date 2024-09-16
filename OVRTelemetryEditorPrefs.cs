using UnityEngine;
using UnityEditor;

// Sources:
// https://docs.unity3d.com/ScriptReference/EditorPrefs.html
// https://docs.unity3d.com/ScriptReference/EditorPrefs.SetInt.html
// https://communityforums.atmeta.com/t5/Unity-VR-Development/Always-pop-up-Help-to-improve-Meta-SDKs-window/td-p/1236066

/*
 * Stores and accesses Unity Editor preferences.
 * On macOS, EditorPrefs are stored in ~/Library/Preferences/com.unity3d.UnityEditor5.x.plist.
 * On Windows, EditorPrefs are stored in the registry under the HKCU\Software\Unity Technologies\Unity Editor 5.x key.
*/


public class OVRTelemetryEditorPrefs : EditorWindow
{
    private int intValue = 0;
    private string keyValueDefault = "OVRTelemetry.TelemetryEnabled";
    private string keyValue = "OVRTelemetry.TelemetryEnabled";
    private string link = "https://docs.unity3d.com/ScriptReference/EditorPrefs.SetInt.html";

    [MenuItem("EditorPrefs/OVRTelemetry TelemetryEnabled")]
    static void Init()
    {
        OVRTelemetryEditorPrefs window = (OVRTelemetryEditorPrefs)EditorWindow.GetWindow(typeof(OVRTelemetryEditorPrefs));
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Override OVRTelemetry TelemetryEnabled in Registry");

        bool openLink = EditorGUILayout.LinkButton(link);
        if (openLink) Application.OpenURL(link);
        EditorGUILayout.LabelField("Windows: [HKEY_CURRENT_USER\\SOFTWARE\\Unity Technologies\\Unity Editor 5.x]");
        EditorGUILayout.LabelField("On Windows, EditorPrefs are stored in the registry under the HKCU\\Software\\Unity Technologies\\Unity Editor 5.x key");
        EditorGUILayout.LabelField("On macOS, EditorPrefs are stored in ~/Library/Preferences/com.unity3d.UnityEditor5.x.plist");
        EditorGUILayout.LabelField("On Linux, EditorPrefs are stored in ~/.local/share/unity3d/prefs.");
        EditorGUILayout.LabelField("\n\n");

        EditorGUILayout.LabelField("Current stored Key");
        keyValue = EditorGUILayout.TextField("Key to write to Prefs: ", keyValue);
        if(string.IsNullOrEmpty(keyValue)) keyValue = keyValueDefault;

        int temp;
        temp = EditorPrefs.GetInt(keyValue, -1);

        EditorGUILayout.LabelField("Found stored value: " + temp.ToString());
        intValue = EditorGUILayout.IntField("Value to write to Prefs: ", intValue);
        
        if (GUILayout.Button("Save value: " + intValue.ToString()))
        {
            EditorPrefs.SetInt(keyValue, intValue);
            Debug.Log(keyValue + ": " + intValue);
        }

        EditorGUILayout.LabelField("\n");

        EditorGUILayout.LabelField("If you know what you are doing, then go ahead!");

        if (GUILayout.Button("Delete Key: " + keyValue))
        {
            EditorPrefs.DeleteKey(keyValue);
            temp = EditorPrefs.GetInt(keyValue, -1);

            Debug.Log(keyValue + " Found: " + temp);
        }
    }
}
