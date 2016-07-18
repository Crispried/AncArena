using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Scenes/scene1", LoadSceneMode.Single);
        }
    }
}
