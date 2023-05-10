using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] SFXManager sfx;

    public Animator transition;



    public void Awake()
    {
    }

    public void start2PMode()
    {
        StartCoroutine(sceneTransition(1));
    }
    public void start1PModeEasy()
    {
        StartCoroutine(sceneTransition(2));
    }
    public void start1PModeMedium()
    {
        StartCoroutine(sceneTransition(3));
    }
    public void start1PModeHard()
    {
        StartCoroutine(sceneTransition(4));
    }


    public void fadeMusic()
    {

    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT GAME");
    }

    public IEnumerator sceneTransition(int indexAdd)
    {
        //fade to black
        transition.SetTrigger("Start");

        //fade out music
        music.Stop();
        sfx.playUIgameStart();

        //Wait a second
        yield return new WaitForSeconds(2f);

        //Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + indexAdd);
    }

}
