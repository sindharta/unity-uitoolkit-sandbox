using System;
using UnityEngine;

[Serializable]
public class FolderSO : ScriptableObject {
    public void SetFolder(Folder folder) => m_folder = folder;
    
//--------------------------------------------------------------------------------------------------------------------------------------------------------------    
    [SerializeField] private Folder m_folder;
}