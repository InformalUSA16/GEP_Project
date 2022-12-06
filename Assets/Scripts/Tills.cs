using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tills : MonoBehaviour
{
    private AudioSource _audio;

    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float WaitTimeCountdown = -1f;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
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
