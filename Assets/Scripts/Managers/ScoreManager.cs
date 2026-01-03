using System.Collections;
using UnityEngine;
using UnityEngine.Events;

 public class ScoreManager : MonoBehaviour
 {
     [Header("Settings")] 
     [SerializeField] private int addScorePerIteration;
     [SerializeField] private float iterationDelta;
     [SerializeField] private float minIterationDelta;
     [SerializeField] private float maxIterationDelta;
     [SerializeField] private float lessDeltaPerSecond;
     [SerializeField] private float nonLessDeltaTime;
     [Space] 
     [SerializeField] private int scoreCount;
     [SerializeField] private int highScoreCount;

     [SerializeField] private UnityEvent<int> scoreChanged;
     [SerializeField] private UnityEvent<int> highScoreChanged;
     
     private IEnumerator ScoreCounter()
     {
         while (true)
         {
            scoreCount += addScorePerIteration;
            scoreChanged?.Invoke(scoreCount);

             if (scoreCount > highScoreCount)
             {
                 highScoreCount = scoreCount;
                 highScoreChanged?.Invoke(highScoreCount);
             }

             yield return new WaitForSeconds(iterationDelta);
         }
     }

     private IEnumerator IterationDeltaCounter()
     {
         yield return new WaitForSeconds(nonLessDeltaTime);
         while (true)
         {
             iterationDelta -= lessDeltaPerSecond / 10;
             iterationDelta = Mathf.Clamp(iterationDelta, minIterationDelta, maxIterationDelta);

             yield return new WaitForSeconds(0.1f);
         }
     }

     public void OnGameStart()
     {
        StartCoroutine(ScoreCounter());
        StartCoroutine(IterationDeltaCounter());
     }
     
     public void OnPlayerDead()
     {
        StopAllCoroutines();
     }

     public void OnDataLoaded(GameData data)
     {
        highScoreCount = data.highScoreCount;
        highScoreChanged?.Invoke(highScoreCount);
     }
 }