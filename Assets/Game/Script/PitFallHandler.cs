using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFallHandler : MonoBehaviour
{
    PlayerController Player;

    void Start()
    {
        Player = GameManager.Instance.Player.GetComponent<PlayerController>();
    } 

    private void OnTriggerEnter(Collider other)
    {       
        if (other.name.Equals("Player"))
        {
          // Debug.Break();
            Debug.Log("digg");
            Player.IsFalling = true;
            //isJump = false;            
            //if (fallCor == null)
            //{
            //    fallCor = fallHandle();
            //    StartCoroutine(fallCor);
            //}
        }
    }
}
