using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ShiftOver : MonoBehaviour
    {
        public void Menu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}