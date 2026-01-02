using System.Collections;
using UnityEngine;

public class MapMover : MonoBehaviour
{
    [Header("Settings")] 
    [Tooltip("Minimum moving speed.")]
    [SerializeField] private float minSpeed;
    
    [Tooltip("Maximum moving speed.")]
    [SerializeField] private float maxSpeed;    
    [Tooltip("Current speed.")]
    [SerializeField] private float speed;
        
    [Tooltip("Boost moving speed per second.")]
    [SerializeField] private float boostSpeedPerSecond;

    [SerializeField] private float nonBoostSpeedTime;
        
    [SerializeField] private bool isPLay;

    private void Update()
    {
        if (isPLay)
        {
            Vector3 position = transform.position;
            position = Vector3.Lerp(position, position + Vector3.left, Time.deltaTime * this.speed);
            transform.position = position;
        }
    }

    private IEnumerator SpeedCounter()
    {
        yield return new WaitForSeconds(nonBoostSpeedTime);
    
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            speed += boostSpeedPerSecond / 10;

            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        }
    }

    public void OnGameStart()
    {
        StartCoroutine(SpeedCounter());
        isPLay = true;
    }

    public void OnPause() => isPLay = false;
        
    public void OnContinue() => isPLay = true;
    }
