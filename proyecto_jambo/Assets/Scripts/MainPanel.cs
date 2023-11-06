using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
    [Header("opciones")]
    public Slider volumen;
    [Header("Paneles")]
    public GameObject backgroundPanel;
    public GameObject mainPanel;
    public GameObject opcionPanel;

    public void OpenPanel(GameObject panel)
    {
        backgroundPanel.SetActive(false);
        mainPanel.SetActive(false);
        opcionPanel.SetActive(false);

        panel.SetActive(true);
    }
    public void PlayLevel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
}
