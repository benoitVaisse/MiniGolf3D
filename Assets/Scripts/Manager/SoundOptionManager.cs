using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundOptionManager : MonoBehaviour
{
    private const string VOLUME_BACKGROUND_MUSIC_TEXT = "Volume de la musique";
    private const string VOLUME_BACKGROUND_MUSIC_OPTION_KEY = "backgroudMusicVolume";

    [Header("OptionSound")]
    [SerializeField]
    private GameObject _panelSoundOption;
    [SerializeField]
    private AudioSource _backgroundSound;
    [SerializeField]
    private GameObject _soundManagerObject;


    // Start is called before the first frame update
    void Start()
    {

        _soundManagerObject = GameObject.FindGameObjectsWithTag("SoundManager").FirstOrDefault();
        _backgroundSound = _soundManagerObject.transform.Find("BackGroundSound").GetComponent<AudioSource>();
        _panelSoundOption = gameObject;
        InitializeBackgroundVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBackgroundMusicVolume()
    {
        if (_panelSoundOption != null &&
            _panelSoundOption.transform.Find("SliderVolumeMusique") is Transform transformSlider &&
            transformSlider.GetComponent<Slider>() is Slider slider &&
            _panelSoundOption.transform.Find("VolumeMusique") is Transform transformText &&
            transformText.GetComponent<TMP_Text>() is TMP_Text text
        )
        {
            float volume = slider.value;
            _backgroundSound.volume = volume;
            text.SetText($"{VOLUME_BACKGROUND_MUSIC_TEXT} {Math.Ceiling(volume * 100)}%");
            SaveValueBackGroupVolume(volume);
        }
    }

    private void InitializeBackgroundVolume()
    {
        float volume = PlayerPrefs.GetFloat(VOLUME_BACKGROUND_MUSIC_OPTION_KEY, 0.5f);
        TMP_Text text = _panelSoundOption.transform.Find("VolumeMusique").GetComponent<TMP_Text>();
        Slider slider = _panelSoundOption.transform.Find("SliderVolumeMusique").GetComponent<Slider>();
        slider.value = volume;
        _backgroundSound.volume = volume;
        text.SetText($"{VOLUME_BACKGROUND_MUSIC_TEXT} {Math.Ceiling(volume * 100)}%");
    }

    private void SaveValueBackGroupVolume(float value)
    {
        PlayerPrefs.SetFloat(VOLUME_BACKGROUND_MUSIC_OPTION_KEY, value);
    }
}
