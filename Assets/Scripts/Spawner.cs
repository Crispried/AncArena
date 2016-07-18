using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {

        public static void Spawn(GameObject gameObject, Vector3 spawnPosition)
        {
            Instantiate(gameObject, spawnPosition, Quaternion.identity);
        }
    }
}
