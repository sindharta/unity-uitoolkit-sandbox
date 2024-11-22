using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Folder {

    public Folder(string name) {
        m_name = name;
        m_subFolders = new List<Folder>();
        m_files = new List<string>();
    }

    public void AddFile(string fileName) {
        m_files.Add(fileName);
    }

    public void AddSubFolder(Folder folder) {
        m_subFolders.Add(folder);
    }

    public void Display(int indent = 0) {
        Console.WriteLine(new String(' ', indent) + m_name);
        foreach (var file in m_files)
        {
            Console.WriteLine(new String(' ', indent + 2) + file);
        }
        foreach (var folder in m_subFolders)
        {
            folder.Display(indent + 2);
        }
    }
    
//--------------------------------------------------------------------------------------------------------------------------------------------------------------    
    [SerializeField] private string m_name;
    [SerializeField] private List<Folder> m_subFolders;
    [SerializeField] private List<string> m_files;

}