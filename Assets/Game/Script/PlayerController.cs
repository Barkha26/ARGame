using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip JumpClip;
    public AudioClip SlideClip;
    public AudioClip FallClip;
    public AudioClip GameOverClip;

    public float scaleConstants = 1f;//divide by 1000 because scale of game is 0.001

    public enum PlayerStates { IDLE, RUN, JUMP, DUCK, FALL, HIT };
    public PlayerStates playerState;
   
    public int index;
    Rigidbody rigidBody;   
    CapsuleCollider capCollider;
  
    [SerializeField]
    private float MoveSpeed;

    private MountainController mountainController;
    //private DynamicAssets mountainController;

    Animator animator;    

    float lerpValue = 0;
    float playerYpos;
    public bool isGrounded = false;
    bool isJump = false;

    [HideInInspector]
   public bool IsFalling = false;

    IEnumerator jumpCoroutine = null;
    IEnumerator fallCor = null;
    bool movingDown = false;
  
    bool onceRun = false;

    bool isSliding = false;

    float prev_playerYPos; //player's y position before jump is clicked
  
    void Start()
    {
        index = 0;
        rigidBody = GetComponent<Rigidbody>();
        capCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        playerState = PlayerStates.IDLE;
        animator.SetBool("Run", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Slide", false);
        animator.SetBool("Jump", false);
        playerYpos = transform.position.y;

        StartCoroutine(init());       
    }

    IEnumerator init() {

        while (GameManager.Instance.PlayerSpeed == 0 ) {          
            yield return null;
        }

        MoveSpeed = GameManager.Instance.PlayerSpeed;
        mountainController = GameManager.Instance.Mountain.GetComponent<MountainController>();
      //  mountainController = GameManager.Instance.Mountain.transform.GetChild(0).transform.GetChild(2).GetComponent<DynamicAssets>();
    }    
   
    void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameManager.GameStates.START && IsFalling == false)
        {           
            if (index < mountainController.Waypoints.Length - 1)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
                {
                    if (hit.collider.name.Equals("Path"))
                    {                     
                        if (isGrounded == true && isJump == true && movingDown == true)
                        { 
                            onceRun = false;
                            animator.SetBool("Jump", false);

                            isJump = false;
                            movingDown = false;

                            if (jumpCoroutine != null)
                            {
                                Debug.Log("2");
                                Debug.Log("2_JumpTime: " + (Time.time - t));
                                StopCoroutine(jumpCoroutine);
                                jumpCoroutine = null;
                            }
                        }
                    }

                }
               
                if (isHit == false )
                {
                 //   Debug.Log("lerping");
                    if (onceRun == false)
                    {
                        onceRun = true;
                        animator.SetBool("Run", true);
                        animator.SetBool("Hit", false);
                        animator.SetBool("Slide", false);
                        animator.SetBool("Jump", false);

                    //  animator.speed = MoveSpeed/2;
                        // animation["Run"].speed = MoveSpeed;
                    }
                    
                    lerpValue += Time.deltaTime * MoveSpeed;
                    if (lerpValue < 1)
                    {
                        //move from one waypoint to another
                        Vector3 temp = Vector3.Slerp(mountainController.Waypoints[index].position, mountainController.Waypoints[index + 1].position, lerpValue);

                        if (isJump == false )
                        {
                          //  Debug.Log("y changed : ");
                            playerYpos = temp.y;
                            prev_playerYPos = playerYpos;
                        }

                        temp = new Vector3(temp.x, playerYpos, temp.z);
                        rigidBody.MovePosition(temp);

                        //rotate from one waypoint to another
                        Quaternion tempRotation = Quaternion.Slerp(mountainController.Waypoints[index].rotation, mountainController.Waypoints[index + 1].rotation, lerpValue);
                        rigidBody.MoveRotation(tempRotation);
                    }
                    else
                    {                      
                        //update index for next waypoint
                        index = index + 1;
                        lerpValue = 0;
                    }
                }
                
            }
            else
            {
                GameManager.Instance.gameState = GameManager.GameStates.WIN;
                animator.SetBool("Run", false);
                animator.SetBool("Hit", false);
                animator.SetBool("Slide", false);
                animator.SetBool("Jump", false);
                animator.SetBool("win", true);
            }
        }
        else if (GameManager.Instance.gameState == GameManager.GameStates.LOOSE) {
            //animator.SetBool("Run", false);
            //animator.SetBool("Hit", false);
            //animator.SetBool("Slide", false);
            //animator.SetBool("Jump", false);
            //animator.SetBool("win", false);
        }

        //    if (IsFalling) {
        //    IsFalling = false;
        //    Debug.Log("digg");
        //    isJump = false;
        //     Debug.Log("FALL");
        //    playerYpos -= 50; //put lerp to towards ground here
        //    if (fallCor == null)
        //    {
        //        fallCor = fallHandle();
        //        StartCoroutine(fallCor);
        //    }
        //}
        
    }
    


    //IEnumerator fallHandle()
    //{
    //    //Debug.Break();
    //    // if (audioSource.isPlaying == false)
    //    {
    //        audioSource.PlayOneShot(FallClip);
    //    }

    //    animator.SetBool("Run", false);
    //    animator.SetBool("Hit", false);
    //    animator.SetBool("Slide", false);
    //    animator.SetBool("Jump", false);
    //    animator.SetBool("Fall", true);

    //    Vector3 start = transform.position;
    //    Vector3 end = new Vector3(transform.position.x, transform.position.y - (150 * scaleConstants), transform.position.z);  // change this constant according to the SCALE
    //    float temp = 0;

    //    while (temp < 1)
    //    { //check if not touched with water or not triggered with any waypoint
    //        Vector3 tempVec = Vector3.Slerp(start, end, temp);
    //        if (GameManager.Instance.gameState == GameManager.GameStates.START)
    //        {
    //            rigidBody.MovePosition(tempVec);
    //        }

    //        temp += Time.deltaTime * MoveSpeed;
    //        yield return null;
    //    }

    //    //transform.position = end;
    //    Debug.Log("end");
    //    while (GameManager.Instance.gameState == GameManager.GameStates.START) {
    //        yield return null;
    //    }

    //    if (fallCor != null)
    //    {
    //        StopCoroutine(fallCor);
    //        fallCor = null;
    //    }
    //}

    IEnumerator fallHandle()
    {
        Debug.Log("##: in fall handle");
        // if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(FallClip);
        }

        animator.SetBool("Run", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Slide", false);
        animator.SetBool("Jump", false);
        animator.SetBool("Fall", true);

        while (GameManager.Instance.gameState == GameManager.GameStates.START)
        {
         //   Debug.Log("##: in fall handleWhile");
            // rigidBody.MovePosition(transform.position + (- transform.up) * Time.deltaTime /5);
            transform.position += (-transform.up) * Time.deltaTime / 5;
            yield return null;
        }

        Debug.Log("end");

    }

    bool isHit = false;
    IEnumerator moveBackCor = null;

    public void OnCollisionEnter(Collision collision) {
       /* Debug.Log("1Name: "+ collision.collider.name);
        if (collision.collider.tag.Equals("Obstacle"))
        {            
            ContactPoint contactPoint = collision.contacts[0];
            Debug.Log("2Name: " + Mathf.Round(contactPoint.normal.y));
            if (Mathf.Round(contactPoint.normal.y) <= 0) {
             Debug.Break();
                Debug.Log("1111111111111111111111");
                isHit = true;
                //transform.position = new Vector3(transform.position.x, prev_playerYPos, transform.position.z);
                 rigidBody.useGravity = true;
                 capCollider.direction = 2;
                
                //capCollider.enabled = false;

                if (isJump == true)
                {
                    Debug.Log("00000000000000000000000");
                    isJump = false;
                    movingDown = false;
                    if (jumpCoroutine != null)
                    {
                        Debug.Log("6666666666666");
                        StopCoroutine(jumpCoroutine);
                        jumpCoroutine = null;
                    }
                }

                //do game over
                Debug.Log("3Name: " + collision.collider.name);
                GameManager.Instance.gameState = GameManager.GameStates.LOOSE;
                AudioSource BGAudioSource = transform.parent.GetComponent<AudioSource>();
                BGAudioSource.loop = false;
                BGAudioSource.volume = 1;
                BGAudioSource.clip = GameOverClip;
                BGAudioSource.Play();

                //move back to previous waypoint
                if (moveBackCor == null)
                {
                    moveBackCor = moveBackOnHit();
                    StartCoroutine(moveBackCor);
                }

                Debug.Log("7777777777");
                animator.SetBool("Run", false);
                animator.SetBool("Hit", true);
                animator.SetBool("Slide", false);
                animator.SetBool("Jump", false);
                animator.SetBool("Fall", false);                                          

                
            }              
        }*/

        if (collision.collider.name.Equals("Path"))
        {
            ContactPoint contactPoint = collision.contacts[0];
            if (Mathf.Round(contactPoint.normal.y) <= 1)
            {
                isGrounded = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
            Debug.Log("1Name: " + other.name);
            if (other.tag.Equals("Obstacle"))
            {
                    //Debug.Break();
                    Debug.Log("1111111111111111111111");
                    isHit = true;
                    //transform.position = new Vector3(transform.position.x, prev_playerYPos, transform.position.z);
                    rigidBody.useGravity = true;
                    capCollider.direction = 2;

                    //capCollider.enabled = false;

                    if (isJump == true)
                    {
                        Debug.Log("00000000000000000000000");
                        isJump = false;
                        movingDown = false;
                        if (jumpCoroutine != null)
                        {
                            Debug.Log("6666666666666");
                            StopCoroutine(jumpCoroutine);
                            jumpCoroutine = null;
                        }
                    }

                    //do game over
                    Debug.Log("3Name: " + other.name);
                    GameManager.Instance.gameState = GameManager.GameStates.LOOSE;
                    AudioSource BGAudioSource = transform.parent.GetComponent<AudioSource>();
                    BGAudioSource.loop = false;
                    BGAudioSource.volume = 1;
                    BGAudioSource.clip = GameOverClip;
                    BGAudioSource.Play();

                    //move back to previous waypoint
                    if (moveBackCor == null)
                    {
                        moveBackCor = moveBackOnHit();
                        StartCoroutine(moveBackCor);
                    }

                    Debug.Log("7777777777");
                    animator.SetBool("Run", false);
                    animator.SetBool("Hit", true);
                    animator.SetBool("Slide", false);
                    animator.SetBool("Jump", false);
                    animator.SetBool("Fall", false);                
            }

        if (other.tag.Equals("Dig"))
        {

            IsFalling = true;
            Debug.Log("##: TriggerDigEnter");
            isJump = false;

            if (fallCor == null)
            {
                Debug.Log("##: TriggerDigEnter: startcoroutine");
                mountainController.Path1.SetActive(false);
                mountainController.Path2.SetActive(false);
                fallCor = fallHandle();
                StartCoroutine(fallCor);
            }
        }
    }

    IEnumerator moveBackOnHit()
    {
        //move back to previous waypoint
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        //capCollider.height = capCollider.height / 10;
        // capCollider.center = new Vector3(capCollider.center.x, capCollider.center.y / 10, capCollider.center.z);
      
        float t = 0;
        while (t < 1)
        {
                Debug.Log("moving back");
                //move from one waypoint to another
                Vector3 temp = Vector3.Slerp(startPos, mountainController.Waypoints[index].position, t);
                playerYpos = temp.y;
                

                temp = new Vector3(temp.x, playerYpos, temp.z);
                rigidBody.MovePosition(temp);
                //rotate from one waypoint to another
                Quaternion tempRotation = Quaternion.Slerp(startRot, mountainController.Waypoints[index].rotation, t);
                rigidBody.MoveRotation(tempRotation);
            
            t += Time.deltaTime * MoveSpeed * 2;
            yield return null;

        }

        if (moveBackCor != null)
        {
            StopCoroutine(moveBackCor);
            moveBackCor = null;
        }
    }

    public void OnJump()
    {
       // Debug.Break();
        if (GameManager.Instance.gameState == GameManager.GameStates.START) {       
            Debug.Log("jump111111111");
            if (isJump == false)
            {
                //if falling then donot start jump
                if (fallCor == null) {
                    if (jumpCoroutine == null)
                    {
                        //  Debug.Log("jump333333333");
                        jumpCoroutine = jumpHandle();
                        StartCoroutine(jumpCoroutine);
                    }
                }
               
            }
        }      
    }

    float t;
    float t2;

    private IEnumerator jumpHandle()
    {
        t = Time.time;
        isGrounded = false;
     
        //if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(JumpClip);
        }

       animator.SetBool("Run", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Slide", false);
        animator.SetBool("Jump", true);
         
        isJump = true;      
        movingDown = false;

        //move up
        float start = playerYpos;
        float end = playerYpos + (40 * scaleConstants); // change this constant according to the SCALE

        Vector3 startVec = transform.position;
        Vector3 endVec = new Vector3(transform.position.x, transform.position.y + (40 * scaleConstants), transform.position.z);

            float temp = 0;
            while (temp < 1)
            {
                Debug.Log("UPPPPPPP");               
                playerYpos = Mathf.Lerp(start, end, temp);
                temp += Time.deltaTime * MoveSpeed*2;
                yield return null;
            }
            playerYpos = end;
       // Debug.Break();

        float tt = 0;
        while (tt < 1)
        {
            tt += (Time.deltaTime*4) * MoveSpeed;
            yield return null;
        }

        movingDown = true;
        //move down
        float start2 = end;
        float end2 = start;
        float temp2 = 1.0f;

        while (temp2 > 0)
        {
          Debug.Log("DDDDDDDDDDDDDDDDDDDD");
            playerYpos = Mathf.Lerp(end2, start2, temp2);
            temp2 -= Time.deltaTime * MoveSpeed;
            yield return null;
        }
        playerYpos = end2;
        
        isJump = false;     
        movingDown = false;
 
        animator.SetBool("Run", true);
        animator.SetBool("Hit", false);
        animator.SetBool("Slide", false);
        animator.SetBool("Jump", false);

        if (jumpCoroutine != null)
        {          
            Debug.Log("7");
            Debug.Log("7_JumpTime: " + (Time.time - t));
            StopCoroutine(jumpCoroutine);
            jumpCoroutine = null;
        }
    }

    public void OnDuck()
    {
        if (GameManager.Instance.gameState == GameManager.GameStates.START) {        
            Debug.Log("duck##############");
            if (isSliding == false)
            {
                Debug.Log("duck");
                isSliding = true;
                StartCoroutine(SlideHandle());
            }
        }                
    }

    private IEnumerator SlideHandle()
    {
        t2 = Time.time;
        // if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(SlideClip);
        }

        onceRun = true;
        
        //change the height of collider
        capCollider.height = capCollider.height / 3;
        capCollider.center = new Vector3(capCollider.center.x,capCollider.center.y/3,capCollider.center.z);

         animator.SetBool("Run", false);
        animator.SetBool("Hit", false);
        animator.SetBool("Slide", true);
        animator.SetBool("Jump", false);
       
        float temp = 0;
        while (temp < 1)
        { 
            temp += (Time.deltaTime/2) * MoveSpeed;
            yield return null;
        }

        Debug.Log("duck finish");

        capCollider.height = capCollider.height * 3;
        capCollider.center = new Vector3(capCollider.center.x, capCollider.center.y * 3, capCollider.center.z);

        animator.SetBool("Slide", false);
        animator.SetBool("Run", true);

        onceRun = false;
        isSliding = false;
        Debug.Log("slideTime: " + (Time.time - t2));
    }
}
