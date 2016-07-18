using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        [Tooltip("How much mobs will spawn")]
        public int MobSpawnAmount = 10;

        GameObject[] mobs;

        GameObject[] aliveMobs;

        GameObject character;

        GameObject arena;

        float minXPosition, maxXPosition, minZPosition, maxZPosition;

        Vector3 spawnPlace;

        void Awake()
        {
            character = GameObject.FindGameObjectWithTag("Character");
            mobs = new GameObject[1];
            DetermineRelativeSpawnPosition();
            GenerateRandomSkybox();
        }

        void Update()
        {
            SpawnMobs();
            GameOver();
        }

        void SpawnMobs()
        {
            mobs[0] = Resources.Load("Mobs/MobExecuter") as GameObject;
            aliveMobs = GameObject.FindGameObjectsWithTag("Mob");
            if (aliveMobs.Length == 0)
            {
                for (int i = 0; i < MobSpawnAmount; i++)
                {
                    spawnPlace = new Vector3(Random.Range(minXPosition, maxXPosition), 1, Random.Range(minZPosition, maxZPosition));
                    int j = Random.Range(0, 1);
                    Spawner.Spawn(mobs[j], spawnPlace);
                }
            }
        }

       void GameOver()
        {
            if (character == null)
            {
                SceneManager.LoadScene("scene1");
            }
        }

        void GenerateRandomSkybox()
        {
            int randomForSkybox = Random.Range(0, 3);
            switch (randomForSkybox)
            {
                case 0:
                    RenderSettings.skybox = Resources.Load("Skybox/forest") as Material;
                    break;
                case 1:
                    RenderSettings.skybox = Resources.Load("Skybox/mossymountains") as Material;
                    break;
                case 2:
                    RenderSettings.skybox = Resources.Load("Skybox/sunset") as Material;
                    break;
            }
        }

        void DetermineRelativeSpawnPosition()
        {
            // init respawn place relatively arena.position
            arena = GameObject.FindGameObjectWithTag("Arena");
            maxXPosition = arena.transform.localScale.x / 2 - 5 + arena.transform.position.x;
            minXPosition = -maxXPosition + 2 * arena.transform.position.x;
            maxZPosition = arena.transform.localScale.z / 2 - 5 + arena.transform.position.z;
            minZPosition = -maxZPosition + 2 * arena.transform.position.z;
        }

        public void OpenMainMenu()
        {
            SceneManager.LoadScene("Scenes/StartMenu", LoadSceneMode.Single);
        }

        public void PauseGame()
        {
            foreach (var item in FindObjectsOfType<Canvas>())
            {
                if(item.name != "GamePause")
                {
                    item.enabled = false;
                }
            }
            Time.timeScale = 0;
        }

        public void RestoreGame()
        {
            foreach (var item in FindObjectsOfType<Canvas>())
            {
                item.enabled = true;
            }
            Time.timeScale = 1;
        }
    }

}
