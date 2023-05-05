using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Parry Window info")]
    public float parryWindow;
    [Header("Ball Stuff")]
    public float speed;
    private float initialSpeed;
    Rigidbody2D rb;
    public Vector3 startPosition;
    SFXManager sfx;
    ParrySFX psfx;
    public SpriteRenderer ballSprite;
    public SpriteRenderer ballShellSprite;
    public CameraShake cameraShake;
    public PoisonPicker pp;
    public AnnouncerManager vo;
    float screwAngle;


    [Header("Volley Attributes")]
    public Color colorCurveUp;
    public Color colorCurveDown;
    public Color colorFast;
    public Color colorScrew;
    public Color colorLeft;
    public Color colorRight;
    public Color colorDefault;
    public bool isLeftBall = false;
    public bool isRightBall = false;
    TrailRenderer trail;
    public Gradient colorCurveUpGradient;
    public Gradient colorCurveDownGradient;
    public Gradient colorFastGradient;
    public Gradient colorScrewGradient;
    [Header("Intro Text")]
    public GameObject readyText;
    public GameObject brewText;


    //public Gradient colorRightGradient;
    //public Gradient colorLeftGradient;
    public Gradient colorBasicGradient;

    private void Awake()
    {
        sfx = FindObjectOfType<SFXManager>();
        psfx = FindObjectOfType<ParrySFX>();
        vo = FindObjectOfType<AnnouncerManager>();
        ballSprite = GetComponent<SpriteRenderer>();
        trail = GetComponent<TrailRenderer>();
        ballShellSprite.color = colorDefault;
        ballSprite.color = Color.white;
        pp = FindObjectOfType<PoisonPicker>();

        readyText.SetActive(false);
        brewText.SetActive(false);

        //initialize speed;
        initialSpeed = speed;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        StartCoroutine("FirstServeBall");
    }

    private void Update()
    {
        if (isRightBall == true)
        {
            //ballShellSprite.color = colorRight;
            //trail.colorGradient = colorRightGradient;
        }
        
        if (isLeftBall == true)
        {
            //ballShellSprite.color = colorLeft;
            //trail.colorGradient = colorLeftGradient;
        }

        if (isLeftBall == false && isRightBall == false)
        {
            ballShellSprite.color = colorDefault;
            trail.colorGradient = colorBasicGradient;
        }

        if (pp.isLeftScrew || pp.isRightScrew)
        {
            screwAngle = Mathf.Sin(20);
        }

        //if the speed is above 100, make it 100.
        SpeedCapper(60);
    }

    public void Reset()
    {
        //Restore Speed
        speed = initialSpeed;

        //Stop moving the ball
        rb.velocity = Vector2.zero;
        
        /*

        //clone yourself
        Instantiate(gameObject);
        //kill yourself
        Destroy(gameObject);
        */
        
        //MOVE THE BALL TO THE CENTER, RESET OWNERSHIP, RESET POWER, SERVE BALL
        
        transform.position = startPosition;

        isLeftBall = false;
        isRightBall = false;

        DefaultBall();
        StartCoroutine("ServeBall");
        
    }

    private void Launch()
    {
        //Choose a random direction
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        
        //Push the ball in that direction
        rb.velocity = new Vector2(speed * x, speed * y);

        //Clear the Ball's Trail
        trail.Clear();

        //Turn the trail back on
        trail.enabled = true;

        //Serve Sound Effect (Currently Paddle sound)
        sfx.playSFXPaddleHit();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerLeft"))
        {
            //Swap Ball Ownership
            isLeftBall = true;
            isRightBall = false;

            //APPLY LEFT PLAYER'S BALL EFFECT
            LeftPoisonEffect();

            //Check for a Parry
            if (pp.leftParryElapsed < parryWindow)
            {
                Debug.Log("Nice Parry, Player Left!");
                psfx.playSFXParry();
                rb.velocity = rb.velocity * 1.25f;
            } else sfx.playSFXPaddleHit(); //Paddle Hit Sound

            //Reset Left Player's Equipped Poison
            pp.PlayerLeftDefault();
            
        } 
        if (other.gameObject.CompareTag("PlayerRight"))
        {
            //Swap Ball Ownership
            isRightBall = true;
            isLeftBall = false;

            //APPLY RIGHT PLAYER'S BALL EFFECT
            RightPoisonEffect();

            //Check for a Parry
            if (pp.rightParryElapsed < parryWindow)
            {
                //Debug.Log("Nice Parry, Player Right!");
                psfx.playSFXParry();
                rb.velocity = rb.velocity * 1.25f;
            }
            else sfx.playSFXPaddleHit(); //Paddle Hit Sound

            //Reset Right Player's Equipped Poison
            pp.PlayerRightDefault();

        }

        if (other.gameObject.CompareTag("Wall"))
        {
            //Wall Hit Sound
            sfx.playSFXWallHit();

            //SHAKE CAMERA
            StartCoroutine(cameraShake.Shake(.1f, .05f));

        }

    }

    void RightPoisonEffect()
    {
        if (pp.isRightCurveDown == true)
        {
            CurveBallDown();
        }
        if (pp.isRightCurveUp == true)
        {
            CurveBallUp();
        }
        if (pp.isRightDefault == true)
        {
            DefaultBall();
        }
        if (pp.isRightFast == true)
        {
            FastBall();
            rb.velocity = new Vector2(-rb.velocity.x * 2, screwAngle);
        }
        if (pp.isRightScrew == true)
        {
            ScrewBall();
        }
    }

    void LeftPoisonEffect()
    {
        if (pp.isLeftCurveDown == true)
        {
            CurveBallDown();
        }
        if (pp.isLeftCurveUp == true)
        {
            CurveBallUp();
        }
        if (pp.isLeftDefault == true)
        {
            DefaultBall();
        }
        if (pp.isLeftFast == true)
        {
            FastBall();
            rb.velocity = new Vector2(rb.velocity.x * 2, screwAngle);
        }
        if (pp.isLeftScrew == true)
        {
            ScrewBall();
        }
    }

    void CurveBallDown()
    {
        //Set Ball Color
        ballShellSprite.color = colorCurveDown;
        //Set Trail Color
        trail.colorGradient = colorCurveDownGradient;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .1f));
        //HIT STOP
        FindObjectOfType<HitStop>().Stop(0.1f);
        //Play VO 
        vo.CurvePicker();

        //Curve Ball Down Effect
        rb.gravityScale = .75f;
    }

    void CurveBallUp()
    {
        //Set Ball Color
        ballShellSprite.color = colorCurveUp;
        //Set Trail Color
        trail.colorGradient = colorCurveUpGradient;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .1f));
        //HIT STOP
        FindObjectOfType<HitStop>().Stop(0.1f);
        //Play VO 
        vo.CurvePicker();

        //Curve Ball Up Effect
        rb.gravityScale = -.75f;
    }

    void DefaultBall()
    {
        //Set Ball Color
        ballShellSprite.color = colorDefault;
        //Set Trail Color
        trail.colorGradient = colorBasicGradient;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .1f));
        //HIT STOP
        FindObjectOfType<HitStop>().Stop(0.1f);

        //Default Ball Effect
        rb.gravityScale = 0f;
    }

    void ScrewBall()
    {
        //Set Ball Color
        ballShellSprite.color = colorScrew;
        //Set Trail Color
        trail.colorGradient = colorScrewGradient;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .3f));
        //BIIIIIG HIT STOP
        FindObjectOfType<HitStop>().Stop(0.3f);
        //Play VO 
        vo.ScrewPicker();

        //Screw Ball Effect
        // 50/50 chance that the ball will have positive or negative gravity with a range of strength
        if (Random.Range(0f, 1f) > .5f)
        {
            rb.gravityScale = Random.Range(4f, 6f);
        }
        else
        {
            rb.gravityScale = Random.Range(-4f, -6f);
        }
    }
    void FastBall()
    {
        //Set Ball Color
        ballShellSprite.color = colorFast;
        //Set Trail Color
        trail.colorGradient = colorFastGradient;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .3f));
        //BIIIIIG HIT STOP
        FindObjectOfType<HitStop>().Stop(0.3f);
        //Play VO 
        vo.FastPicker();

        //BALL EFFECT IS CALCULATED AT THE METHOD'S FIREPOINT. See Left/RightPoisonEffect
        rb.gravityScale = 0f;
    }

    void SpeedCapper(int speedLimit)
    {
        if (rb.velocity.x >= speedLimit)
        {
            rb.velocity = new Vector2(speedLimit, rb.velocity.y);
        }

        if (rb.velocity.y >= speedLimit)
        {
            rb.velocity = new Vector2(rb.velocity.x , speedLimit);
        }
    }

    // First Serve Ball is where the pre-game countdown is handled
    public IEnumerator FirstServeBall()
    {
        yield return new WaitForSeconds(.2f);

        //"My Pretties!" Witch Call
        vo.playVOpretties();
        // show "READY?"
        readyText.SetActive(true);
        // wait 2 seconds
        yield return new WaitForSeconds(2f);
        // hide "READY?"
        readyText.SetActive(false);
        // Show "BREW!"
        brewText.SetActive(true);
        // Launch the Ball
        Launch();
        // Wait a second
        yield return new WaitForSeconds(1f);
        // hide "BREW!"
        brewText.SetActive(false);
    }

    // Serve Ball is called after every score
    public IEnumerator ServeBall()
    {
        //Wait a second
        yield return new WaitForSeconds(1f);
        //Launch the Ball
        Launch();
    }
}
