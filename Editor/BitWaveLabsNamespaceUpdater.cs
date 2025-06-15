using UnityEditor;
using UnityEngine;
using System.IO;

public static class BitWaveLabsNamespaceUpdater
{
    [MenuItem("BitWave Labs/Update Root Namespace")]
    public static void UpdateRootNamespace()
    {
     
        string dataPath = Application.dataPath;
        string projectRoot = Path.GetDirectoryName(dataPath);
        string projectName = Path.GetFileName(projectRoot);
        string newNamespace = $"BitWaveLabs.{projectName}";
        EditorSettings.projectGenerationRootNamespace = newNamespace;
        Debug.Log($"[BitWave Labs] Root namespace updated to “{newNamespace}”");
    }
}