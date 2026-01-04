using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private bool isGameStarted;
    [SerializeField] private bool isPlayerDead;
    [Space]
    [SerializeField] private UnityEvent gameStart;
    [SerializeField] private UnityEvent restartLevel;
    [SerializeField] private UnityEvent jumpButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnPlayButtonDown();
            OnJumpButtonDown();
            OnRestartLevelButtonDown();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) OnCrouchRunButtonDown();

        if (Input.GetKeyUp(KeyCode.DownArrow)) OnCrouchRunButtonUp();
    }

    public void OnPlayerDead() => isPlayerDead = true;

    public void OnRestartLevelButtonDown()
    {
        if(isPlayerDead == true)
        {
            restartLevel?.Invoke();
        }
    }
    public void OnPlayButtonDown()
    {
        if(isGameStarted == false)
        {
            isGameStarted = true;
            gameStart?.Invoke();
            Debug.Log("Game started");
        }
    }

    public void OnJumpButtonDown()
    {
        jumpButtonDown?.Invoke();
        Debug.Log("Pressed button jump");
    }

    public void OnCrouchRunButtonDown()
    {
        crouchRunButtonDown?.Invoke();
        Debug.Log("Pressed button crouch run");
    }

    public void OnCrouchRunButtonUp()
    {
        crouchRunButtonUp?.Invoke();
        Debug.Log("Letted button crouch run");
    }
}
