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
    private float movement2;

    public PoisonPicker pp;
    public Ball _ball;
    float ballLastSeenY;
    
    //this is a variable that determines how often the ai checks the ball's y position
    //consider it a % chance out of 100 per frame
    public int aiMoveBrain; // x/100 chance to update ballLastSeenY
    public int aiPoisonBrain; // x/1000 chance to 50/50 cycle to the left or right
    public float aiReactionRange; // if the ball is greater than x or less than -x, then react (LOWER NUMBER MEANS LESS REACTION TIME)

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

        if (isPlayerLeft)
        {
            movement = Input.GetAxisRaw("Vertical");
            movement2 = Input.GetAxisRaw("Vertical3");
            rb.velocity = new Vector2(rb.velocity.x, (movement + movement2) * speed);
        }
        if (isPlayerRight)
        {
            movement = Input.GetAxisRaw("Vertical2");
            movement2 = Input.GetAxisRaw("Vertical4");
            rb.velocity = new Vector2(rb.velocity.x, (movement + movement2) * speed);
        }

        //listen for player poison selection
        PickYourPoison();

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

            if (ballLastSeenY > gameObject.transform.position.y + aiReactionRange)
            {
                // if the ball was last seen above the paddle (plus reaction range) move up
                movement = 1;
            }

            if (ballLastSeenY < gameObject.transform.position.y - aiReactionRange)
            {
                // if the ball was last seen below the paddle (minus reaction range) move down
                movement = -1;
            }

            if (ballLastSeenY > gameObject.transform.position.y - aiReactionRange && ballLastSeenY < gameObject.transform.position.y + aiReactionRange)
            {
                // if the ball was last seen within the reaction range, don't move. 
                movement = 0;
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
        if (isPlayerLeft)
        {
            //Player LEFT cycle LEFT
            if (Input.GetKeyDown(KeyCode.A) || (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0))
            {
                Debug.Log("PlayerLeft: Cycled Left");

                pp.PlayerLeftCycleLeft();
            }
            
            //Player LEFT cycle RIGHT
            if (Input.GetKeyDown(KeyCode.D) || (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0))
            {
                Debug.Log("PlayerLeft: Cycled Right");

                pp.PlayerLeftCycleRight();
            }

        }

        else
        {
            //Player RIGHT cycle LEFT
            if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetButtonDown("Horizontal2") && Input.GetAxisRaw("Horizontal2") < 0))
            {
                Debug.Log("PlayerRight: Cycled Left");


                pp.PlayerRightCycleLeft();
            }

            //Player RIGHT cycle RIGHT
            if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetButtonDown("Horizontal2") && Input.GetAxisRaw("Horizontal2") > 0))
            {
                Debug.Log("PlayerRight: Cycled Right");

                pp.PlayerRightCycleRight();
            }
        }
        
    }

    void aiBallTracker()
    {

        int _random1 = Random.Range(1, 100);
        if (_random1 <= aiMoveBrain && _ball != null)
        {
            ballLastSeenY = _ball.transform.position.y;
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
}
