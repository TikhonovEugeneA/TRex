using System.IO;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class TemplatesLoader : MonoBehaviour
{
    [Header("Settings")] 
    [Tooltip("Loaded templates.")]
    [SerializeField] private List<GameObject> loadedTemplates;
    
    [Tooltip("Templates folder name in resources.")]
    [SerializeField] private string templatesFolderName;

    [Tooltip("Template name prefix.")]
    [SerializeField] private string templatePrefix;
    
    [Tooltip("Templates count in resources folder.")]
    [SerializeField] private int templatesCount;

    public GameObject GetRandomTemplate()
    {
        int templateId = Random.Range(1, templatesCount);
        string templateName = templatePrefix + templateId;
        if (loadedTemplates.Exists(t => t.name == templateName))
        {
            Debug.Log("{<color=cyan><b>Template Loaded Log</b></color>} => [TemplatesLoader] - (<color=yellow>GetRandomTemplate</color>) -> Template " + templateName + " return from loaded templates.");
            GameObject template = loadedTemplates.Find(t => t.name == templateName);
            return template;
        }

        string templateResourcePath = Path.Combine(templatesFolderName, templateName);
        GameObject loadedTemplate = Resources.Load<GameObject>(templateResourcePath);
        loadedTemplates.Add(loadedTemplate);
        Debug.Log("{<color=cyan><b>Template Loaded Log</b></color>} => [TemplatesLoader] - (<color=yellow>GetRandomTemplate</color>) -> Template " + templateName + " loaded from resources.");
        return loadedTemplate;
    }
}