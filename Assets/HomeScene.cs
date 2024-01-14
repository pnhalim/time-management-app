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
}
