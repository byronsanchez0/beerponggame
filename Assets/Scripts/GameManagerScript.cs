using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    #region Singleton class: GameManager
    public static GameManagerScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    Camera cam; 
    public Ball ball;  // Reference to the current ball
    public Trayectory trajectory;
    [SerializeField] float pushForce = 3f;
    public Transform spawnPoint;  // Set this in the Inspector for ball spawn position
    private Vector2 initialPosition = new Vector2(-2.35f, -3.63f);
    public GameObject ballPrefab; // Reference to the ball prefab
    //public GameObject[] vasos;



    // Fields for drag and force calculation amor, quiero decirte algo. No sé si ya te levantaste o seguis con los jos chinitos pero mi amor, es tan bonito pensar que cuando los abris tu dia empieza y no se como se te vienen las cosas que tengas que hacer en el dia o las gans quwe tengas pero a mi lo que nunca sale de mi mente sos vos, en mi dia a dia yo me
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 force;
    public GameObject youWin;

     


    private int score;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private void Start()
    {
        cam = Camera.main;
        if (ball != null)
        {
            ball.DesactivateRb();
        }
    }

    private void Update()
    {
        if (ball != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnDragStart();
            }
            if (Input.GetMouseButtonUp(0))
            {
                OnDragEnd();
            }
            if (Input.GetMouseButton(0))
            {
                OnDrag();
            }
        }
        if (score == 1)
        {
            Time.timeScale = 0;
            youWin.SetActive(true);
        }
    }

    void OnDragStart()
    {
        Debug.Log("tirar es esto");
        ball.DesactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();
    }

    void OnDrag()
    {
        if (ball != null)
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            float distance = Vector2.Distance(startPoint, endPoint);
            Vector2 direction = (startPoint - endPoint).normalized;
            force = direction * distance * pushForce;

            trajectory.UpdateDots(ball.pos, force); // Update trajectory dots
        }
    }

    void OnDragEnd()
    {
        if (ball != null)
        {
            ball.ActivateRb();
            ball.Push(force); // Use the force calculated during OnDrag
            //Debug.Log("metodo de tirar entra");
            //Debug.Log("Force applied: " + force);
            trajectory.Hide();
        }
    }

    // Called when ball enters the hole
    public void BallInHole()
    {
        // Update score
        AddScore();

        // Nullify the ball reference (the ball was destroyed)
        ball = null;

        // Wait a moment and then spawn a new ball
        StartCoroutine(SpawnNewBall());

    }

    // Coroutine to delay spawning of the new ball
    IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(.65f);  // Adjust delay time if needed

        // Spawn a new ball
        GameObject newBall = Instantiate(ballPrefab, initialPosition, Quaternion.identity);

        // Get the Ball component and assign it to the GameManager
        ball = newBall.GetComponent<Ball>();

        // Deactivate Rigidbody to prevent movement on spawn
        ball.DesactivateRb();

    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = $"{score}";
    }
}

