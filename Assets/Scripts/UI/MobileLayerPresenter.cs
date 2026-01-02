using UnityEngine;

public class MobileLayerPresenter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject mobileLayer;

    private void Awake()
    {
#if UNITY_ANDROID
        mobileLayer.SetActive(true);
#endif
    }
}
