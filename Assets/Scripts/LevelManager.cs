using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LevelManager : MonoBehaviour
{
    private static LevelManager _instance { get; set; }
    public static LevelManager Instance { get { return _instance;} }

    private void Awake()
    {
        _instance = this;
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
