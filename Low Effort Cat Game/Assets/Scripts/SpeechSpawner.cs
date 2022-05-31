using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechSpawner : MonoBehaviour
{
    public GameObject speechBubble;
    public GameObject spikeBubble;
    public Transform speechPoint;

    public void SpawnBubble()
    {
        Vector2 point = new Vector2(speechPoint.position.x, Random.Range(3f, -4f));

        Instantiate(speechBubble, point, Quaternion.identity, speechPoint);
    }

    public void SpawnSpikeBubble()
    {
        Vector2 point = new Vector2(speechPoint.position.x, Random.Range(3f, -4f));

        Instantiate(spikeBubble, point, Quaternion.identity, speechPoint);
    }
}
