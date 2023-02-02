using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LobbyCanvasManager : MonoBehaviour
{
    public float loadTimePeriod = 10f;
    public float loadTimerCount = 0f;
    public bool loadTimeMark = true;
    public Slider loadSlider;
    public float load_MaxVolume;
    public GameObject loadAnime;
    public GameObject startButton;

    void Start()
    {
        loadSlider.maxValue = load_MaxVolume;
        loadSlider.value = 0;
        loadAnime.SetActive(true);
        startButton.SetActive(false);
    }

    void Update()
    {
        if(loadSlider.value >= loadSlider.maxValue)
        {
            loadAnime.SetActive(false);
            startButton.SetActive(true);
            loadTimeMark = false;
        }

        if (loadTimeMark)
        {
            if (CheckIfLoadCountDownElapsed(loadTimePeriod))
            {
                RessetTimeCount();
            }
        }
    }

    public bool CheckIfLoadCountDownElapsed(float duration)
    {
        loadTimerCount += Time.deltaTime;
        return (loadTimerCount >= duration);
    }

    private void RessetTimeCount()
    {
        LoadPeriodChecker();
        loadTimerCount = 0f;
    }

    private void LoadPeriodChecker()
    {

        var curTimeValue = Random.Range(10, 20);
        loadSlider.value += curTimeValue;

    }


}
