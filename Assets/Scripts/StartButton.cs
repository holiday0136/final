using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceanChange()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void HelpChange()
    {
        SceneManager.LoadScene("Help");
    }
    public void XChange()
    {
        SceneManager.LoadScene("main");
    }

    private void Update()
    {
        
           

    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
