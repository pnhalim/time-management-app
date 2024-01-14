using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("CurrentActivity"))
        {
            SceneManager.LoadScene("Activity");
        }
        Application.targetFrameRate = 60;
    }

    public void OnResetButtonPressed()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Home");
    }
}
