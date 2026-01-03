using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HighScoreSoundController : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private AudioSource audioSource;

    [Header("Settings")] 
    [SerializeField] private AudioClip highScoreChangedSounds;
    [SerializeField] private bool isSoundPayed;
    
    private void Awake()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }
    
    public void OnHighScoreChanged(int highScore)
    {
        if (isSoundPayed == false)
        {
            isSoundPayed = true;
            audioSource.PlayOneShot(highScoreChangedSounds);
        }
    }
}
