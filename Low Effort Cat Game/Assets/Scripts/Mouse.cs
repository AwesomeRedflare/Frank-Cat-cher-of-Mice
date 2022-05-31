using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cheeses;
    private GameObject[] holes;
    private Transform target;
    private Transform returnHole;

    private float speed;
    public float minSpeed;
    public float maxSpeed;

    private bool gotCheese;

    private SpeechSpawner speechSpawner;
    private ShakeBehavior shakeBehavior;

    private Animator anim;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("squeak");
        anim = GetComponent<Animator>();

        if(Score.scoreAmount > 0)
        {
            minSpeed += (1 + (Score.scoreAmount / 10));
            maxSpeed += (1 + (Score.scoreAmount / 10));
        }

        speechSpawner = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SpeechSpawner>();
        shakeBehavior = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShakeBehavior>();

        speed = Random.Range(minSpeed, maxSpeed);
        cheeses = GameObject.FindGameObjectsWithTag("Cheese");
        holes = GameObject.FindGameObjectsWithTag("Hole");

        target = cheeses[Random.Range(0, 3)].transform;
        returnHole = holes[Random.Range(0, 3)].transform;
    }

    private void Update()
    {
        if (!gotCheese)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, target.position) < .1f)
            {
                gotCheese = true;
                anim.SetBool("cheese", true);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, returnHole.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, returnHole.position) < .1f)
            {
                AngerMeter.targetAngerAmount++;
                speechSpawner.SpawnSpikeBubble();
                FindObjectOfType<AudioManager>().Play("grrr");
                shakeBehavior.TriggerShake();
                Destroy(gameObject);
            }
        }
    }
}
