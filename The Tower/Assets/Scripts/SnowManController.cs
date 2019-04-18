using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnowManController : MonoBehaviour
{

    public float movementSpeed;
    public float jumpHeight;
    public float rotationSpeed = 1f;
    public LayerMask ground;
    public Transform feet;
    public Text cherryCountText;

    [SerializeField] private Transform respawnPoint;
    private bool isGrounded = false;
    private Vector3 direction;
    private Rigidbody rbody;

    //Final Score
    private int cherryCount;
    private int deathCount;
    private int finalScore;
  //  private AudioSource audio;

    private float minY = -60f;
    private float maxY = 60f;
    private float rotationY = 0f;
    private float rotationX = 0f;

    // Use this for initialization
    void Start()
    {
        movementSpeed = 5.0f;
        jumpHeight = 3.0f;
        rbody = GetComponent<Rigidbody>();
        cherryCount = 0;
        deathCount = 0;

      //  audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        if (direction.x != 0)
            rbody.MovePosition(rbody.position + transform.right * direction.x * movementSpeed * Time.deltaTime);
        if (direction.z != 0)
            rbody.MovePosition(rbody.position + transform.forward * direction.z * movementSpeed * Time.deltaTime);

        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

      //  bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
        if (Input.GetKeyDown("space") && isGrounded)
        {
           // audio.Play();
            rbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if making contact with ground layer
        if (collision.gameObject.layer == 9)
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "platform")
        {
            transform.parent = collision.transform;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cherry"))
        {
            other.gameObject.SetActive(false);
            cherryCount++;
            setCountText();
        }

        if (other.gameObject.CompareTag("CheckPoint"))
        {
            respawnPoint.transform.position = rbody.transform.position + new Vector3(0.0f,3.0f,0.0f);
 
        }

        if (other.gameObject.CompareTag("OutOfBound"))
        {
            deathCount++;
            setCountText();
            rbody.transform.position = respawnPoint.transform.position;
            Debug.Log("OutOfBound trigger");
        }

        if (other.gameObject.CompareTag("WinPoint"))
        {
            PlayerPrefs.SetInt("cherries", cherryCount);
            PlayerPrefs.SetInt("deaths", deathCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void setCountText()
    {
        cherryCountText.text = "Cherries: " + cherryCount.ToString() +
                                "\nDeaths: " + deathCount.ToString();
    }

    private void OnCollisionExit(Collision collision)
    {

        //if leaving contact with ground layer
        if (collision.gameObject.layer == 9)
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "platform")
        {
            transform.parent = null;

        }
    }

    void OnDisable()
    {
    }
}