using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController charCon;
    public float speed;
    Vector3 velocity, vmovement;
    public GameObject cam, panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       cam. transform.position = new Vector3(transform.position.x, cam.transform.position.y, transform.position.z - 8);
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

        if (transform.position.y < -30)
        {
            print("Ping");
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    
}
