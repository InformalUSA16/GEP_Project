using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ShiftTimer : MonoBehaviour
    {
        public float startTime;
        public float endTime;
        private float duration;

        
        private void Start()
        {
            duration = (endTime - startTime)*60;
        }

        private void Update()
        {
            duration -= Time.deltaTime;
            if (duration<0f)
            {
                SceneManager.LoadScene("ShiftOver");
            }
        }
    }
}