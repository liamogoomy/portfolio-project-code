using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject projectileobject;
    public int posx;
    float returnpos;
    public float speed = 0.01f;
    float directionx = -1.0f;
    bool posreturn;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startposition = transform.localPosition;
        returnpos = startposition.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.localPosition; // creates a vector3 variable called position and sets it to transform.localPosition
        position.x += speed * directionx; // sets position.x to position.x + speed * direction
        if (posreturn)
        {
            position.x = returnpos;
            posreturn = false;
        }
        transform.localPosition = position;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        posreturn = true;
    }
}
