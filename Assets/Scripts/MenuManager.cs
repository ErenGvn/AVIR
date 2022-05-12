using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    [SerializeField] private GameObject startpanel;
    [SerializeField] private GameObject gamepanel;
    [SerializeField] private GameObject stagepanel;

    public void Play()
    {
        startpanel.SetActive(false);
        gamepanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartStory(string stagename)
    {
        SceneManager.LoadScene(stagename);
    }

    public void StartSingleBattle()
    {
        gamepanel.SetActive(false);
        stagepanel.SetActive(true);

    }

    public void SelectStage(string stagename)
    {
        SceneManager.LoadScene(stagename);
    }


    public void Back()
    {
        startpanel.SetActive(true);
        gamepanel.SetActive(false);
    }

    public void BackFromSelection()
    {
        stagepanel.SetActive(false);
        gamepanel.SetActive(true);

    }











}
