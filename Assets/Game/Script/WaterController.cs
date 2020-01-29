using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public Transform Environment;   
    public Transform Base;
    public PlayerController Player;

    [SerializeField]
    private float Speed;

    AudioSource audioSource;
   public AudioClip GameOverClip;

    Animator animator;
    public GameObject Tile;

    private IEnumerator Start()
    {
        audioSource = Environment.GetComponent<AudioSource>();
        while (GameManager.Instance.WaterSpeed == 0)
        {
            yield return null;
        }
        Speed = GameManager.Instance.WaterSpeed;
        animator = GameManager.Instance.Player.GetComponent<Animator>();
        Tile.SetActive(true);
    }


    void Update()
    {
        
        if (GameManager.Instance.gameState == GameManager.GameStates.START && Player.IsFalling == false) {
          //  Debug.Log("##: fixedUpdatewater");
            // Environment.Translate(Vector3.down * Time.deltaTime * speed);
            Base.Translate(Vector3.up * Time.deltaTime * Speed);

            //increase speed gradually             reduce the rate of change of speed
            //speed += Time.deltaTime/2000;               

            //decrease the speed gradually
           // Speed -= Time.deltaTime / 2;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.name.Equals("Player"))
        {
            Debug.Log("waterinteraction");
            GameManager.Instance.gameState = GameManager.GameStates.LOOSE;
            audioSource.loop = false;
            audioSource.volume = 1;
            audioSource.clip = GameOverClip;
            audioSource.Play();
            
            animator.SetBool("Run", false);
            animator.SetBool("Hit", true);
            animator.SetBool("Slide", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
            GameManager.Instance.Player.GetComponent<Rigidbody>().useGravity = true;
            GameManager.Instance.Player.GetComponent<CapsuleCollider>().direction = 2;
        }
    }

}
