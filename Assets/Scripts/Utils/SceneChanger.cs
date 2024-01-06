using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChangeFunction(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
