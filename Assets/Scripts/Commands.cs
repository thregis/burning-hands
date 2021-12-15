using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Commands : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameController.score = 0;
            SceneManager.LoadScene(sceneName);
        }
    }
}
