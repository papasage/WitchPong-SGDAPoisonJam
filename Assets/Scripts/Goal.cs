using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerLeftGoal;
    SFXManager sfx;
    public CameraShake cameraShake;

    [SerializeField] GameObject rightScoreParticles;
    [SerializeField] GameObject leftScoreParticles;

    private void Awake()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //play score sound
            sfx.playSFXScore();
            
            //SHAKE CAMERA
            StartCoroutine(cameraShake.Shake(.2f, .4f));

            //LEFT PLAYER POINT
            if (!isPlayerLeftGoal)
            {
                Debug.Log("Left Player Scored!");
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLeftScored();

                //SCORE PARTICLES
                Vector3 collisionPoint = collision.ClosestPoint(transform.position);
                Instantiate(rightScoreParticles, collisionPoint, Quaternion.identity); 
            }
            //RIGHT PLAYER POINT
            else
            {
                Debug.Log("Right Player Scored!");
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerRightScored();

                //SCORE PARTICLES
                Vector3 collisionPoint = collision.ClosestPoint(transform.position);
                Instantiate(leftScoreParticles, collisionPoint, Quaternion.identity);
            }
        }
    }
}
