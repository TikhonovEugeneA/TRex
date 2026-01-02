using UnityEngine;

public class TooltipsPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] private GameObject tooltipsContainer;

    public void OnGameStart() => tooltipsContainer.SetActive(false);
}
