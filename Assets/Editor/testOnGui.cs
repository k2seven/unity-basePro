using UnityEditor;
using UnityEngine;

public class testOnGui : EditorWindow
{
    [MenuItem("Tools/My Window ongui")]
    static void ShowWindow()
    {
        GetWindow<testOnGui>("ongui");
    }
    void OnGUI()
    {
        if (GUILayout.Button("Generate Asset"))
        {
            Debug.Log("Generating...");
        }
    }
    
}