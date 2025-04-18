using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class BuilderBundle
{
    static string dest = "Assets/StreamingAssets";  //打包的路径

    [MenuItem("Tools/bundle/win", false, 0)]
    public static void buildWin()  //打包Windows平台
    {
        build(BuildTarget.StandaloneWindows);  //打包Windows平台
    }
    public static void build(BuildTarget target)  //打包
    {
        if (!Directory.Exists(dest)){
            Directory.CreateDirectory(dest);
        }
        else{
            Directory.Delete(dest, true);  //删除目录下的所有文件
            Directory.CreateDirectory(dest);  //创建目录 
        }
            
        BuildPipeline.BuildAssetBundles(dest,
            BuildAssetBundleOptions.StrictMode |
            BuildAssetBundleOptions.DisableLoadAssetByFileName |  //打包选项    
            BuildAssetBundleOptions.DisableLoadAssetByFileNameWithExtension |  //打包选项   
            BuildAssetBundleOptions.DeterministicAssetBundle, //打包选项
            target
        );  //打包到StreamingAssets目录下，打包的平台为Windows

        AssetDatabase.Refresh();  //刷新资源
    }
}
