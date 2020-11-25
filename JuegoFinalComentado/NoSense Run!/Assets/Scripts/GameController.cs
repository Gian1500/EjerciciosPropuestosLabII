using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum GameState { Idle, Playing, Ended, Ready }; //CREA las diferentes instancias o momentos del juego

public class GameController : MonoBehaviour
{
    //Variables del efecto Parallax
    public float parallaxSpeed = 0.06f;
    public RawImage background;
    public RawImage platform;

    //variables de la instancia de juego y los objetos del Canvas
    public GameState gameState = GameState.Idle;
    public GameObject uiIdle;
    public GameObject uiScore;
    public GameObject uiEnded;

    public Text pointsText;
    public Text bestText;
    public Text dieText;

    public GameObject player;
    public GameObject obstaculeGenerator;
    public float scaleTime = 10f;
    public float scaleInc = 0.1f;


    private AudioSource musicPlayer;
    private int points = 0;
    private float Cont = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>(); //inicia la musica cuando el juego empieza
        bestText.text = "Best: " + GetMaxScore().ToString(); // indica el mejor puntaje obtenido y lo convierte a string para mostrar en pantalla
    }

    // Update is called once per frame
    void Update() //Bucle de juego
    {
        //INICIO DEL JUEGO
        if (gameState == GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);// se desactiva el titulo, best score y la descripcion del inicio
            uiScore.SetActive(true);// se activa la interfaz del juego
            player.SendMessage("UpdateState","PlayerRun");// envio de mensajes entre scripts que hacen que se desencadene el evento "actualizar estado" y la animacion de correr
            obstaculeGenerator.SendMessage("StartGenerator");// inicia el generador de obstaculos
            musicPlayer.Play();
            InvokeRepeating("GameTimeScale", scaleTime , scaleTime);// ir incrementando el Parallax en una medida de escala de tiempo

            

        }
       
        //JUEGO RUNNING
        else if (gameState == GameState.Playing)
        {
            Parallax();
            IncreasePoints();
        }

        else if (gameState == GameState.Ended)
        {
            uiEnded.SetActive(true);// interfaz de muerte

            if (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))
            {

                RestartGame();
            }


        }

        else if (gameState == GameState.Ready)
        {
            uiEnded.SetActive(true);

            if (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))
            {

                RestartGame();
            }


        }


    }
    
    void Parallax()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
    }

    public void IncreasePoints()
    {

        Cont = Cont + 0.08f;

        if (Cont>=0.8)
        {
            pointsText.text = points.ToString();
            points++;
            Cont = 0f;
        }

        if (points >= GetMaxScore())
        {
            bestText.text = "Best: " + points.ToString();
            SetScore(points);
        }
    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("Max Points",0);
    }

    public void SetScore(int currentPoints)
    {
        PlayerPrefs.SetInt("Max Points", currentPoints);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Assets/Scenes/Main.unity");
    }
    //DIFICULTAD DEL JUEGO

    void GameTimeScale()
    {
        Time.timeScale += scaleInc;
        Debug.Log("Ritmo Incrementeado: " + Time.timeScale.ToString());
    }

    public void ResetTimeScale()
    {
        CancelInvoke("GameTimeScale");
        Time.timeScale = 1f;
        Debug.Log("Ritmo Reestablecido: " + Time.timeScale.ToString());
    }

  
}

