using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AnnouncerManager vo;

    [Header("Ball")]
    public GameObject ball;

    [Header("Player Left")]
    public GameObject playerLeftPaddle;
    public GameObject playerLeftGoal;

    [Header("Player Right")]
    public GameObject playerRightPaddle;
    public GameObject playerRightGoal;

    [Header("Score UI")]
    public GameObject PlayerLeftText;
    public GameObject PlayerRightText;

    private int PlayerLeftScore;
    private int PlayerRightScore;
    
    [Header("EndGame")]
    public int ScoreMax;
    [SerializeField] GameObject rightWinnerText;
    [SerializeField] GameObject leftWinnerText;
    [SerializeField] GameObject matchSetText;
    [SerializeField] GameObject menuPromptText;
    bool gameOver = false;
    bool restartReady = false;

    [Header("Transition")]
    public Animator transition;
    GameObject musicManager;
    public AudioSource music;
    public SFXManager sfx;

    private void Awake()
    {
        transition = (Animator)FindObjectOfType(typeof(Animator));

        musicManager = GameObject.Find("MusicManager");
        music = musicManager.GetComponent<AudioSource>();
        
        sfx = (SFXManager)FindObjectOfType(typeof(SFXManager));


        vo = FindObjectOfType<AnnouncerManager>();
        leftWinnerText.SetActive(false);
        rightWinnerText.SetActive(false);
        menuPromptText.SetActive(false);
        matchSetText.SetActive(false);
    }

    public void PlayerLeftScored()
    {
        PlayerLeftScore++;
        PlayerLeftText.GetComponent<TextMeshProUGUI>().text = PlayerLeftScore.ToString();
        ResetPosition();

        if (PlayerLeftScore % 3 == 0)
        {
            vo.LaughPicker();
        }
    }
    public void PlayerRightScored()
    {
        PlayerRightScore++;
        PlayerRightText.GetComponent<TextMeshProUGUI>().text = PlayerRightScore.ToString();
        ResetPosition();

        if (PlayerRightScore % 3 == 0)
        {
            vo.LaughPicker();
        }
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();

        //Return the player's paddle position
        //playerLeftPaddle.GetComponent<Paddle>().Reset();
        //playerRightPaddle.GetComponent<Paddle>().Reset();
    }

    private void Update()
    {
        if (PlayerLeftScore == ScoreMax && gameOver == false)
        {
            StartCoroutine(PlayerVictory(true));
        }
        if (PlayerRightScore == ScoreMax && gameOver == false)
        {
            StartCoroutine(PlayerVictory(false));
        }

        if (restartReady == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button6) || Input.GetKeyDown(KeyCode.Joystick2Button6))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            StartCoroutine(sceneTransition(1));
            
        }
    }

    IEnumerator PlayerVictory(bool LeftWinner)
    {
        gameOver = true;
        Destroy(ball);
        matchSetText.SetActive(true);
        vo.playVOmatchSet();
        yield return new WaitForSeconds(2f);
        vo.playVOwinner();

        if (LeftWinner == true)
        {
            leftWinnerText.SetActive(true);
            
            yield return new WaitForSeconds(2f);
           
            menuPromptText.SetActive(true);
            restartReady = true;
        }

        else 
        {
            rightWinnerText.SetActive(true);
            
            yield return new WaitForSeconds(2f);
            
            menuPromptText.SetActive(true);
            restartReady = true;

        }
    }

    public IEnumerator ServeBall()
    {
        vo.playVOpretties();
        yield return new WaitForSeconds(2f);
    }

    public IEnumerator sceneTransition(int indexAdd)
    {
        //fade to black
        transition.SetTrigger("Start");

        //fade out music
        //fade out music
        music.Stop();
        sfx.playUIgameStart();


        //Wait a second
        yield return new WaitForSeconds(2f);

        //Load the menu
        SceneManager.LoadScene(0);
    }
}
