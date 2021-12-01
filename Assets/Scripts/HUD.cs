using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textCoin;
    [SerializeField]
    TextMeshProUGUI textTimer;
    [SerializeField]
    GameObject panelMenu;
    public static float timerSec;
    public static int timerMin;
    AudioSource audioSource;
    public AudioClip AudioMenu;


    // Start is called before the first frame update
    void Start()
    {
        panelMenu.SetActive(false);
        timerSec = 00;
        timerMin = 00;
        audioSource = GetComponent<AudioSource>();
    }

    public void ActivePanelMenu()
    {
        panelMenu.SetActive(!panelMenu.activeSelf);

        if (panelMenu.activeSelf == true)
        {
            Time.timeScale = 00;
            audioSource.PlayOneShot(AudioMenu);
        }
        else
        {
            Time.timeScale = 01;
        }
    }

    // Update is called once per frame
    void Update()
    {
        textCoin.text = Player.Moedas.ToString();
        timerSec += Time.deltaTime;

        if (timerSec > 60)
        {
            timerSec = 0;
            timerMin += 1;
        }

        if (timerMin < 10)
        {
            if (timerSec < 10)
            {
                textTimer.text = "0" + timerMin + ":0" + (int)timerSec;
            }
            else
                textTimer.text = "0" + timerMin + ":" + (int)timerSec;
        }
        else
            textTimer.text = timerMin + ":" + (int)timerSec;
    }
}
