using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadARGame : MonoBehaviour
{
    public bool isInARGame = false;
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;
    float Speed;

    public void Start()
    {
        Speed = GameManager.Instance.MountainSpeed;

        //Set the axis the Rigidbody rotates in (100 in the y axis)
        m_EulerAngleVelocity = new Vector3(0, -Speed, 0);

        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    public void Reload()
    {
        SceneManager.LoadScene("MainGame");
    }

    void FixedUpdate()
    {
        if (isInARGame)
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }
    }
}
