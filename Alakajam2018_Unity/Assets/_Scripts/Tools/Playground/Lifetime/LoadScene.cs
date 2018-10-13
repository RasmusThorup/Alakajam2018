using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void Reload()
    {
        Load(SceneManager.GetActiveScene().name);
    }
}