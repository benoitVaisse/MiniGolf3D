using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Pause")]

    private bool _pause = false;
    [SerializeField]
    private Sprite _pauseSprite;
    [SerializeField]
    private Sprite _lectureSprite;
    [SerializeField]
    private GameObject _pauseBlock;
    void Start()
    {
        _pauseBlock = _pauseBlock == null ? GameObject.Find("Canvas/PauseBlock") : _pauseBlock;
        if (_pauseBlock == null)
            throw new Exception($"Pas de panel de pause pour la scene {SceneManager.GetActiveScene().buildIndex}" );

        _pause = false;
        _pauseBlock.transform.Find("PauseButton").GetComponent<Image>().sprite = GetPauseSpriteButton(_pause);
        _pauseBlock.transform.Find("PausePanel").gameObject.SetActive(_pause);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }

    public void SetPause()
    {
        _pause = !_pause;
        SoundManager.Instance.PlayGameSound(GameSountConst.PAUSE);
        Time.timeScale = _pause ? 0.0f : 1.0f;
        _pauseBlock.transform.Find("PausePanel").gameObject.SetActive(_pause);
        _pauseBlock.transform.Find("PauseButton").GetComponent<Image>().sprite = GetPauseSpriteButton(_pause);

    }

    private Sprite GetPauseSpriteButton(bool isPaused)
    {
        return isPaused ? _lectureSprite : _pauseSprite;
    }
}
