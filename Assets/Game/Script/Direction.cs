using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public bool isForward, isBackword, isHead,isFoot;
    public PlayerController PC_Instance;

    void Start()
    {

    }


    void OnTriggerEnter(Collider ob)
    {
        if (ob.gameObject.tag == "Obstacle" && isForward)
        {
            print("Forward enter");
    //        PC_Instance.direction = "Forward";
        }
        else if (ob.gameObject.tag == "Obstacle" && isBackword)
        {
            print("Backword enter");
     //       PC_Instance.direction = "Backword";
        }

        if (ob.gameObject.tag == "Obstacle" && isHead)
        {
            print("Head enter");
    //        PC_Instance.TouchedPart = "Head";
        }
        else if (ob.gameObject.tag == "Obstacle" && isFoot)
        {
            print("Foot enter");
        //    PC_Instance.TouchedPart = "Foot";
        }

    }

    private void OnTriggerStay(Collider ob)
    {
        if (ob.gameObject.tag == "Obstacle" && isForward)
        {
            print("Forward stay");
     //       PC_Instance.direction = "Forward";
        }
        else if (ob.gameObject.tag == "Obstacle" && isBackword)
        {
            print("Backword stay");
     //       PC_Instance.direction = "Backword";
        }

        if (ob.gameObject.tag == "Obstacle" && isHead)
        {
            print("Head stay");
    //        PC_Instance.TouchedPart = "Head";
        }
        else if (ob.gameObject.tag == "Obstacle" && isFoot)
        {
            print("Foot stay");
    //        PC_Instance.TouchedPart = "Foot";
        }
    }

    private void OnTriggerExit(Collider ob)
    {
        if (ob.gameObject.tag == "Obstacle" && isForward)
        {
            print("Forward exit");
     //       PC_Instance.direction = "";
        }
        else if (ob.gameObject.tag == "Obstacle" && isBackword)
        {
            print("Backword exit");
    //        PC_Instance.direction = "";
        }

        if (ob.gameObject.tag == "Obstacle" && isHead)
        {
            print("Head exit");
    //        PC_Instance.TouchedPart = "";
        }
        else if (ob.gameObject.tag == "Obstacle" && isFoot)
        {
            print("Foot exit");
    //        PC_Instance.TouchedPart = "";
        }
    }
}
