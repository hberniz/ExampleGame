using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideScript : MonoBehaviour
{
    [SerializeField] private GameObject eToHide;
    [SerializeField] private GameObject eToReapper;
    private Vector3 positionBeforeHiding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter (Collider collisionInfo)
    {
        if(collisionInfo.GetComponent<Collider>().tag == "Player")
        {
            eToHide.SetActive(true);
        }
        //eToHide.SetActive(false);
    }
    void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.GetComponent<Collider>().tag == "Player")
            eToHide.SetActive(false);
    }

    public void hidePlayer(GameObject player)
    {
        if (eToHide.activeSelf)
        {
            //hide player
            positionBeforeHiding = player.transform.position;
            player.GetComponent<PlayerMove>().disabled = true;
            player.SetActive(false);
            eToHide.SetActive(false);
            eToReapper.SetActive(true);
            return;
        }else if (eToReapper.activeSelf)
        {
            player.GetComponent<PlayerMove>().disabled = false;
            player.SetActive(true);
            eToReapper.SetActive(false);
            eToHide.SetActive(true);
            Debug.Log("Im pressing to reappear");
            return;
        }
        return;
    }
}
