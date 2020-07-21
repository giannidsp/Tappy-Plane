using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static Text scoreText;
    private static int score;
    
    public static int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    [Header("Obstacle Information")]

    [Tooltip("The obstacle that we will spawn")]
    public GameObject obstacleReference;

    [Tooltip("Minimum Y value used for obstacle")]
    public float obstacleMinY = -1.3f;

    [Tooltip("Maximum Y value used for obstacle")]
    public float obstacleMaxY = 1.3f;

    /// <summary>
    /// Creates the obstacle an initializes its position.
    /// </summary>
    void CreateObstacle()
    {
        // Spawn offscreen with a random Y
        Instantiate(obstacleReference, new Vector3(RepeatingBackground.ScrollWidth,
        Random.Range(obstacleMinY, obstacleMaxY),0.0f), Quaternion.identity);
    }

    [HideInInspector] // Hides var below
    /// <summary>
    /// Affects how fast objects with the
    /// RepeatingBackground script move.
    /// </summary>
    public static float speedModifier;
    
    // Use this for initialization
    // Start is called before the first frame update
    void Start ()
    {
        speedModifier = 1.0f;
        gameObject.AddComponent<GameStartBehaviour>();
        score = 0;
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }
    
}
