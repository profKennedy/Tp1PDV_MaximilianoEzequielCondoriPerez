using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelEndGame : MonoBehaviour
{
    public void ChangeScene(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
    
}
