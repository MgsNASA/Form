using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.Networking;


public class GameRegim : MonoBehaviour
{
    [DllImport("__Internal")]
   private static extern void ShowAdv();

   [DllImport("__Internal")]
   private static extern void RestartGameAdExtern();
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    public HeartBar heartbar;
    public GameObject castle;
    public GameObject[] EnemyObject;
    public GameObject StartUi;
    public GameObject GamePlayUI;
    public AudioSource GamePlayAudio;
    public GameObject Heart;
    public GameObject image;
    public GameObject LoseUI;
    public AudioSource audioSource;
    public WaveSpawner waveSpawner;
    public int checkWave;
    public bool IsWork = true;
    private void Start()
    {

        
        ShowAdv();

        waveSpawner = GetComponent<WaveSpawner>();
    }
    public void StartGame()
    {
      
        DataHolder.StartGame = true;
        StartUi.SetActive(false);
        GamePlayUI.SetActive(true);
        Heart.SetActive(true);
        image.SetActive(true);
        LoseUI.SetActive(false);

    }
    public void Lose()
    {
      
            checkWave = waveSpawner.currWave;
            audioSource.Play();
            DataHolder.StartGame = false;
            GamePlayUI.SetActive(false);
            Heart.SetActive(false);
            image.SetActive(false);
            LoseUI.SetActive(true);
            
    }
    public void Restart()
    {
#if UNITY_WEBGL
       
       
#endif
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DataHolder.Money = 0;
        ShowAdv();

    }
    public void Continio()
    {
        castle.GetComponent<Animator>().SetBool("GameOver", false);
        foreach (GameObject go in EnemyObject)
        {
            go.SetActive(false);
        }

        LoseUI.SetActive(false);
        GamePlayUI.SetActive(true);
        Heart.SetActive(true);
        image.SetActive(true);
        castle.GetComponent<Health>().currentHealth = 1000;
        heartbar.GetComponent<HeartBar>().SetHealth(1000);
        DataHolder.StartGame = true;
        castle.GetComponent<Animator>().SetBool("GameOver", false);

    }
    private void Update()
    {
        
            EnemyObject = GameObject.FindGameObjectsWithTag("Enemy");
       
    }
    public void showAdvButton()
    {

        // Continio();
      //  castle.GetComponent<Animator>().SetBool("GameOver", false);
        RestartGameAdExtern();
        castle.GetComponent<Animator>().SetBool("GameOver", false);
    }
}
