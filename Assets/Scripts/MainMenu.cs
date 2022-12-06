using UnityEngine;
using UnityEngine.SceneManagement;
using static DefaultNamespace.ShiftTimer;

namespace DefaultNamespace
{
    public class MainMenu : MonoBehaviour
    {
        
        public void shiftStart()
        {
            
        }
        public void play()
        {
            SceneManager.LoadScene("MainGame");
        }
        public void quit()
        {
            Application.Quit();
        }
    }
}