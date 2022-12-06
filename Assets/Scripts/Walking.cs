using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class Walking : MonoBehaviour
    {
        [SerializeField]private AudioClip _audio;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            
        }

        private void Update()
        {
            if (_audio != null && _animator.GetBool("Moving"))
            {
                _audio.LoadAudioData();
            }else
            {
                _audio.UnloadAudioData();
            }
        }
    }
}