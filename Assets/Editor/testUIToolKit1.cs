using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class testUIToolKit1 : EditorWindow
{
    [MenuItem("Tools/My UIToolkit Window")]
    public static void ShowWindow()
    {
        GetWindow<testUIToolKit1>("UIToolkit Window");
    }
    public void CreateGUI()
    {
        // 从 UXML 文件加载
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
            "Assets/Editor/testuxml.uxml");
        visualTree.CloneTree(rootVisualElement);
        // 从 USS 文件加载样式
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(
            "Assets/Editor/testuss.uss");
        rootVisualElement.styleSheets.Add(styleSheet);
        // 获取按钮引用并添加点击事件
        var button = rootVisualElement.Q<Button>("my-button");
        button.clicked += () => Debug.Log("UIToolkit Button Clicked!");
    }
}
