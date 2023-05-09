using System;
using UnityEditor;
using UnityEngine;

public class BuildScript
{
    private static readonly string[] sceneList = new[]
    {
        "Assets/Scenes/BootScene.unity", "Assets/Scenes/GameScene.unity"
    };

    [MenuItem("Build/Build All")]
    public static void BuildAll()
    {
        BuildWindowsServer();
        BuildLinuxServer();
        BuildWindowsClient();
    }

    [MenuItem("Build/Build Server (Windows)")]
    public static void BuildWindowsServer()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = sceneList;
        buildPlayerOptions.locationPathName = "Builds/Windows/Server/Server.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.subtarget = (int) StandaloneBuildSubtarget.Server;
        buildPlayerOptions.options = BuildOptions.CompressWithLz4HC;

        Debug.Log(
            $"Building Server (Windows)..., Target {buildPlayerOptions.target}, SubTarget {buildPlayerOptions.subtarget}");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Console.WriteLine("Built Server (Windows).");
    }

    [MenuItem("Build/Build Server (Linux)")]
    public static void BuildLinuxServer()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = sceneList;
        buildPlayerOptions.locationPathName = "Builds/Linux/Server/Server.x86_64";
        buildPlayerOptions.target = BuildTarget.StandaloneLinux64;
        buildPlayerOptions.subtarget = (int) StandaloneBuildSubtarget.Server;
        buildPlayerOptions.options = BuildOptions.CompressWithLz4HC;

        Console.WriteLine("Building Server (Linux)...");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Console.WriteLine("Built Server (Linux).");
    }


    [MenuItem("Build/Build Client (Windows)")]
    public static void BuildWindowsClient()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = sceneList;
        buildPlayerOptions.locationPathName = "Builds/Windows/Client/Client.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.subtarget = (int) StandaloneBuildSubtarget.Player;
        buildPlayerOptions.options = BuildOptions.CompressWithLz4HC;

        Console.WriteLine("Building Client (Windows)...");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Console.WriteLine("Built Client (Windows).");
    }
}