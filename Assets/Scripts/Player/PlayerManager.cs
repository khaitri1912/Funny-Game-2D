using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isGameWin;


    public GameObject gameOverScreen;
    public GameObject gameFinishPanel;

    public GameObject pauseMenuPanel;


    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;


    public static Vector2 lastCheckPointPos = new Vector2(0,0);



    [SerializeField] CinemachineVirtualCamera VCam;
    [SerializeField] GameObject[] playPrefabs;
    int characterIndex;

    

    private void Awake()
    {
        //AudioManager.instance.Play("Music");
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;

        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        isGameWin = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Music");
        lastCheckPointPos = new Vector2(0, 0);
        gameFinishPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
        if (isGameWin)
        {
            gameFinishPanel.SetActive(true);
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
        AudioManager.instance.Play("Click");
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        AudioManager.instance.Play("Click");
    }


    public void Home()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.Play("Click");
    }



    public void ReplayLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        
        AudioManager.instance.Play("Click");
    }

    public void Level02()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        lastCheckPointPos = new Vector2(0,0);
        AudioManager.instance.Play("Click");
    }
    
    
    public void LevelFinal()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        lastCheckPointPos = new Vector2(0,0);
        AudioManager.instance.Play("Click");
    }
}
