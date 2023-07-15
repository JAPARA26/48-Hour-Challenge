using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{

    
    #region Variable
    public float speed;
    public Transform player;
    #endregion
   
    #region Function

    private void Start()
    {
        
        if (GameObject.FindGameObjectWithTag("Point") != null)
        {
            player = GameObject.FindGameObjectWithTag("Point").transform;
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
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x,transform.position.y, -10), speed * Time.deltaTime);
        }else if(transform.position.x - 1 > player.position.x)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, transform.position.y, -10), speed * Time.deltaTime);
        }
        if(transform.position.y  < player.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.position.y, -10), speed * Time.deltaTime);
        }else if(transform.position.y > player.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.position.y,-10), speed * Time.deltaTime);
        }
    }
    #endregion
}
