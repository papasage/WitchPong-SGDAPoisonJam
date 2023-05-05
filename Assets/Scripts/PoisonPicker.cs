using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoisonPicker : MonoBehaviour
{
    public float rightParryElapsed;
    public float leftParryElapsed;

    [Header("Poison Debugger UI")]
    public GameObject PlayerLeftPowerText;
    public GameObject PlayerRightPowerText;    
    public GameObject PlayerLeftHerbText;
    public GameObject PlayerRightHerbText;

    [Header("Player Paddles")]
    [SerializeField] SpriteRenderer LeftPaddleSprite;
    [SerializeField] SpriteRenderer RightPaddleSprite;
    [SerializeField] Sprite paddleCurveUp;
    [SerializeField] Sprite paddleCurveDown;
    [SerializeField] Sprite paddleFast;
    [SerializeField] Sprite paddleScrew;
    [SerializeField] Sprite paddleDefault;

    [Header("Herb Names")]
    public string root = "Mandrake";
    public string flower = "Deadly Nightshade";
    public string berry = "Winter Berry";
    public string shroom = "Verdigris Agaric";
    public string basic = "Rose Water";
    [Header("Ball Types")]
    public string screw = "ScrewBall";
    public string curveDown = "CurveBall Down";
    public string curveUp = "CurveBall Up";
    public string fast = "Fast Ball";
    public string basicball = "Default";

    int poisonMin = 1;
    int poisonMax = 5;
    
    int poisonLeft = 3;
    int poisonRight = 3;

    SFXManager sfx;
    Ball ball;

    [Header("PlayerLeft's Poison")]
    public bool isLeftScrew = false;
    public bool isLeftCurveDown = false;
    public bool isLeftDefault = true;
    public bool isLeftCurveUp = false;
    public bool isLeftFast = false;

    [Header("PlayerRight's Poison")]
    public bool isRightScrew = false;
    public bool isRightCurveDown = false;
    public bool isRightDefault = true;
    public bool isRightCurveUp = false;
    public bool isRightFast = false;

    private void Awake()
    {
        PlayerLeftPowerText.GetComponent<TextMeshProUGUI>().text = poisonLeft.ToString();
        PlayerRightPowerText.GetComponent<TextMeshProUGUI>().text = poisonRight.ToString();
        sfx = FindObjectOfType<SFXManager>();
        ball = FindObjectOfType<Ball>();
    }


    private void Update()
    {
        //Left and Right player is counting frames for parrying
        leftParryElapsed += Time.deltaTime;
        rightParryElapsed += Time.deltaTime;

        PlayerLeftPoisonSelect();
        PlayerRightPoisonSelect();
    }



    //--------------METHODS---------------

    //Reset the Left Player's poison after hit
    public void PlayerLeftDefault()
    {
        sfx.playSFXCycleDefault();
        poisonLeft = 3;
        //PlayerLeftText.GetComponent<TextMeshProUGUI>().text = poisonLeft.ToString();
    }

    //Reset the Right Player's poison after hit
    public void PlayerRightDefault()
    {
        sfx.playSFXCycleDefault();
        poisonRight = 3;
        //PlayerRightText.GetComponent<TextMeshProUGUI>().text = poisonRight.ToString();
    } 
    
    //Cycle the Left Player's Poison
    public void PlayerLeftCycleLeft()
    {
        //reset the left parry frame count
        leftParryElapsed = 0;

        sfx.playSFXCycleDown();

        if (poisonLeft > poisonMin)
        {
            poisonLeft--;
        }
        else poisonLeft = poisonMax;

        //PlayerLeftText.GetComponent<TextMeshProUGUI>().text = poisonLeft.ToString();
    } 
    public void PlayerLeftCycleRight()
    {
        //reset the left parry frame count
        leftParryElapsed = 0;

        sfx.playSFXCycleUp();

        if (poisonLeft < poisonMax)
        {
            poisonLeft++;
        }
        else poisonLeft = poisonMin;
            
        //PlayerLeftText.GetComponent<TextMeshProUGUI>().text = poisonLeft.ToString();
    }

    //Cycle the Right Player's Poison
    public void PlayerRightCycleLeft()
    {
        //reset the right parry frame count
        rightParryElapsed = 0;

        sfx.playSFXCycleDown();

        if (poisonRight > poisonMin)
        {
            poisonRight--;
        }
        else poisonRight = poisonMax;

        //PlayerRightText.GetComponent<TextMeshProUGUI>().text = poisonRight.ToString();
    } 
    public void PlayerRightCycleRight()
    {
        //reset the right parry frame count
        rightParryElapsed = 0;

        sfx.playSFXCycleUp();

        if (poisonRight < poisonMax)
        {
            poisonRight++;
        }
        else poisonRight = poisonMin;

        //PlayerRightText.GetComponent<TextMeshProUGUI>().text = poisonRight.ToString();
    }

    //Set the Poison Descriptions
    public void PlayerLeftPoisonSelect()
    {
        if (poisonLeft == 1)
        {
            isLeftDefault = false;
            isLeftCurveUp = false;
            isLeftCurveDown = false;
            isLeftFast = false;
            isLeftScrew = true;

            LeftPaddleSprite.sprite = paddleScrew;
            PlayerLeftPowerText.GetComponent<TextMeshProUGUI>().text = screw;
            PlayerLeftHerbText.GetComponent<TextMeshProUGUI>().text = root;
        }
        if (poisonLeft == 2)
        {
            isLeftDefault = false;
            isLeftCurveUp = false;
            isLeftCurveDown = true;
            isLeftFast = false;
            isLeftScrew = false;

            LeftPaddleSprite.sprite = paddleCurveDown;
            PlayerLeftPowerText.GetComponent<TextMeshProUGUI>().text = curveDown;
            PlayerLeftHerbText.GetComponent<TextMeshProUGUI>().text = flower;
        }
        if (poisonLeft == 3)
        {
            isLeftDefault = true;
            isLeftCurveUp = false;
            isLeftCurveDown = false;
            isLeftFast = false;
            isLeftScrew = false;

            LeftPaddleSprite.sprite = paddleDefault;
            PlayerLeftPowerText.GetComponent<TextMeshProUGUI>().text = basicball;
            PlayerLeftHerbText.GetComponent<TextMeshProUGUI>().text = basic;
        }
        if (poisonLeft == 4)
        {
            isLeftDefault = false;
            isLeftCurveUp = true;
            isLeftCurveDown = false;
            isLeftFast = false;
            isLeftScrew = false;

            LeftPaddleSprite.sprite = paddleCurveUp;
            PlayerLeftPowerText.GetComponent<TextMeshProUGUI>().text = curveUp;
            PlayerLeftHerbText.GetComponent<TextMeshProUGUI>().text = berry;
        }
        if (poisonLeft == 5)
        {
            isLeftDefault = false;
            isLeftCurveUp = false;
            isLeftCurveDown = false;
            isLeftFast = true;
            isLeftScrew = false;

            LeftPaddleSprite.sprite = paddleFast;
            PlayerLeftPowerText.GetComponent<TextMeshProUGUI>().text = fast;
            PlayerLeftHerbText.GetComponent<TextMeshProUGUI>().text = shroom;
        }
    }
    public void PlayerRightPoisonSelect()
    {
        if (poisonRight == 1)
        {
            isRightScrew = true;
            isRightCurveDown = false;
            isRightDefault = false;
            isRightCurveUp = false;
            isRightFast = false;

            RightPaddleSprite.sprite = paddleScrew;
            PlayerRightPowerText.GetComponent<TextMeshProUGUI>().text = screw;
            PlayerRightHerbText.GetComponent<TextMeshProUGUI>().text = root;
        }
        if (poisonRight == 2)
        {
            isRightScrew = false;
            isRightCurveDown = true;
            isRightDefault = false;
            isRightCurveUp = false;
            isRightFast = false;

            RightPaddleSprite.sprite = paddleCurveDown;
            PlayerRightPowerText.GetComponent<TextMeshProUGUI>().text = curveDown;
            PlayerRightHerbText.GetComponent<TextMeshProUGUI>().text = flower;
        }
        if (poisonRight == 3)
        {
            isRightScrew = false;
            isRightCurveDown = false;
            isRightDefault = true;
            isRightCurveUp = false;
            isRightFast = false;

            RightPaddleSprite.sprite = paddleDefault;
            PlayerRightPowerText.GetComponent<TextMeshProUGUI>().text = basicball;
            PlayerRightHerbText.GetComponent<TextMeshProUGUI>().text = basic;
        }
        if (poisonRight == 4)
        {
            isRightScrew = false;
            isRightCurveDown = false;
            isRightDefault = false;
            isRightCurveUp = true;
            isRightFast = false;

            RightPaddleSprite.sprite = paddleCurveUp;
            PlayerRightPowerText.GetComponent<TextMeshProUGUI>().text = curveUp;
            PlayerRightHerbText.GetComponent<TextMeshProUGUI>().text = berry;
        }
        if (poisonRight == 5)
        {
            isRightScrew = false;
            isRightCurveDown = false;
            isRightDefault = false;
            isRightCurveUp = false;
            isRightFast = true;

            RightPaddleSprite.sprite = paddleFast;
            PlayerRightPowerText.GetComponent<TextMeshProUGUI>().text = fast;
            PlayerRightHerbText.GetComponent<TextMeshProUGUI>().text = shroom;
        }
    }
   
}
