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

    /*using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenScript : MonoBehaviour
{

    [SerializeField]
    GameObject pantallaI;
    [SerializeField]
    public GameObject pantallaG;
    [SerializeField]
    GameObject pantallaP;
    [SerializeField]
    GameObject pantallaO;
    [SerializeField]
    LeanTweenType animCurve;
    [SerializeField]
    GameObject pantallaInfo;
    [SerializeField]
    GameObject canvasJuego;
    [SerializeField]
    GameObject canvasPausa;

    [SerializeField]
    MovimientoJugador movimientoJugador;
    [SerializeField]
    MovimientoPelota movimientoPelota;

    [SerializeField]
    Slider slideVolume;
    [SerializeField]
    float valueVolume;
    [SerializeField]
    Image imagenMuteO;
    [SerializeField]
    Image imagenMuteJ;

    [SerializeField]
    Slider slideBrillo;
    [SerializeField]
    float valueBrillo;
    [SerializeField]
    Image imagenBrillo;

    [SerializeField]
    Toggle pantallaCompleta;

    [SerializeField]
    TMP_Dropdown resolutionDropdown;
    Resolution[] resoluciones;

    [SerializeField]
    GameObject pantallaNewG;

    bool estaJugando;

    //float tiempoSinFuncionar = 0f;
    void Start()
    {
        estaJugando = false;
        pantallaI.SetActive(true);
        pantallaG.SetActive(false);
        pantallaP.SetActive(false);
        pantallaO.SetActive(false);
        pantallaInfo.SetActive(false);
        movimientoJugador.enabled = false;
        movimientoPelota.enabled = false;
        canvasJuego.SetActive(false);
        canvasPausa.SetActive(false);
        pantallaNewG.SetActive(false);
        slideVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slideVolume.value;
        Mute();
        slideBrillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        imagenBrillo.color = new Color(imagenBrillo.color.r, imagenBrillo.color.g, imagenBrillo.color.b, slideBrillo.value);
        if (Screen.fullScreen)
        {
            pantallaCompleta.isOn = true;
        }
        else
        {
            pantallaCompleta.isOn = false;
        }
        RevisarResolucion();
    }

    // Update is called once per frame
    void Update()
    {
        if (estaJugando & Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPausa.SetActive(true);
            movimientoJugador.enabled = false;
            movimientoPelota.enabled = false;
            FindObjectOfType<MovimientoPelota>().pelotaRb.velocity = Vector3.zero;
        }   
    }

    public void Continuar()
    {
        estaJugando = true;
        canvasPausa.SetActive(false);
        FindObjectOfType<MovimientoPelota>().pelotaRb.velocity = FindObjectOfType<MovimientoPelota>().transform.position;
        movimientoJugador.enabled = true;
        movimientoPelota.enabled = true;
    }

    public void StartButton()
    {
        estaJugando = false;
        pantallaI.SetActive(false);
        pantallaInfo.SetActive(true);
        canvasJuego.SetActive(true);
        LeanTween.scale(pantallaInfo, Vector3.one * 0.9f, 0.5f).setEase(animCurve).setOnComplete(() =>
        {
            LeanTween.scale(pantallaInfo, Vector3.one * 1f, 0.5f);
        });
    }

    public void ListoButton()
    {
        pantallaInfo.SetActive(false);
        estaJugando = true;
        //tiempoSinFuncionar += Time.deltaTime;
        //if (tiempoSinFuncionar>=5.0f)
        //{
            movimientoJugador.enabled = true;
            movimientoPelota.enabled=true;
        
        //}
    }

    public void OptionButton()
    {
        estaJugando = false;
        LeanTween.moveLocalX(pantallaI, -1920f, 1f).setOnComplete(() =>
        {
            pantallaI.SetActive(false);
        });
        pantallaO.SetActive(true);
        LeanTween.moveLocalX(pantallaO, 0, 1f);
    }

    //los dos siguientes void son para controlar el volumen
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
            imagenMuteO.enabled = true;
            imagenMuteJ.enabled = true;
        }
        else
        {
            imagenMuteO.enabled = false;
            imagenMuteJ.enabled = false;
        }
    }

    public void BrilloSlide (float valor)
    {
        valueBrillo = valor;
        PlayerPrefs.SetFloat("brillo", valueBrillo);
        imagenBrillo.color = new Color(imagenBrillo.color.r, imagenBrillo.color.g, imagenBrillo.color.b, slideBrillo.value);
    }
    
    public void ActivarPantallaCompleta (bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i< resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }
        resolutionDropdown.AddOptions(opciones);
        resolutionDropdown.value = resolucionActual;
        resolutionDropdown.RefreshShownValue();
    }

    public void CambiarResolucion (int indiceResolucion)
    {
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }

    public void ReturnButton()
    {
        LeanTween.moveLocalX(pantallaO, 1920, 1f).setOnComplete(() =>
        {
            pantallaO.SetActive(false);
        });
        pantallaInfo.SetActive(false);
        pantallaI.SetActive(true);
        
        LeanTween.moveLocalX(pantallaI, 0, 1f);
        //movimientoPelota.Update().tiempoPartida = 0.00f;
    }

    public void SalirButton()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void PantallaDeInicioButton()
    {
        estaJugando = false;
        canvasPausa.SetActive(false);
        pantallaG.SetActive(false);
        pantallaP.SetActive(false);
        canvasJuego.SetActive(false);
        pantallaI.SetActive(false);
        pantallaNewG.SetActive(true);
        //FindObjectOfType<MovimientoPelota>().tiempoPartida = 0;

    }
    public void ReintentarButton()
    {
        estaJugando = false;
        pantallaG.SetActive(false);
        pantallaP.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pantallaI.SetActive(false);
    }

    public void NuevoJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<Bloques>().GenerarMapa();
    }
}

*/
}
