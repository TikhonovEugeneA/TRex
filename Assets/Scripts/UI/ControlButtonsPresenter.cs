using UnityEngine;

public class ControlButtonsPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] private GameObject controlButtonContainer;

    public void OnGameStart() => controlButtonContainer.SetActive(true);
}
