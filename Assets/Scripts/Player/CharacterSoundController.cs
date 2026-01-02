using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterSoundController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource audioSource;

    [Header("Settings")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deadSound;

    private void Awake()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound() => audioSource.PlayOneShot(jumpSound);

    public void PlayDeadSound() => audioSource.PlayOneShot(deadSound);
}
