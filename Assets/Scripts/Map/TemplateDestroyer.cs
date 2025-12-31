using Unity.VisualScripting;
using UnityEngine;
    
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class TemplateDestroyer : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private MapSpawner spawner;

    private void Awake()
    {
        if (spawner == null) spawner = FindFirstObjectByType<MapSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "LocationTemplate":
                spawner.DeleteTemplate(other.transform.parent.gameObject);
                break;
        }
    }
    
}
