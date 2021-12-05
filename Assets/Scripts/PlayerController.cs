using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private float fspeed = 4;
    private int desiredLane; //0:left 1:middle 2:right
    public float laneDistance = 4; //the distance between two lanes
    public float jumpForce = 2;
    public float Gravity = -20;

    public Animator animator;
    private bool isSliding = false;
    

    //Do Strzelania
    public GameObject bullet;
    public float shootRate = 0f;
    public float shootRateTimeStamp = 0f;
    public float shootForce = 0f;

    [SerializeField] ParticleSystem dustParticle = null;
    [SerializeField] ParticleSystem explosionParticle = null;

    // Start is called before the first frame update
    void Start()
    {
        desiredLane = 1;
        controller = GetComponent<CharacterController>();
        fspeed = forwardSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        forwardSpeed += Time.deltaTime/10;
        direction.z = fspeed;

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (PowerUpController.ammo > 0)
            {
                if (Time.time > shootRateTimeStamp)
                {
                    GameObject go = (GameObject)Instantiate(bullet, GameObject.FindGameObjectWithTag("Gun").transform.position, GameObject.FindGameObjectWithTag("Player").transform.rotation);
                    go.GetComponent<Rigidbody>().AddForce(GameObject.FindGameObjectWithTag("Gun").transform.forward * shootForce);
                    shootRateTimeStamp = Time.time + shootRate;
                    PowerUpController.ammo -= 1;
                }

            }
        }
        animator.SetBool("isGrounded", controller.isGrounded);
        if (controller.isGrounded)
        {
            Vector3 dustPosition = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
            dustParticle.transform.position = dustPosition;
            dustParticle.Play();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dustParticle.transform.position = new Vector3(0, -5.0f, 0);
                Jump();
            }
        }
        else
        {
            dustParticle.Stop();
            direction.y += Gravity * Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if(desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            fspeed = forwardSpeed * 2;
        }

        else if (Input.GetKey(KeyCode.S) && !isSliding)
        {
            //fspeed = forwardSpeed/2;
            StartCoroutine(Slide());
        }
        else
        {
            //fspeed = forwardSpeed;
        }
        

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.deltaTime);
    }

    public void Jump()
    {
        direction.y = jumpForce;
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        yield return new WaitForSeconds(1.3f);

        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            explosionParticle.Play();
        }
    }
}
