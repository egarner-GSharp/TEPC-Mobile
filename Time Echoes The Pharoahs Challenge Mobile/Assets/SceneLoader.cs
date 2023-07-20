using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // This is the public variable you can set in the Unity Inspector.
    public int sceneNumber;

    void Start()
    {
        // Use the public variable to load the scene.
        // LoadSceneByNumber(sceneNumber);
    }

    public void LoadSceneByNumber(int sceneNumber)
    {
        // Check if the scene index is valid.
        if (sceneNumber >= 0 && sceneNumber < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneNumber);
        }
        else
        {
            Debug.LogError("Scene " + sceneNumber + " does not exist. Please check your Build Settings.");
        }
    }
}
