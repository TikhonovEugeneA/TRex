using UnityEngine;

public class RestartButtonPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] private GameObject restartButton;

    public void OnPlayerDead() => restartButton.SetActive(true);
}
