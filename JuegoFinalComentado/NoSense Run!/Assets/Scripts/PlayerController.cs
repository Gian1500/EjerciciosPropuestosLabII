using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioPlayer;

    public GameObject game;
    public GameObject obstaculeGenerator;
    public AudioClip jumpClip;
    public AudioClip dieClip;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool gamePlaying = game.GetComponent<GameController>().gameState == GameState.Playing;

        if (gamePlaying && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {

            UpdateState("PlayerJump");
            audioPlayer.clip = jumpClip;
            audioPlayer.Play();
        }

    }

    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacule")
        {
            UpdateState("PlayerDie");

            game.GetComponent<GameController>().gameState = GameState.Ended;

            obstaculeGenerator.SendMessage("StopGenerator",true);

            game.SendMessage("ResetTimeScale");

            game.GetComponent<AudioSource>().Stop();

            audioPlayer.clip = dieClip;

            audioPlayer.Play();

        }
    }

    void GameReady()
    {
        game.GetComponent<GameController>().gameState = GameState.Ready;
    }
}
