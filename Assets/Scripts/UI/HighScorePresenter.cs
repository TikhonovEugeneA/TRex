using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScorePresenter : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Text _highScoreText;

    [Header("Settings")] 
    [SerializeField] private string _prefix;
    
    private void Awake()
    {
        if (_highScoreText == null) _highScoreText = GetComponent<Text>();
    }
    
    public void OnHighScoreChanged(int highScore) => _highScoreText.text = $"{_prefix}" + highScore.ToString("0000");

}
