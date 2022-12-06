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
    private AudioSource _walkingAudio;

    // Start is called before the first frame update
    void Start()
    {
        _walkingAudio = GetComponent<AudioSource>();
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
            if (_walkingAudio.isPlaying)
            {
                _walkingAudio.Play();
            }
            transform.rotation.Set(0,0,0,0);
        }
        else
        {
            _animator.SetBool("Moving",true);
            if (_walkingAudio.isPlaying == false)
            {
                _walkingAudio.Stop();
            }
            transform.rotation.Set(0,0,0,0);
        }
    }
}
