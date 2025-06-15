using UnityEngine;
using UnityEditor;
using System.IO;

public static class BitWaveLabsFolderCreator
{
    private const string BaseFolder = "Assets/BitWaveLabs";

    [MenuItem("BitWave Labs/Create Default Folders")]
    public static void CreateDefaultFolders()
    {
        string dataPath = Application.dataPath;
        string projectRoot = Path.GetDirectoryName(dataPath);
        string projectName = Path.GetFileName(projectRoot);

        CreateIfMissing("Assets", "BitWaveLabs");

        string projectFolder = $"{BaseFolder}/{projectName}";
        CreateIfMissing(BaseFolder, projectName);

        string examplesFolder = $"{projectFolder}/Examples";
        CreateIfMissing(projectFolder, "Examples");
        CreateIfMissing(examplesFolder, "Scenes");

        string scriptsFolder = $"{projectFolder}/Scripts";
        CreateIfMissing(projectFolder, "Scripts");
        CreateIfMissing(scriptsFolder, "Editor");

        AssetDatabase.Refresh();
        Debug.Log($"[BitWave Labs] Default folders created under '{projectFolder}'.");
    }

    private static void CreateIfMissing(string parentPath, string childName)
    {
        string fullPath = $"{parentPath}/{childName}";

        if (!AssetDatabase.IsValidFolder(fullPath))
            AssetDatabase.CreateFolder(parentPath, childName);
    }
}