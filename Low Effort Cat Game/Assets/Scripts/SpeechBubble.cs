using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    private Text text;
    private Animator anim;

    public string[] words;

    private void Start()
    {
        anim = GetComponent<Animator>();

        text = GetComponentInChildren<Text>();

        text.text = words[Random.Range(0, words.Length)];

        Invoke("BubbleOut", 2f);
        Destroy(gameObject, 3f);
    }

    void BubbleOut()
    {
        anim.SetTrigger("out");
    }
}
