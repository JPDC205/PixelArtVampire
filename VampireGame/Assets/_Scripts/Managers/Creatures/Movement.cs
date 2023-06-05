using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!direction.Equals(Vector2.zero)){
            var pos = transform.position;
            pos += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
            transform.position = pos;
        }
    }

    public void setSpeed(float s){
        speed = s;
    }

    public float getSpeed(){
        return speed;
    }

    public void setDirection(Vector2 d){
        direction = d.normalized;
    }

    public Vector2 getDirection(){
        return direction;
    }

    public void stop(){
        direction = Vector2.zero;
    }
}
