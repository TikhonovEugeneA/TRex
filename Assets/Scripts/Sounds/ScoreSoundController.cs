using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScoreSoundController : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private AudioSource audioSource;

    [Header("Settings")] 
    [SerializeField] private AudioClip scoreEven100Sound;
    [SerializeField] private AudioClip scoreEven250Sound;
    [SerializeField] private AudioClip scoreEven500Sound;
    
    private void Awake()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }
    
    private bool IsEvenNumber(int value, int number) => value % number == 0;
    
    public void OnScoreChanged(int score)
    {
        if (IsEvenNumber(score, 500)) audioSource.PlayOneShot(scoreEven500Sound);
        else if(IsEvenNumber(score, 250)) audioSource.PlayOneShot(scoreEven250Sound);
        else if(IsEvenNumber(score, 100)) audioSource.PlayOneShot(scoreEven100Sound);
    }
}
