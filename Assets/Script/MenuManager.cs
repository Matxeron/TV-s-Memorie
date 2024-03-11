using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    //TP2 Vintar
    public GameObject canvas;
    public GameObject PanelCredits;
    public GameObject PanelControls;

    Pause _pause;
    private void Start()
    {
        _pause = new Pause();
    }
    public void Resume()
    {
        _pause.PausedGame(canvas, false, 1); 
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Credits()
    {
        PanelCredits.SetActive(true);
    }

    public void Controls()
    {
        PanelControls.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Nivel1Blockout");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Reset()
    {
       
        string nombreEscena = SceneManager.GetActiveScene().name;

       
        SceneManager.LoadScene(nombreEscena);
    }
}
