using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float speed = 0.04f;
    float directionx = 0.0f;
    float directiony = 0.0f;
    public GameObject playercharacter;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public bool jumped;
    public bool crouched;
    public bool stomped;
    public KeyCode crouchKey = KeyCode.DownArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode jumpkey;
    public int health = 10;
    public bool onground;
    bool launch;
    int count;
    bool e1defeated;
    bool e2defeated;
    bool e3defeated;
    bool e4defeated;
    bool defeat1;
    bool defeat2;
    bool defeat3;
    bool defeat4;
    bool canmoveleft = true;
    bool canmoveright = true;
    int points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.localPosition; // creates a vector3 variable called position and sets it to transform.localPosition
        position.x += speed * directionx; // sets position.x to position.x + speed * direction
        position.y += speed * directiony;
        transform.localPosition = position; 
        e1defeated = enemy1.gameObject.GetComponent<enemy>().defeated;
        e2defeated = enemy2.gameObject.GetComponent<enemy>().defeated;
        e3defeated = enemy3.gameObject.GetComponent<enemy>().defeated;
        e4defeated = enemy4.gameObject.GetComponent<enemy>().defeated;
        if (launch)
        {
            speed = 0.08f;
            count += 1;
            directionx = -1.0f;
        }
        if (count == 100)
        {
            count = 0;
            launch = false;
            speed = 0.04f;
        }
        bool iscrouch = Input.GetKey(crouchKey);
        bool isLeftPressed = Input.GetKey(moveLeftKey);
        bool isRightPressed = Input.GetKey(moveRightKey);
        bool isjump = Input.GetKey(jumpkey);
        if (isLeftPressed && canmoveleft)
        {
            directionx = -1.0f;
        }
        else if (isRightPressed && canmoveright)
        {
            directionx = 1.0f;
        }
        else if (!launch)
        {
            directionx = 0.0f;
        }
        if (isjump)
        {
            directiony = 2.0f;
            jumped = true;
        }
        if (iscrouch)
        {
            crouched = true;
        }
        if (!iscrouch && !isjump)
        {
            directiony = 0.0f;

        }
        if (jumped && crouched && !onground)
        {
            directiony = -1.0f;
            stomped = true;
            speed = 0.08f;
            canmoveleft = false;
            canmoveright = true;
        }
        else if (!launch)
        {
            speed = 0.04f;
        }
        if (onground)
        {
            jumped = false;
            crouched = false;
        }
        if (health < 1)
        {
            playercharacter.gameObject.SetActive(false);
        }
        if (e1defeated && !defeat1)
        {
            points += 10;
            defeat1 = true;
        }
        if (e2defeated && !defeat2)
        {
            points += 10;
            defeat2 = true;
        }
        if (e3defeated && !defeat3)
        {
            points += 10;
            defeat3 = true;
        }
        if (e4defeated && !defeat4)
        {
            points += 10;
            defeat4 = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "platform":
                if (stomped)
                {
                    directiony = 0.0f;
                    stomped = false;
                    canmoveleft = true;
                    canmoveright = true;
                }
                onground = true;
                break;
            case "enemy":
                stomped = false;
                canmoveleft = true;
                canmoveright = true;
                directiony = 0.0f;
                break;
            case "fire":
                if (stomped)
                {
                    health -= 2;
                    launch = true;
                    stomped = false;
                    canmoveleft = true;
                    canmoveright = true;
                    points -= 1;
                }
                else 
                {
                    health -= 1;
                }
                break;
            case "wall":
                directionx = 0.0f;
                break;
        }  
    }
    void OnCollisionExit2D(Collision2D other)
    {
        onground = false;
    }
}
