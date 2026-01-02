using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovementController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float detectGroundRayLenght;

    [Header("Development settings")]
    [SerializeField] private bool showDetectGroundRay;
    private void Awake()
    {
       if(rb==null) rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (showDetectGroundRay)
        {
            Debug.DrawRay(transform.position,Vector3.down * detectGroundRayLenght, Color.red);
        }
    }

    public bool IsGround()
    {
        int groundLayerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down, detectGroundRayLenght,groundLayerMask);
        return hit.collider;
    }

    public void Jump() => rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    
}
