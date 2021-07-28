using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInformation : MonoBehaviour
{

    public static bool VisualizatonPaused = false;
    

    public GameObject visualizationPauseUI;
    public GameObject MiniMapY;
    public GameObject MiniMapZ;
    public GameObject MiniMapX;
    public GameObject Legend;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(VisualizatonPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            if(VisualizatonPaused)
            {
                CloseLegend();
            }
            else
            {
                OpenLegend();
            }
        }
    }

    void Resume()
    {
        visualizationPauseUI.SetActive(false);
        MiniMapY.SetActive(true);
        MiniMapZ.SetActive(true);
        MiniMapX.SetActive(true);
        Legend.SetActive(false);
        Time.timeScale = 1f;
        VisualizatonPaused = false;
    }
    void Pause()
    {
        visualizationPauseUI.SetActive(true);
        MiniMapY.SetActive(false);
        MiniMapZ.SetActive(false);
        MiniMapX.SetActive(false);
        Legend.SetActive(false);
        Time.timeScale = 0f;
        VisualizatonPaused = true;
    }

    void OpenLegend()
    {
        Legend.SetActive(true);
        MiniMapY.SetActive(false);
        MiniMapZ.SetActive(false);
        MiniMapX.SetActive(false);
        visualizationPauseUI.SetActive(false);
        Time.timeScale = 0f;
        VisualizatonPaused = true;
    }
    void CloseLegend()
    {
        Legend.SetActive(false);
        MiniMapY.SetActive(true);
        MiniMapZ.SetActive(true);
        MiniMapX.SetActive(true);
        visualizationPauseUI.SetActive(false);
        Time.timeScale = 1f;
        VisualizatonPaused = false;
    }
}
