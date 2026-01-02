using UnityEngine;

public class PlayButtonPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] private GameObject playButton;

    public void OnGameStart() => playButton.SetActive(false);
}
