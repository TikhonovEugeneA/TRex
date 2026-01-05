using UnityEngine;

public class DesktopLayerPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] private GameObject desktopLayer;

    private void Awake()
    {
#if UNITY_STANDALONE
        desktopLayer.SetActive(true);
#endif
    }
}
