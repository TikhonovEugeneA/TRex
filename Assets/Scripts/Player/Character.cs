using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CharacterMovementController))]
[RequireComponent(typeof(CharacterAnimationController))]
[RequireComponent(typeof(CharacterSoundController))]
public class Character : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterAnimationController characterAnimation;
    [SerializeField] private CharacterMovementController characterMovement;
    [SerializeField] private CharacterSoundController characterSound;

    [SerializeField] private UnityEvent jump;
    [SerializeField] private UnityEvent dead;
    [SerializeField] private UnityEvent crouchRunStart;
    [SerializeField] private UnityEvent crouchRunEnd;

    private void Awake()
    {
        if (characterAnimation == null) characterAnimation = GetComponent<CharacterAnimationController>();
        if (characterMovement == null) characterMovement = GetComponent<CharacterMovementController>();
        if (characterSound == null) characterSound = GetComponent<CharacterSoundController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                characterSound.PlayDeadSound();
                dead?.Invoke();
                break;
        }
    }

    public void OnJumpButtonDown()
    {
        bool isGround = characterMovement.IsGround();
        if (isGround)
        {
            characterMovement.Jump();
            characterAnimation.SetJump();
            characterSound.PlayJumpSound();
            jump?.Invoke();
        }
    }

    public void OnCrouchRunButtonDown()
    {
        bool isGround = characterMovement.IsGround();
        if (isGround)
        {
            characterAnimation.SetCrouchRun(true);
            crouchRunEnd?.Invoke();
        }
    }

    public void OnCrouchRunButtonUp()
    {
        bool isGround = characterMovement.IsGround();
        if (isGround)
        {
            characterAnimation.SetCrouchRun(false);
            crouchRunEnd?.Invoke();
        }
    }

    public void OnGameStart()
    {
       characterAnimation.SetGameStart(); 
    }
}
