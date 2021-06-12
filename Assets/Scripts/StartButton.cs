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

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
           

    }
    public void GameQuit()
    {
        
    }
}
