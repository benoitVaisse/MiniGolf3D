using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class LevelManager : MonoBehaviour
{
    private static LevelManager _instance { get; set; }
    public static LevelManager Instance { get { return _instance;} }

    public const string LAST_LEVEL_UNLOCK_KEY = "LastLevelUnlock";

    private const string SCORE_TEXT_BASE = "Score : {score}";


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
        Time.timeScale = 1.0f;
        _panelFinishLevel = _panelFinishLevel == null ? GameObject.Find("FinishLevelPanel") : _panelFinishLevel;
        _canvas = _canvas == null ? GameObject.Find("Canvas") : _canvas;
        if(_panelFinishLevel != null)
        {
            _panelFinishLevel.SetActive(false);
        }

        ShowScore(Score);
        InitializeLevelChoice();
    }

    private void Update()
    {
    }
    #region Scene
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
        int levelUnlocked = SceneManager.GetActiveScene().buildIndex + 1;
        SetLastLevelUnlock(levelUnlocked);
        SceneManager.LoadScene(levelUnlocked);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey(LAST_LEVEL_UNLOCK_KEY);
        LoadScene(PlayerPrefs.GetInt(LAST_LEVEL_UNLOCK_KEY, 1));
    }

    public void ContinueGame()
    {
        LoadScene(PlayerPrefs.GetInt(LAST_LEVEL_UNLOCK_KEY, 1));
    }

    public void SetLastLevelUnlock(int levelUnlocked)
    {
        PlayerPrefs.SetInt(LAST_LEVEL_UNLOCK_KEY, levelUnlocked);
    }

    private void InitializeLevelChoice()
    {
        int lastLevelUnlocked = PlayerPrefs.GetInt(LAST_LEVEL_UNLOCK_KEY, 1);
        GameObject allLevelParent = GameObject.Find("allLevel");
        if (allLevelParent != null)
        {
            foreach (Transform go in allLevelParent.transform)
            {
                go.GetComponent<Button>().interactable = int.Parse(go.name) <= lastLevelUnlocked;
            }
        }
    }

    #endregion Scene

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
        if (_canvas != null && _canvas.transform.Find("Scoring/ScoreText") is Transform transform && transform.GetComponent<TMP_Text>() is TMP_Text text)
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
