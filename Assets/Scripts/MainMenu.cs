using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public Button start;
    public Button about;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(StartGame);
        about.onClick.AddListener(ToggleAbout);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ToggleAbout()
    {
        if (!panel.active)
            panel.SetActive(true);
        else
            panel.SetActive(false);
    }
}
