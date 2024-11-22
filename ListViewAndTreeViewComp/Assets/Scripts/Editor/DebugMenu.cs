using Unity.Mathematics.Geometry;
using UnityEditor;
using UnityEngine;

public class DebugMenu  {

    [MenuItem("Debug/Create New Folder Data")]
    static void CreateNewFolderData() {
        
        FolderSO folderSO = ScriptableObject.CreateInstance<FolderSO>();
        AssetDatabase.CreateAsset(folderSO, AssetDatabase.GenerateUniqueAssetPath("Assets/FolderData.asset"));
        
        Folder folder = new Folder(".");
        folderSO.SetFolder(folder);
        
        PopulateFolderRandomly(folder, 3, "");
        EditorUtility.SetDirty(folderSO);
        AssetDatabase.SaveAssets();
    }

    static void PopulateFolderRandomly(Folder folder, int maxDepth, string pathPrefix) {
        if (maxDepth <= 0)
            return;

        const int MAX_FILES_PER_FOLDER = 10;
        const string FILE_NAME_PREFIX = "File";
        int numFiles = Random.Range(1, MAX_FILES_PER_FOLDER); 
        for (int i = 0; i < numFiles; i++) {
            folder.AddFile($"{pathPrefix}/{FILE_NAME_PREFIX}_{i + 1}.txt");
        }

        const int MAX_SUB_FOLDERS = 3;
        int numSubFolders = Random.Range(1, MAX_SUB_FOLDERS); 
        for (int i = 0; i < numSubFolders; i++) {
            string subFolderName = $"SubFolder_{i + 1}";
            Folder subFolder = new Folder(subFolderName);
            folder.AddSubFolder(subFolder);
            PopulateFolderRandomly(subFolder, maxDepth - 1, $"{pathPrefix}/{subFolderName}");
        }
    }
}