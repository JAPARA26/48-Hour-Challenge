using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    
    public float speed;
    public Transform player;
 

    private void Start()
    {
        
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    private void Update()
    {
        targetplayer();
    }

    void targetplayer()
    {
        if(transform.position.x + 1 < player.position.x)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x,transform.position.y, -15), speed * Time.deltaTime);
        }else if(transform.position.x - 1 > player.position.x)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, transform.position.y, -15), speed * Time.deltaTime);
        }
        if(transform.position.y + 1 < player.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.position.y, -15), speed * Time.deltaTime);
        }else if(transform.position.y - 1 > player.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.position.y,-15), speed * Time.deltaTime);
        }
    }

}
