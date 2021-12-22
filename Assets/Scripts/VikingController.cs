using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VikingController : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public Text scoreText;
    public GameObject background;
    public Canvas endWindow;
    public Button menu;

    [SerializeField] float movingSpeed = 5f;
    [SerializeField] float ForceAmount = 400f;
    private float scores;

    bool jump = true;
    bool idle = false;
    float st = 0;
    float idleTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        st = Time.time;
        endWindow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float nt = Time.time;
        if((nt-st) > 0.5f)
        {
            scores++;
            st = nt;
            
            if(idle == true) {
                idleTime++;
                if(idleTime == 4)
                {
                    endWindow.enabled = true;
                    Time.timeScale = 0;
                    menu.interactable = false;
                }
            }
        }
        scoreText.text = "Score: " + scores.ToString();

        animator.SetBool("Jump", jump);
        animator.SetBool("Idle", idle);

        if (idle == false )
        {
            transform.localPosition += movingSpeed * Time.deltaTime * transform.forward;
            background.transform.localPosition += movingSpeed * Time.deltaTime * transform.forward;
            idleTime = 0;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localPosition += -movingSpeed * Time.deltaTime * transform.right;
            idle = false;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * transform.right;
            idle = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
            background.transform.localPosition += Vector3.right * (-57f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }
        if (Input.GetKey(KeyCode.Space) && jump == true)
        {
            jump = false;
            rb.AddForce(ForceAmount * Vector3.up);
            idle = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jump = true;
            
        }
        if (collision.gameObject.tag == "barrier")
        {
            idle = true;
            transform.localPosition -= movingSpeed *8* Time.deltaTime * Vector3.forward;
        }
        if(collision.gameObject.tag == "Gold")
        {
            Destroy(collision.gameObject);
            scores += 5;
        }
        if(collision.gameObject.tag == "Silver")
        {
            Destroy(collision.gameObject);
            scores += 3;
        }
        if(collision.gameObject.tag == "Background")
        {
            endWindow.enabled = true;
            Time.timeScale = 0;
            menu.interactable = false;
        }
    }
}
