using UnityEngine;

public class RestartTooltipsPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] private GameObject restartToolTipsContainer;

    public void OnPlayerDead() => restartToolTipsContainer.SetActive(true);
}
