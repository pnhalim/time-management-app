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
    }

    public void OnResetButtonPressed()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Home");
    }
}
