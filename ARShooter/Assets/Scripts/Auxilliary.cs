using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//You can insert here methods that aren't specific to anything, e.g the RestartGame method.

public class Auxilliary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}
