using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private bool isGameStarted;
    [Space]
    [SerializeField] private UnityEvent gameStart;
    [SerializeField] private UnityEvent jumpButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonDown;
    [SerializeField] private UnityEvent crouchRunButtonUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPlayButtonDown();
            OnJumpButtonDown();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) OnCrouchRunButtonDown();

        if (Input.GetKeyUp(KeyCode.DownArrow)) OnCrouchRunButtonUp();
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
