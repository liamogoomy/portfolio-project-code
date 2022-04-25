using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 5;
    bool playerstomp;
    public GameObject playercharacter;
    public GameObject enemycharacter;
    public GameObject projectile;
    public bool defeated;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerstomp = playercharacter.gameObject.GetComponent<character>().stomped;
        if (health == 0)
        {
            enemycharacter.gameObject.SetActive(false);
            projectile.gameObject.SetActive(false);
            defeated = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "player":
                if (playerstomp)
                {
                    health -= 1;
                }
                break;
        }
    }
}
