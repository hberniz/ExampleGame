using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject respawnPosition;
    // Start is called before the first frame update
    private HideScript hide;

    void Start()
    {
        hide = GameObject.FindObjectOfType<HideScript>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            hide.hidePlayer(player);
        }
    }

    public IEnumerator ResetToSpawn()
    {
        player.GetComponent<PlayerMove>().disabled = true;

        yield return new WaitForSeconds(.01f);
        player.transform.position = respawnPosition.transform.position;
        player.transform.rotation = respawnPosition.transform.rotation;
        yield return new WaitForSeconds(.01f);
        player.GetComponent<PlayerMove>().disabled = false;
    }

}
