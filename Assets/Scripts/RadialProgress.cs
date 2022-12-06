using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class RadialProgress : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private float _speed = 5f;
        private float currentValue;
        private bool _beingFaced=false;

        private void Start()
        {
            _image.fillAmount = 0;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.CompareTag("Player"))
            {
                Debug.Log("Facing");
                _beingFaced = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                _beingFaced = false;
            }
        }

        private void Update()
        {
            
            if (_beingFaced)
            {
                if (currentValue < 100)
                {
                    currentValue += _speed * Time.deltaTime;
                }
                _image.fillAmount = currentValue / 100;
            }
        }
    }
}