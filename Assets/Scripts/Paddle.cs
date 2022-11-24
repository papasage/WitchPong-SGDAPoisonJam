using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayerLeft;
    public float speed;

    private Rigidbody2D rb = null;
    private Vector3 startPosition;
    private float movement;

    public PoisonPicker pp;


    private void Start()
    {
        //initialize rigidbody, PoisonPicker, and Paddle Start position
        rb = GetComponent<Rigidbody2D>();
        pp = FindObjectOfType<PoisonPicker>();

        //paddle start position is reset per-goal inside of GameManager.cs
        startPosition = transform.position;
    }

    void Update()
    {
        //calculate player's movement

        if (isPlayerLeft)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

        rb.velocity = new Vector2(rb.velocity.x, movement * speed);


        //listen for player poison selection
        PickYourPoison();
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("PlayerLeft: Cycled Left");
                pp.PlayerLeftCycleLeft();
            }
            
            //Player LEFT cycle RIGHT
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("PlayerLeft: Cycled Right");
                pp.PlayerLeftCycleRight();
            }
        }

        else
        {
            //Player RIGHT cycle LEFT
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("PlayerRight: Cycled Left");
                pp.PlayerRightCycleLeft();
            }

            //Player RIGHT cycle RIGHT
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("PlayerRight: Cycled Right");
                pp.PlayerRightCycleRight();
            }
        }
        
    }

}
