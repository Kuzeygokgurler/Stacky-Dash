using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float speed;
    public GameObject dashesParent;
    public GameObject prevDash;
    public GameObject azaltParent;

    private Rigidbody rb;
    private bool isMoving = false;


    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        }
        
        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }
        
        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }
        
        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown && !isMoving)
        {
            isMoving = true;
            rb.velocity = -Vector3.forward * speed * Time.deltaTime;
        }

        if (rb.velocity == Vector3.zero)
        {
            isMoving = false;
        }

    }

    public void TakeDashes(GameObject dash)
    {
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.047f;
        dash.transform.localPosition = pos;
        Vector3 karakterPos = transform.localPosition;
        karakterPos.y += 0.047f;
        transform.localPosition = karakterPos;
        prevDash = dash;
        prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }
    public void Azalt(GameObject gameObject)
    {
        GameObject objem = transform.GetChild(2).GetChild(transform.GetChild(2).childCount - 1).gameObject;
        transform.GetChild(2).GetChild(transform.GetChild(2).childCount - 2).gameObject.AddComponent<StackScript>();
        transform.GetChild(2).GetChild(transform.GetChild(2).childCount - 1).SetParent(azaltParent.transform);

        Vector3 karakterPos = transform.localPosition;
        karakterPos.y -= 0.047f;
        transform.transform.position = karakterPos;

        Vector3 vec = gameObject.transform.position;
        vec.y += 0.1f;
        
        objem.transform.position = vec;

        
    }


}

