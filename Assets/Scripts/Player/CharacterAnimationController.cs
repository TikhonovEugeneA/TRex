using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;

    [SerializeField] private CharacterMovementController characterMovement;

    private static readonly int GameStartTrigger = Animator.StringToHash("GameStart");
    private static readonly int JumpTrigger = Animator.StringToHash("Jump");
    private static readonly int IsGround = Animator.StringToHash("IsGround");
    private static readonly int IsCrouchRun = Animator.StringToHash("IsCrouchRun");
    private void Awake()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (characterMovement == null) characterMovement = GetComponent<CharacterMovementController>();
    }
    private void Update()
    {
        bool isGround = characterMovement.IsGround();
        SetIsGround(isGround);
    }
    public void SetJump() => animator.SetTrigger(JumpTrigger);

    public void SetGameStart() => animator.SetTrigger(GameStartTrigger);

    public void SetIsGround(bool value) => animator.SetBool(IsGround,value);

    public void SetCrouchRun(bool value) => animator.SetBool(IsCrouchRun,value);
}
