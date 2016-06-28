﻿using System.Collections;
using Tangzx.ABSystem;
using UnityEngine;

/// <summary>
/// 注意：未经测试，不要用
/// </summary>
class AndroidAssetBundleLoader : MobileAssetBundleLoader
{
    protected override IEnumerator LoadFromBuiltin()
    {
        //兼容低版本API
#if UNITY_4 || UNITY_5_1 || UNITY_5_2
        _bundle = AssetBundle.CreateFromFile(_assetBundleSourceFile);
        yield return null;
#else
        //直接用 LoadFromFile
        _assetBundleSourceFile = bundleManager.pathResolver.GetBundleSourceFile(bundleName, false);
        AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync(_assetBundleSourceFile);
        yield return req;
        _bundle = req.assetBundle;
#endif
        Complete();
    }
}