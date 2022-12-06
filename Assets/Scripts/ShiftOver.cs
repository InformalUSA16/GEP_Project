using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ShiftOver : MonoBehaviour
    {
        public void returntomenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}