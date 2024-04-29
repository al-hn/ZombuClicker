using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGames : MonoBehaviour
{
    [SerializeField ] GameObject PausePanel;
    [SerializeField ] GameObject Zombu;
    [SerializeField ] GameObject ZombuText;
   
   private void Update()
 {
     HandlePause();
 }
 void HandlePause()
 {
     if(Input.GetKeyDown(KeyCode.Escape))
     {
         PauseGame();
     }
 }
    public void PauseGame(){
        PausePanel.SetActive(true);
        PausePanel.SetActive(false);
        PausePanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void Pause(){
        Time.timeScale = 0; 
    }
    public void Continue(){
        Time.timeScale = 1;
    }
    public void ContinueGame(){
        PausePanel.SetActive(false);
        Zombu.SetActive(true);
        ZombuText.SetActive(true);
        Time.timeScale = 1;
    }
   public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
