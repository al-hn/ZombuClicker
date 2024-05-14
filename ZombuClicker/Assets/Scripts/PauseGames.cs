using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class PauseGames : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject Zombu;
    [SerializeField] GameObject ZombuText;
    public CloudSaving cloudSaving;

    private const int GetMoneyAdId = 1;

    void Start()
    {
        cloudSaving = GameObject.Find("CloudSavings").GetComponent<CloudSaving>();
        YandexGame.FullscreenShow();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    
    private void Update()
    {
        HandlePause();
    }
    void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        PausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void ContinueGame()
    {
        PausePanel.gameObject.SetActive(false);
        Zombu.gameObject.SetActive(true);
        ZombuText.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
    public void BackToMenu()
    {
        cloudSaving.DefaultVariables();
        // Company of Heroes 3
        cloudSaving.MySave();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("MainMenu");
    }
    public void Play()
    {
        // await Task.Delay((int)(1.0f * 1000));
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("infdev");
    }

}
