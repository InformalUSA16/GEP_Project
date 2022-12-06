using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tills : MonoBehaviour
{
    private AudioSource _audio;
    public BoxCollider2D tills;

    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float WaitTimeCountdown = -1f;
    private bool Losing;
    private bool AtTills;
    [SerializeField] private Image _image;
    private float _speed = 5f;

    private float currentValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        AtTills = false;
        Losing = false;
        _audio = GetComponent<AudioSource>();
        tills = GetComponent<BoxCollider2D>();
        _image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Losing)
        {
            if (AtTills == false)
            {
                if (!_audio.isPlaying)
                {
                    if (WaitTimeCountdown < 0f)
                    {
                        _audio.Play();
                        Losing = true;
                        WaitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
                    }
                    else
                    {
                        WaitTimeCountdown -= Time.deltaTime;
                    }
                }
            }
        }

        if (Losing)
        {
            if (currentValue < 100)
            {
                currentValue += _speed * Time.deltaTime;
            }

            _image.fillAmount = currentValue / 100;
        }
        else
        {
            currentValue = 0f;
        }

        if (currentValue >= 100)
        {
            SceneManager.LoadScene("Fired");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Debug.Log("At tills");
            AtTills = true;
            Losing = false;
            _image.fillAmount = 0;
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
    