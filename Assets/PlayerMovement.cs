using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController charCon;
    public float speed;
    Vector3 velocity, vmovement;
    public GameObject cam, panel;
    public TextMeshProUGUI timer;
    public float clock;
    // Start is called before the first frame update
    void Awake()
    {

    }
    private void Update()
    {
        
    }
    // Update is called once per frame

    void Clocking()
    {
            float minutes = Mathf.FloorToInt(clock / 60);
            float seconds = Mathf.FloorToInt(clock % 60);
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        
    }
    void FixedUpdate()
    {
        clock += Time.deltaTime;
        Clocking();

        cam. transform.position = new Vector3(transform.position.x, transform.position.y + 12.25f, transform.position.z - 8);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (z != 0)
        {
            if (speed < 20)
            {
                speed = (speed + Time.deltaTime * 10);

            }
        }
        else if (z == 0)
        {
            speed = 0;
        }
        
        // Vector3 move = new Vector3(transform.forward.x * x, 0, transform.forward.z * z);
        // charCon.Move(move * speed * Time.deltaTime);

        // if (move != Vector3.zero)
        //{
        // transform.Rotate(x * 100 * transform.up * Time.deltaTime);

        // }

        vmovement = charCon.transform.forward * z;
        charCon.transform.Rotate(Vector3.up * x * (120f * Time.deltaTime));
        charCon.Move(vmovement * speed * Time.deltaTime);

        if (charCon.isGrounded)
        {
            velocity.y = -1.0f;
        }
        else
        {
            velocity.y += -9.8f * Time.deltaTime;

        }
        charCon.Move(velocity * Time.deltaTime);

        if (transform.position.y < -20)
        {
            print("Ping");
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    
}
