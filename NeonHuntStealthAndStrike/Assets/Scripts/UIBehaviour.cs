using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField]
    public GameObject canvasMainMenu;
    [SerializeField]
    public GameObject canvasOptions;

    [SerializeField]
    Slider slideVolume;
    [SerializeField]
    Toggle toggleCompleteScreen;

    void Start()
    {
        canvasMainMenu.SetActive(true);
        canvasOptions.SetActive(false);
    }
    public void ButtonStart()
    {
        canvasMainMenu.SetActive(false);
        canvasOptions.SetActive(false);
    }

    public void ButtonOptions()
    {
        canvasOptions.SetActive(true);
        LeanTween.moveLocalX(canvasMainMenu, -1920f, 1f).setOnComplete(() =>
        {
            canvasMainMenu.SetActive(false);
        });
        LeanTween.moveLocalX(canvasOptions, -1920f, 1f);
    }

    public void ButtonReturn()
    {
        canvasMainMenu.SetActive(true);
        LeanTween.moveLocalX(canvasOptions, 0f, 1f).setOnComplete(() =>
        {
            canvasOptions.SetActive(false);
        });
        LeanTween.moveLocalX(canvasMainMenu, 0f, 1f);
    }

    public void ButtonExit()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
