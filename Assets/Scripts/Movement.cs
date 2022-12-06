using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D body;
    private float horizontal;
    private float vertical;
    public float runSpeed = 20.0f;
    private Animator _animator;
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        if (body.velocity == Vector2.zero)
        {
            _animator.SetBool("Moving",false);
            if (_audio.isPlaying)
            {
                _audio.Play();
            }
        }
        else
        {
            _animator.SetBool("Moving",true);
            if (_audio.isPlaying == false)
            {
                _audio.Stop();
            }
        }
    }
}
