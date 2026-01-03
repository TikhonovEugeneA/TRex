using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void OnRestartLevel()=>SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
