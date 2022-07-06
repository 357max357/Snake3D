using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelLose;

    public void Win()
    {
        _panelWin.SetActive(true);
        Time.timeScale = 0;
    }

    public void Lose()
    {
        _panelLose.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToTheMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
