using UnityEngine;
using System.IO;
using UnityEditor;

// 假设 SignatureLoader 和 PUBLIC_KEY 已经在其他地方定义
// 这里省略了 SignatureLoader 和 PUBLIC_KEY 的定义代码

public class SmartCreat
{
    [MenuItem("Assets/SmartCreat/LuaScript",false,0)]
    public static void LuaScript()
    {
        // 获取当前选择的文件夹路径
        string selectedPath = "Assets";
        if (Selection.activeObject != null)
        {
            selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (File.Exists(selectedPath))
            {
                selectedPath = Path.GetDirectoryName(selectedPath);
            }
        }

        // 生成新的 Lua 脚本文件路径
        string newLuaScriptPath = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(selectedPath, "NewLuaScript.lua"));

        // 创建新的 Lua 脚本文件
        try
        {
            using (StreamWriter writer = File.CreateText(newLuaScriptPath))
            {
                // 可以在这里写入 Lua 脚本的初始内容
                writer.WriteLine("-- This is a new Lua script.");
            }

            // 刷新资源数据库
            AssetDatabase.Refresh();

            // 高亮显示新创建的文件
            UnityEngine.Object newAsset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(newLuaScriptPath);
            EditorGUIUtility.PingObject(newAsset);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to create Lua script: {e.Message}");
        }
    }
}
