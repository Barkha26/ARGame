using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainController : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    public GameObject Path1;
    public GameObject Path2;

    public Transform[] Waypoints;

    AudioSource audioSource;     
 
    //Make sure you attach a Rigidbody in the Inspector of this GameObject
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;

    
    PlayerController Player;

    void Start()
    {
        // StartCoroutine(init());
        Debug.Log(gameObject.name);
        audioSource = transform.parent.GetComponent<AudioSource>();
        Speed = GameManager.Instance.MountainSpeed;

        //Set the axis the Rigidbody rotates in (100 in the y axis)
        m_EulerAngleVelocity = new Vector3(0, Speed, 0);

        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        Player = GameManager.Instance.Player.GetComponent<PlayerController>();
    }
    /*IEnumerator init()
    {

        while (GameManager.Instance.MountainSpeed == 0)
        {
            yield return null;
        }

        Speed = GameManager.Instance.MountainSpeed;
        //Set the axis the Rigidbody rotates in (100 in the y axis)
        m_EulerAngleVelocity = new Vector3(0, Speed, 0);

    }*/
    void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameManager.GameStates.START && Player.IsFalling == false) {
            Debug.Log("##: fixedUpdateMountain");
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime );
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);   

            if (!audioSource.isPlaying) {               
                audioSource.Play();
            }
        }        
    }
}
