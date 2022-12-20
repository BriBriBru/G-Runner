using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{    
    public void GoToGame()
    {
        SceneManager.LoadScene("Runner");
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
