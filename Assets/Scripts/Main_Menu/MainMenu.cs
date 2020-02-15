using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
