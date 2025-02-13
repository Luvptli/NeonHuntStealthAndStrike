using System.Collections;
using System.Collections.Generic;
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
    float valueVolume;
    [SerializeField]
    Slider slideVolume;
    [SerializeField]
    Image imageMuteO;

    [SerializeField]
    Toggle toggleCompleteScreen;

    [SerializeField]
    public GameObject player;

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

        player.SetActive(false);
        //deshabilitar thirdPersonController hasta que le des al boton start

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
    }
    public void ButtonStart()
    {
        canvasMainMenu.SetActive(false);
        canvasOptions.SetActive(false);
        estaJugando = true;
        canvasGame.SetActive(true);
        player.SetActive(true);
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
            canvasGame.SetActive(false);
            estaJugando = false;
        }
        else if (estaJugando == false && canvasPause == true && Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPause.SetActive(false);
            canvasGame.SetActive(true);
        }
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
