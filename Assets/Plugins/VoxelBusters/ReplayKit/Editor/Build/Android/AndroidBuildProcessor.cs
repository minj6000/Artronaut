﻿#if UNITY_ANDROID
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.Editor;

namespace VoxelBusters.ReplayKit.Editor.Build.Android
{
    public class AndroidBuildProcessor : IPreprocessBuildWithReport
    {
        #region IPostprocessBuildWithReport implementation

        public int callbackOrder => 1;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (report.summary.platform != BuildTarget.Android) return;

            if (!ReplayKitSettingsEditorUtility.SettingsExists) return;

            var     defaultSettings = ReplayKitSettingsEditorUtility.DefaultSettings;

            // Regenerate manifest with the latest settings
            AndroidManifestGenerator.GenerateManifest(defaultSettings);
        }

        #endregion
    }
}
#endif