using System.IO;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class TemplatesLoader : MonoBehaviour
{
    [Header("Settings")]

    [Tooltip("Loaded templates")]
    [SerializeField] private List<GameObject> loadedTemplates;

    [Tooltip("Templates folder name in resourses")]
    [SerializeField] private string templatesFolderName;

    [Tooltip("Templates name prefix")]
    [SerializeField] private string templatesPrefix;

    [Tooltip("Templates count in resourses folder")]
    [SerializeField] private int templatesCount;
    public GameObject GetRandomTemplate()
    {
        string templateName = templatesFolderName + Random.Range(1, templatesCount);

        if (loadedTemplates.Exists(t => t.name == templateName))
        {
            GameObject template = loadedTemplates.Find(t => t.name == templateName);
            return template;
        }

        string templateResourcePath = Path.Combine(templatesFolderName, templateName);
        GameObject loadedTemplate = Resources.Load<GameObject>(templateResourcePath);
        
        loadedTemplates.Add(loadedTemplate);
        return loadedTemplate;
    }
}
