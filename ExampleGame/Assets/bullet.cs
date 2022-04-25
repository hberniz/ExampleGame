using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.GetComponent<Collider>().tag == "Player")
        {
            StartCoroutine(GameObject.FindObjectOfType<GameControl>().ResetToSpawn());
        }
    }

    }
