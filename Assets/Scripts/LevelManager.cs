using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LevelManager : MonoBehaviour
{
    private static LevelManager _instance { get; set; }
    public static LevelManager Instance { get { return _instance;} }

    private bool _pause = false;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pause = !_pause;
            SoundManager.Instance.PlayGameSound(GameSountConst.PAUSE);
            Time.timeScale = _pause? 1.0f : 0.0f;
        }
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
