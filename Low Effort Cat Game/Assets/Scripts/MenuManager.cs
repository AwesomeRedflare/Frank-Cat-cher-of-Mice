using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name != "LoseScreen")
        {
            FindObjectOfType<AudioManager>().Play("song");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("womp");
        }
    }

    public void StartButton()
    {
        FindObjectOfType<AudioManager>().Play("Meow");
        Transition();
        Invoke("GoToGame", 1f);
    }

    void Transition()
    {
        transition.SetTrigger("Exit");
    }

    void GoToGame()
    {
        SceneManager.LoadScene("LivingRoom");
    }

    public void Lose()
    {
        Transition();
        Invoke("GoToLoseScreen", 1f);
    }

    void GoToLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void Menu()
    {
        FindObjectOfType<AudioManager>().Play("Meow");
        Transition();
        Invoke("GoToMenu", 1f);
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
