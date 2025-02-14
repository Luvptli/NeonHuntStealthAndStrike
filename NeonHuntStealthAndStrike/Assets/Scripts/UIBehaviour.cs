using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField]
    public GameObject canvasMainMenu;
    [SerializeField]
    public GameObject canvasOptions;
    [SerializeField]
    public GameObject canvasGame;
    [SerializeField]
    public GameObject canvasPause;
    [SerializeField]
    public GameObject canvasWin;
    [SerializeField]
    public GameObject canvasLose;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public GameObject mainCamera;

    [SerializeField]
    float valueVolume;
    [SerializeField]
    Slider slideVolume;
    [SerializeField]
    Image imageMuteO;

    [SerializeField]
    Toggle toggleCompleteScreen;

    public bool estaJugando;

    void Start()
    {
        canvasMainMenu.SetActive(true);
        canvasOptions.SetActive(false);
        canvasGame.SetActive(false);
        canvasPause.SetActive(false);
        canvasWin.SetActive(false);
        canvasLose.SetActive(false);
        estaJugando = false;

        slideVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slideVolume.value;
        Mute();

        if (Screen.fullScreen)
        {
            toggleCompleteScreen.isOn = true;
        }
        else
        {
            toggleCompleteScreen.isOn = false;
        }
    }

    void Update()
    {
        slideVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slideVolume.value;
        Mute();
        PauseGame();
        if (Input.GetKeyDown(KeyCode.Space))
        { ButtonStart(); }
    }
    public void ButtonStart()
    {
        canvasMainMenu.SetActive(false);
        canvasOptions.SetActive(false);
        canvasGame.SetActive(true);
        estaJugando = true;
    }

    public void ButtonOptions()
    {
        canvasOptions.SetActive(true);
        LeanTween.moveLocalX(canvasMainMenu, -1920f, 1f).setOnComplete(() =>
        {
            canvasMainMenu.SetActive(false);
        });
        LeanTween.moveLocalX(canvasOptions, -1920f, 1f);
        estaJugando = false;
    }

    public void VolumenSlide(float valor)
    {
        estaJugando = false;
        valueVolume = valor;
        PlayerPrefs.SetFloat("volumenAudio", valueVolume);
        AudioListener.volume = valueVolume;
        Mute();
    }

    public void Mute()
    {
        if (valueVolume == 0)
        {
            imageMuteO.enabled = true;
        }
        else
        {
            imageMuteO.enabled = false;
        }
    }

    public void ActivarPantallaCompleta(bool toggleCompleteScreen)
    {
        Screen.fullScreen = toggleCompleteScreen;
    }

    public void ButtonReturn()
    {
        canvasMainMenu.SetActive(true);
        LeanTween.moveLocalX(canvasOptions, 0f, 1f).setOnComplete(() =>
        {
            canvasOptions.SetActive(false);
        });
        LeanTween.moveLocalX(canvasMainMenu, 0f, 1f);
        estaJugando = false;
    }

    public void ButtonExit()
    {
        Application.Quit();
        Debug.Log("Salir");
        estaJugando = false;
    }

    public void PauseGame()
    {
        if (estaJugando && Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPause.SetActive(true);
            player.SetActive(false);
            estaJugando = false;
        }
        else if (estaJugando == false && canvasPause == true && Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPause.SetActive(false);
            estaJugando= true;
        }
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ButtonContinue()
    {
        canvasPause.SetActive(false);
        canvasGame.SetActive(true);
    }
}
