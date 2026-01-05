using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class CommandBuild 
{
    public static void DoCommonBuildStuff(string outPath, BuildTarget buildTarget) 
    {
        try
        {
            string[] scenes = GetEnabledScenes();
            
            if (scenes.Length == 0)
            {
                return;
            }
            
            string directory = Path.GetDirectoryName(outPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            BuildPipeline.BuildPlayer(scenes, outPath, buildTarget, BuildOptions.None);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Ошибка при сборке: {ex.Message}");
            throw;
        }
    }
    
    private static string[] GetEnabledScenes()
    {
        var scenesList = new System.Collections.Generic.List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
                scenesList.Add(scene.path);
        }
        return scenesList.ToArray();
    }
    public static void BuildWindows()
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string buildPath = Path.Combine(desktop, "TRex.exe");
        
        DoCommonBuildStuff(buildPath, BuildTarget.StandaloneWindows64);
    }

    public static void BuildLinux()
    {
        string home = Environment.GetEnvironmentVariable("HOME");
        if (string.IsNullOrEmpty(home))
        {
            return;
        }
        
        string desktop = Path.Combine(home, "Desktop");
        string buildPath = Path.Combine(desktop, "TRex.x86_64");
        
        DoCommonBuildStuff(buildPath, BuildTarget.StandaloneLinux64);
    }

    public static void BuildAndroid() 
    {
        string projectRoot = Application.dataPath + "/../";
        string buildPath = Path.Combine(projectRoot, "Builds", "Android", "TRex.apk");
        
        PlayerSettings.applicationIdentifier = "com.yourcompany.trex";
        
        DoCommonBuildStuff(buildPath, BuildTarget.Android);
    }
}