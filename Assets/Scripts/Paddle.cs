using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayerLeft;
    public bool isPlayerRight;
    public float speed;
    public float cpuSpeed;

    private Rigidbody2D rb = null;
    private Vector3 startPosition;
    private float movement;

    public PoisonPicker pp;
    public Ball _ball;
    float ballY;
    
    //this is a variable that determines how often the ai checks the ball's y position
    //consider it a % chance out of 100 per frame
    public int aiMoveBrain;
    public int aiPoisonBrain;

    private void Start()
    {
        //initialize rigidbody, PoisonPicker, and Paddle Start position
        rb = GetComponent<Rigidbody2D>();
        pp = FindObjectOfType<PoisonPicker>();
        _ball = FindObjectOfType<Ball>();

        //paddle start position is reset per-goal inside of GameManager.cs
        startPosition = transform.position;
    }

    void Update()
    {
        //calculate player's movement
        /*
        if (isPlayerLeft)
        {
            movement = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        }
        if (isPlayerRight)
        {
            movement = Input.GetAxisRaw("Vertical2");
            rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        }
        */

        //listen for player poison selection
        //PickYourPoison();

        // track the ball Y for the AI
        aiBallTracker();
        // Poison Selecter for CPU mode
        aiPoisonPicker();
    }


    //ENEMY AI MOVEMENT HERE
    private void FixedUpdate()
    {
        if (!isPlayerRight && !isPlayerLeft)
        {

            if (ballY > gameObject.transform.position.y)
            {
                movement = 1;
            }

            if (ballY < gameObject.transform.position.y)
            {
                movement = -1;
            }

            rb.velocity = new Vector2(rb.velocity.x, movement * cpuSpeed);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    void PickYourPoison()
    {
        // left and right will cycle through different chaotic ball styles that will apply to the ball when you hit it. 
        // think like how a baseball pitcher decides what kind of pitch to throw to the batter
       // if (isPlayerLeft)
       // {
            //Player LEFT cycle LEFT
            //if (Input.GetKeyDown(KeyCode.A))
           // {
               // Debug.Log("PlayerLeft: Cycled Left");
               // pp.PlayerLeftCycleLeft();
           // }
            
            //Player LEFT cycle RIGHT
           // if (Input.GetKeyDown(KeyCode.D))
            //{
               // Debug.Log("PlayerLeft: Cycled Right");
               // pp.PlayerLeftCycleRight();
           // }
       // }

       // else
       // {
            //Player RIGHT cycle LEFT
            //if (Input.GetKeyDown(KeyCode.LeftArrow))
            //{
               // Debug.Log("PlayerRight: Cycled Left");
               // pp.PlayerRightCycleLeft();
           // }

            //Player RIGHT cycle RIGHT
           // if (Input.GetKeyDown(KeyCode.RightArrow))
            //{
               // Debug.Log("PlayerRight: Cycled Right");
               // pp.PlayerRightCycleRight();
            //}
        //}
        
    }

    void aiBallTracker()
    {

        int _random1 = Random.Range(1, 100);
        if (_random1 <= aiMoveBrain)
        {
            ballY = _ball.transform.position.y;
        }

    }

    void aiPoisonPicker()
    {
        int _randomPoisonChance = Random.RandomRange(1, 1000);
        int _randomPicker = Random.RandomRange(1,2);

        if(_randomPoisonChance < aiPoisonBrain)
        {
            if (_randomPicker == 1)
            {
                pp.PlayerRightCycleRight();
            }
            else pp.PlayerRightCycleLeft();
        }

    }

    public void PlayerLeftCycleLeft()
    {
        if (isPlayerLeft)
        {
            Debug.Log("PlayerLeft: Cycled Left");
            pp.PlayerLeftCycleLeft();
        }
        
    }

    public void PlayerLeftCycleRight()
    {
        if (isPlayerLeft)
        {
            Debug.Log("PlayerLeft: Cycled Right");
            pp.PlayerLeftCycleRight();
        }
    }
    
    public void PlayerRightCycleLeft()
    {
        if (isPlayerRight)
        {
            Debug.Log("PlayerRight: Cycled Left");
            pp.PlayerRightCycleLeft();
        }
        
    }

    public void PlayerRightCycleRight()
    {
        if (isPlayerLeft)
        {
            Debug.Log("PlayerRight: Cycled Right");
            pp.PlayerRightCycleRight();
        }
    }
}
