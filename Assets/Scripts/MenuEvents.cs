using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuEvents : MonoBehaviour
{
    public Button[] buttons;

    public Slider volumeSlider;
    public AudioMixer mixer;

    void Start(){
        AudioManager.instance.Play("Music");
    }


    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }

    
    private void Awake(){
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i=0; i < buttons.Length; i++){
            buttons[i].interactable = false;
        }
        for(int i=0; i < unlockedLevel; i++){
            buttons[i].interactable = true;
        }
    }

    
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1.0f;
        PlayerManager.isGameWin = false;
        PlayerManager.lastCheckPointPos = new Vector2 (0, 0);
        

    }
}
