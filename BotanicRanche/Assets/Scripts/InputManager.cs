using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InputManager : MonoBehaviour
{
    //private LevelManager manager;
    private PlayerBehaviour player;
    public Transform canvasPause;
    public GameObject canvasGameplay;

    private AudioPlayer audioPlayer;

    void Start()
    {
        AudioManager.Initialize();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();

        audioPlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioPlayer>();

        //metalBox = GameObject.FindGameObjectWithTag("MetalBox").GetComponent<BoxBehaviour>();
        //woodBox = GameObject.FindGameObjectWithTag("WoodBox").GetComponent<BoxBehaviour>();
    }

    void Update()
    {
        InputAxis();
        InputJump();
        InputRun();
        InputAbility();
        InputPause();
        InputGod();
        //InputLevelManager();
    }
    
    void InputPause()
    {
        /*if(Input.GetButtonDown("Pause"))
        {
            Debug.Log("Pause");
            // Pausar el juego
            if(canvasPause.gameObject.activeInHierarchy == false)
            {
                //canvasPause.gameObject.SetActive(true);
                //canvasGameplay.SetActive(false);
                Time.timeScale = 0;
                audioPlayer.StopMusic();
                audioPlayer.PlayMusic(1);
            }
            else
            {
                //canvasPause.gameObject.SetActive(false);
                //canvasGameplay.SetActive(true);
                Time.timeScale = 1;
                audioPlayer.StopMusic();
                audioPlayer.PlayMusic(0);
            }
        }*/
    }
    void InputGod()
    {
        if(Input.GetKeyDown(KeyCode.F10))
        {
            Debug.Log("GOD");
            player.SetGod();
        }
    }
}
