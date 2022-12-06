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

        private void Update()
        {
            if (currentValue < 100)
            {
                currentValue += _speed * Time.deltaTime;
            }
            _image.fillAmount = currentValue / 100;
        }
    }
}