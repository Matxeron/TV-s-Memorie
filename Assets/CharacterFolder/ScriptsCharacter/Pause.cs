
using UnityEngine;

public class Pause
{

    //TP2 Marques

    public void PausedGame(GameObject canvasPaused, bool estate, float time)
    {
        canvasPaused.SetActive(estate);
        Time.timeScale = time;
    }
}
