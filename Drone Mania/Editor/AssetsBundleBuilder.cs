using System;
using UnityEditor;
using UnityEngine;

public class AssetsBundleBuilder
{
    [MenuItem("Assets/Create Assets Bundles")]
    private static void BuildAllAssetBundles(){
        string assetsbundledirectorypath=Application.dataPath+"/../AssetsBundles";
        try{
            BuildPipeline.BuildAssetBundles(assetsbundledirectorypath,BuildAssetBundleOptions.None,EditorUserBuildSettings.activeBuildTarget);
        }
        catch(Exception e){
            Debug.LogWarning(e);
        }
    }
}
