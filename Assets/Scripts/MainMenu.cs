using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        //Load random scene
        int index = Random.Range(1, 3);
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        //Exit app
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene(4);
    }


}
