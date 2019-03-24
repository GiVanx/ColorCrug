using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey))
        {
            Vector3 tempVect = new Vector3(1, 0, 0);
            tempVect = tempVect.normalized * (-speed) * Time.deltaTime;
            rigidBody.MovePosition(transform.position + tempVect);
            
        } else if (Input.GetKey(rightKey))
        {
            Vector3 tempVect = new Vector3(1, 0, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rigidBody.MovePosition(transform.position + tempVect);

        } else
        {
            rigidBody.velocity.Set(0, 0);
        }
    }
}
