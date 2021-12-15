using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField]
    public float characterSpeed;
    [Header("Character limits configuration")]
    [SerializeField]
    public float yMax = 1.25f;
    [SerializeField]
    public float xMax = 0;
    [SerializeField]
    public float xMin = -6.2f;


    [Header("Gameplay configuration")]
    [SerializeField] 
    public float objectSpeed = -3f;
    private float objectSpawnInterval = 5f;
    [SerializeField]
    public float accelerationInterval = 5f;


    [Header("Ground configuration")]
    [SerializeField]
    public GameObject groundPrefab;
    [SerializeField]
    public float groundSize = 16f;

    [Header("Objects configuration")]
    [SerializeField]
    public GameObject crystal;
    [SerializeField]
    public GameObject iceBox;
    [SerializeField]
    public GameObject stone;
    [SerializeField]
    public float objectSpawnPosition = 9;

    [Header("HUD configuration")]
    public Text scoreText;
    public static int score;
    [SerializeField]
    private float scoreIncrement = 0.2f;

    [Header("Audio configuration")]
    public AudioSource music;

    public void InstantiateGround(float currentPosition)
    {
        GameObject tempGround = Instantiate(groundPrefab);
        tempGround.transform.position = new Vector3(currentPosition + groundSize, tempGround.transform.position.y, 0);
    }

    private void Start()
    {
        StartCoroutine("SpawnObject");
        StartCoroutine("Score");
        StartCoroutine("Accelerate");
    }

    private void Update()
    {
        
    }


    private GameObject SelectObject(int number)
    {
        if(number == 0)
        {
            return crystal;
        }
        else if(number == 1)
        {
            return iceBox;
        }
        else
        {
            return stone;
        }
    }

    public void GameOver()
    {
        //music.Stop();
        //StopAllCoroutines();
        //DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("GameOver");

    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(objectSpawnInterval);

        objectSpawnInterval = Random.Range(0.5f, 4);

        GameObject selectedObject = SelectObject(Random.Range(0, 3));
        GameObject tempObject = Instantiate(selectedObject);
        tempObject.transform.position = new Vector3(objectSpawnPosition, -2.85f, 0);

        StartCoroutine("SpawnObject");
    }
    IEnumerator Score()
    {
        yield return new WaitForSeconds(scoreIncrement);
        score++;
        scoreText.text = "Score: "+ score.ToString();

        StartCoroutine("Score");
    }

    IEnumerator Accelerate()
    {
        yield return new WaitForSeconds(accelerationInterval);
        objectSpeed -= 1;
        objectSpawnInterval += objectSpeed/100;

        StartCoroutine("Accelerate");
    }
}
