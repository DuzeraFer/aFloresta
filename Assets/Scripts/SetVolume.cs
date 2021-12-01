using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetVolume : MonoBehaviour
{
    public Toggle mudo;
    public Slider volume;

    int ActualScene;
    float time1, time2;

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        volume.value = AudioListener.volume;

        ActualScene = SceneManager.GetActiveScene().buildIndex;

        if (PlayerPrefs.GetInt("Mudo") == 1)
        {
            mudo.isOn = true;
            AudioListener.pause = true;
        }
            
        else if (PlayerPrefs.GetInt("Mudo") == 0)
        {
            mudo.isOn = false;
            AudioListener.pause = false;
        }            
    }

    void Update()
    {
        if (ActualScene == 1)
        {
            time1 += Time.deltaTime;
            PlayerPrefs.SetFloat("lastTimeLvl1", time1);
        }
        if (ActualScene == 2)
        {
            time2 += Time.deltaTime;
            PlayerPrefs.SetFloat("lastTimeLvl2", time2);
        }
    }

    public void ValueChangeCheck()
    {
        PlayerPrefs.SetFloat("Volume", volume.value);
    }
    public void ValueChangeCheckMudo()
    {
        PlayerPrefs.SetInt("Mudo", mudo.isOn ? 1 : 0);

        if (PlayerPrefs.GetInt("Mudo") == 1)
        {
            mudo.isOn = true;
            AudioListener.pause = true;
        }

        else if (PlayerPrefs.GetInt("Mudo") == 0)
        {
            mudo.isOn = false;
            AudioListener.pause = false;
        }

    }

    public void SetBestTime()
    {
        if (PlayerPrefs.GetFloat("lastTimeLvl1") < PlayerPrefs.GetFloat("bestTimeLvl1") && PlayerPrefs.GetFloat("lastTimeLvl1") != 0 || PlayerPrefs.GetFloat("bestTimeLvl1") == 0 && PlayerPrefs.GetFloat("lastTimeLvl1") != 0)
            PlayerPrefs.SetFloat("bestTimeLvl1", PlayerPrefs.GetFloat("lastTimeLvl1")); 

        if (PlayerPrefs.GetFloat("lastTimeLvl2") < PlayerPrefs.GetFloat("bestTimeLvl2") && PlayerPrefs.GetFloat("lastTimeLvl2") != 0 || PlayerPrefs.GetFloat("bestTimeLvl2") == 0 && PlayerPrefs.GetFloat("lastTimeLvl2") != 0)
            PlayerPrefs.SetFloat("bestTimeLvl2", PlayerPrefs.GetFloat("lastTimeLvl2"));
    }
}
