using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public GameObject canvasOptionsPause;

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

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioSource audioSource;

    public GameObject touchControls; // Assign your touch button panel in the inspector

    void Start()
    {
        audioSource.PlayOneShot(menuMusic);
        canvasMainMenu.SetActive(true);
        canvasOptions.SetActive(false);
        canvasGame.SetActive(false);
        canvasPause.SetActive(false);
        canvasWin.SetActive(false);
        canvasLose.SetActive(false);
        canvasOptionsPause.SetActive(false);
        estaJugando = false;
        Time.timeScale = 0f;
        mainCamera.SetActive(false);

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

        if (Application.platform == RuntimePlatform.Android)
        {
            touchControls.SetActive(true); // Show touch controls on Android
        }
        else
        {
            touchControls.SetActive(false); // Hide touch controls on other platforms
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
        audioSource.Stop();
        audioSource.PlayOneShot(gameMusic);
        canvasMainMenu.SetActive(false);
        canvasOptions.SetActive(false);
        canvasGame.SetActive(true);
        canvasPause.SetActive(false);
        estaJugando = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        mainCamera.SetActive(true);
    }

    public void ButtonOptions()
    {
        canvasOptions.SetActive(true);
        LeanTween.moveLocalX(canvasMainMenu, -1920f, 1f).setOnComplete(() =>
        {
            canvasMainMenu.SetActive(false);
        });
        LeanTween.moveLocalX(canvasOptions, -1920f, 1f);
        canvasMainMenu.SetActive(false);
        canvasLose.SetActive(false);
        canvasWin.SetActive(false);
        estaJugando = false;
    }

    public void ButtonOptionsPause()
    {
        canvasPause.SetActive(false);
        canvasOptionsPause.SetActive(true);
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
        canvasOptions.SetActive(false);
        LeanTween.moveLocalX(canvasOptions, 0f, 1f).setOnComplete(() =>
        {
            canvasOptions.SetActive(false);
        });
        LeanTween.moveLocalX(canvasMainMenu, 0f, 1f);
        estaJugando = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ButtonReturnOpitonsPause()
    {
        canvasPause.SetActive(true);
        canvasOptionsPause.SetActive(false);
    }

    public void ButtonExit()
    {
        Application.Quit();
        Debug.Log("Salir");
        estaJugando = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PauseGame()
    {
        if (estaJugando && Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.Stop();
            audioSource.PlayOneShot(menuMusic);
            canvasPause.SetActive(true);
            estaJugando = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            mainCamera.SetActive(false);
        }
        else if (canvasGame == true && Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonStart();
        }
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        canvasLose.SetActive(true);
        canvasGame.SetActive(false);
        estaJugando = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        EndGame();
        canvasLose.SetActive(false);
        canvasWin.SetActive(true);
    }
}
