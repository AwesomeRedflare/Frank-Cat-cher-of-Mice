using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHole : MonoBehaviour
{
    public GameObject mouse;

    private float mouseTimer;
    private float timeBtwMouse;
    public float minMouseTime;
    public float maxMouseTime;
    public float difficulty;

    private void Start()
    {
        timeBtwMouse = Random.Range(minMouseTime, maxMouseTime);
        mouseTimer = timeBtwMouse;
    }

    private void Update()
    {
        if(mouseTimer <= 0)
        {
            Instantiate(mouse, transform.position, Quaternion.identity);

            timeBtwMouse = Random.Range(minMouseTime, maxMouseTime);
            if(maxMouseTime > minMouseTime + 1)
            {
                maxMouseTime -= difficulty;
            }

            mouseTimer = timeBtwMouse;
        }
        else
        {
            mouseTimer -= Time.deltaTime;
        }
    }
}
