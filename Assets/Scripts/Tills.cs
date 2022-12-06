using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tills : MonoBehaviour
{
    private AudioSource _audio;
    public BoxCollider2D tills;

    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float WaitTimeCountdown = -1f;

    private bool AtTills;
    // Start is called before the first frame update
    void Start()
    {
        AtTills = false;
        _audio = GetComponent<AudioSource>();
        tills = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AtTills == false)
        {
            if (!_audio.isPlaying)
            {
                if (WaitTimeCountdown<0f)
                {
                    _audio.Play();
                    WaitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
                }else
                {
                    WaitTimeCountdown -= Time.deltaTime;
                }
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Debug.Log("At tills");
            AtTills = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            AtTills = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("Leaving tills");
            AtTills = false;
            WaitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
        }
    }
}
