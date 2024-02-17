using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);
    }
}
