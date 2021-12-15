using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScorePersister : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        scoreText.text = "Score: " + GameController.score.ToString();
    }
}
