using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed;
    [SerializeField]
    Movement mov;
    // Start is called before the first frame update
    void Start()
    {
        mov = gameObject.GetComponent<Movement>();
        mov.setSpeed(speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move(Vector2 d){
        mov.setDirection(d);
    }
}
