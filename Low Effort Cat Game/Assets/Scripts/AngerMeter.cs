using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AngerMeter : MonoBehaviour
{
    public Image angerMeter;

    public MenuManager menuManager;

    public static float targetAngerAmount;
    private float angerAmount;
    public float maxAnger;
    public float moveSpeed;

    private void Start()
    {
        targetAngerAmount = 0;
    }

    private void Update()
    {
        angerMeter.fillAmount = angerAmount / maxAnger;
        angerAmount = Mathf.Lerp(angerAmount, targetAngerAmount, moveSpeed * Time.deltaTime);

        if(targetAngerAmount < 0)
        {
            targetAngerAmount = 0;
        }

        if (angerAmount >= maxAnger)
        {
            menuManager.Lose();
        }
    }
}
