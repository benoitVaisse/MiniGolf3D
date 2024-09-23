using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class LevelManager : MonoBehaviour
{
    private static LevelManager _instance { get; set; }
    public static LevelManager Instance { get { return _instance;} }

    private const string SCORE_TEXT_BASE = "Score : {score}";

    private bool _pause = false;

    [Header("scoring")]
    public float Score = 0;
    public int NbrShoot = 0;
    [SerializeField]
    private GameObject _panelFinishLevel;
    [SerializeField]
    private GameObject _canvas;

    private void Awake()
    {
        _instance = this;
        
    }
    private void Start()
    {
        _panelFinishLevel = _panelFinishLevel == null ? GameObject.Find("FinishLevelPanel") : _panelFinishLevel;
        _canvas = _canvas == null ? GameObject.Find("Canvas") : _canvas;
        if(_panelFinishLevel != null)
        {
            _panelFinishLevel.SetActive(false);
        }

        ShowScore(Score);
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

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    #region Scoring
    private void FinishLevel()
    {
        if(_panelFinishLevel != null)
        {
            _panelFinishLevel.SetActive(true);
            GameObject text = _panelFinishLevel.transform.Find("TextFinishLevel").gameObject;
            text.GetComponent<TMP_Text>().SetText($"Vous avez fini le niveau en {NbrShoot} coup !!!");
        }
    }

    public void ShowPanelEndingLevel()
    {
        FinishLevel();
        ShowScore(CalculateScore());
    }

    private void ShowScore(float score)
    {
        if (_canvas.transform.Find("Scoring/ScoreText") is Transform transform && transform.GetComponent<TMP_Text>() is TMP_Text text)
        {
            text.SetText(SCORE_TEXT_BASE.Replace("{score}", score.ToString()));
        }
    }

    public float CalculateScore()
    {
        int scoreBase = 10 - NbrShoot;
        if(scoreBase < 0) scoreBase = 0;
        Score += (100f * scoreBase);
        return Score;
    }
    #endregion
}
