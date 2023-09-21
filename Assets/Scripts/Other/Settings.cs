using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider fxSlider;

    private float masterVolume;
    private float musicVolume;
    private float fxVolume;

    public bool isMainMenu = false;

    private int loadSceneIndex = 1;


    //-------------------------------------------------------------------------------------------------------------------

    private void Start() {
        Load();
    }

    //-------------------------------------------------------------------------------------------------------------------

    public void StartGame(){SceneManager.LoadScene(loadSceneIndex);}
    public void ExitToMenu(){SceneManager.LoadScene(0);Save();}
    public void QuitGame(){Application.Quit();}

    //-------------------------------------------------------------------------------------------------------------------

    public void SetVolume_Master(float _v){
        this.masterVolume = _v;
        mixer.SetFloat("MasterVolume",masterVolume);
        Save();
    }
    public void SetVolume_Music(float _v){
        this.musicVolume = _v;
        mixer.SetFloat("MusicVolume",musicVolume);
        Save();
    }
    public void SetVolume_FX(float _v){
        this.fxVolume = _v;
        mixer.SetFloat("FXVolume",fxVolume);
        Save();
    }

    //-------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------

    private void Save(){
        PlayerPrefs.SetFloat("MasterVolume",masterVolume);
        PlayerPrefs.SetFloat("MusicVolume",musicVolume);
        PlayerPrefs.SetFloat("FXVolume",fxVolume);

        if(!isMainMenu){
            PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Load(){
        
        //Get
        if(PlayerPrefs.HasKey("MasterVolume")) masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        else masterVolume = -15f;

        if(PlayerPrefs.HasKey("MusicVolume")) musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        else musicVolume = -15f;

        if(PlayerPrefs.HasKey("FXVolume")) fxVolume = PlayerPrefs.GetFloat("FXVolume");
        else fxVolume = -15f;

        if(!isMainMenu){
            
            if(PlayerPrefs.HasKey("Scene")) loadSceneIndex = PlayerPrefs.GetInt("Scene");
            else loadSceneIndex = 1;
            
        }



        //Load

        masterSlider.value = masterVolume;
        musicSlider.value = musicVolume;
        fxSlider.value = fxVolume;

        mixer.SetFloat("MasterVolume",masterVolume);
        mixer.SetFloat("MusicVolume",musicVolume);
        mixer.SetFloat("FXVolume",fxVolume);


        Save();

    }

}
