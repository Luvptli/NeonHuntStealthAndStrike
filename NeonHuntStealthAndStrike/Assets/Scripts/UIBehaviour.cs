using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField]
    public GameObject canvasMainMenu;
    [SerializeField]
    public GameObject canvasOptions;

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
    }

    public void ButtonExit()
    {
        
    }
}
