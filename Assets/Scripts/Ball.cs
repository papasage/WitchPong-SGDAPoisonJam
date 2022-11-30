using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public Vector3 startPosition;
    SFXManager sfx;
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
        vo = FindObjectOfType<AnnouncerManager>();
        ballSprite = GetComponent<SpriteRenderer>();
        trail = GetComponent<TrailRenderer>();
        ballShellSprite.color = colorDefault;
        ballSprite.color = Color.white;
        pp = FindObjectOfType<PoisonPicker>();

        readyText.SetActive(false);
        brewText.SetActive(false);
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
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;

        isLeftBall = false;
        isRightBall = false;

        DefaultBall();
        StartCoroutine("ServeBall");
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
        trail.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerLeft"))
        {
            sfx.playSFXPaddleHit();
            isLeftBall = true;
            isRightBall = false;

            //APPLY LEFT PLAYER'S BALL EFFECT
            LeftPoisonEffect();

            //reset ball poison
            pp.PlayerLeftDefault();
            
        } 
        if (other.gameObject.CompareTag("PlayerRight"))
        {
            sfx.playSFXPaddleHit();
            isRightBall = true;
            isLeftBall = false;

            //APPLY RIGHT PLAYER'S BALL EFFECT
            RightPoisonEffect();

            //reset ball poison
            pp.PlayerRightDefault();

        }

        if (other.gameObject.CompareTag("Wall"))
        {
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
            rb.velocity = new Vector2(-20, screwAngle);
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
            rb.velocity = new Vector2(20, screwAngle);
        }
        if (pp.isLeftScrew == true)
        {
            ScrewBall();
        }
    }

    void CurveBallDown()
    {
        ballShellSprite.color = colorCurveDown;
        trail.colorGradient = colorCurveDownGradient;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .1f));
        //HIT STOP
        FindObjectOfType<HitStop>().Stop(0.1f);
        //Play VO 
        vo.CurvePicker();

        rb.gravityScale = .75f;
    }

    void CurveBallUp()
    {
        ballShellSprite.color = colorCurveUp;
        trail.colorGradient = colorCurveUpGradient;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .1f));
        //HIT STOP
        FindObjectOfType<HitStop>().Stop(0.1f);
        //Play VO 
        vo.CurvePicker();

        rb.gravityScale = -.75f;
    }

    void DefaultBall()
    {
        ballShellSprite.color = colorDefault;
        trail.colorGradient = colorBasicGradient;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .1f));
        //HIT STOP
        FindObjectOfType<HitStop>().Stop(0.1f);

        rb.gravityScale = 0f;
    }

    void ScrewBall()
    {
        trail.colorGradient = colorScrewGradient;
        ballShellSprite.color = colorScrew;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .3f));
        //BIIIIIG HIT STOP
        FindObjectOfType<HitStop>().Stop(0.3f);
        //Play VO 
        vo.ScrewPicker();


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
        rb.gravityScale = 0f;
        trail.colorGradient = colorFastGradient;
        ballShellSprite.color = colorFast;
        //SHAKE CAMERA
        StartCoroutine(cameraShake.Shake(.1f, .3f));
        //BIIIIIG HIT STOP
        FindObjectOfType<HitStop>().Stop(0.3f);
        //Play VO 
        vo.FastPicker();

        //BALL EFFECT IS CALCULATED AT THE METHOD'S FIREPOINT. See Left/RightPoisonEffect
    }

    public IEnumerator FirstServeBall()
    {
        yield return new WaitForSeconds(.2f);
        vo.playVOpretties();
        readyText.SetActive(true);
        yield return new WaitForSeconds(2f);
        readyText.SetActive(false);
        brewText.SetActive(true);
        sfx.playSFXPaddleHit();
        Launch();
        yield return new WaitForSeconds(1f);
        brewText.SetActive(false);
    }

    public IEnumerator ServeBall()
    {
        yield return new WaitForSeconds(1f);
        sfx.playSFXPaddleHit();
        Launch();
    }
}
