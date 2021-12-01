using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Iniciar : MonoBehaviour
{
    public GameObject canvas;
    public GameObject panelPrincipal;
    public GameObject panelSelect;
    public GameObject panelSobre;
    public AudioSource audioSource;
    public AudioClip AudioInterface;
    public TextMeshProUGUI BestTimeL1, BestTimeL2;
    int bestMin1, bestSec1;
    int bestMin2, bestSec2;

    // Start is called before the first frame update
    void Start()
    {
        panelSelect.SetActive(false);
        panelSobre.SetActive(false);
        SetTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarJogo()
    {
        audioSource.PlayOneShot(AudioInterface);
        SceneManager.LoadScene(1);
        canvas.GetComponent<HUD>().ActivePanelMenu();
        Time.timeScale = 01;
    }

    public void Principal()
    {
        audioSource.PlayOneShot(AudioInterface);
        panelPrincipal.SetActive(true);
        panelSelect.SetActive(false);
        panelSobre.SetActive(false);
    }

    public void Select()
    {
        audioSource.PlayOneShot(AudioInterface);
        panelSelect.SetActive(true);
        panelSobre.SetActive(false);
    }

    public void Level1()
    {
        audioSource.PlayOneShot(AudioInterface);
        SceneManager.LoadScene(1);
        canvas.GetComponent<HUD>().ActivePanelMenu();
        Time.timeScale = 01;
    }

    public void Level2()
    {
        audioSource.PlayOneShot(AudioInterface);
        SceneManager.LoadScene(2);
        canvas.GetComponent<HUD>().ActivePanelMenu();
        Time.timeScale = 01;
    }

    public void Sobre()
    {
        audioSource.PlayOneShot(AudioInterface);
        panelSelect.SetActive(false);
        panelSobre.SetActive(true);       
    }

    public void Sair()
    {
        audioSource.PlayOneShot(AudioInterface);
        Application.Quit();
    }

    public void VoltarMenu()
    {
        audioSource.PlayOneShot(AudioInterface);
        SceneManager.LoadScene(0);
    }

    public void SetTime()
    {
        float bestTime1 = PlayerPrefs.GetFloat("bestTimeLvl1");
        float bestTime2 = PlayerPrefs.GetFloat("bestTimeLvl2");

        var ss1= Convert.ToInt32(bestTime1 % 60).ToString("00");
        var mm1 = (Math.Floor(bestTime1 / 60) % 60).ToString("00");

        var ss2 = Convert.ToInt32(bestTime2 % 60).ToString("00");
        var mm2 = (Math.Floor(bestTime2 / 60) % 60).ToString("00");

        BestTimeL1.text = "Melhor tempo:\n" + mm1 + ":" + ss1;
        BestTimeL2.text = "Melhor tempo:\n" + mm2 + ":" + ss2;
    }
}
