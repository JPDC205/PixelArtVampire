using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMananager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //WASD direction
        Vector2 direction = new Vector2( Mathf.RoundToInt(Input.GetAxis("Horizontal")), Mathf.RoundToInt(Input.GetAxis("Vertical")));

        pc.move(direction);

        if(Input.GetKeyDown(KeyCode.W)){
            Debug.Log("W Pressed");
        }
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log("A Pressed");
        }
        if(Input.GetKeyDown(KeyCode.S)){
            Debug.Log("S Pressed");
        }
        if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("D Pressed");
        }

        //Space 
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Space Pressed");
        }

        //ESC
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("ESC Pressed");
        }

        //F and E
        if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("F Pressed");
            Interactable interactable = null;
            
            foreach(Interactable i in FindObjectsOfType<Interactable>()){
                if(i.inInteractionRange){
                    interactable = i;
                    break;
                }
            }

            if(interactable != null)
                interactable.interact();
        }
        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("E Pressed");
        }

        //Shift
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            Debug.Log("Shift Pressed");
        }

        //Mouse button down and position
        Vector2 mousePos = Vector2.zero;
        if(Input.GetMouseButtonDown(0)){
            mousePos = getMousePositionInScreen();
            Debug.Log("LMB pressed in coord: " + mousePos);
        }
        if(Input.GetMouseButtonDown(1)){
            mousePos = getMousePositionInScreen();
            Debug.Log("RMB pressed in coord: " + mousePos);
        }
    }

    private Vector2 getMousePositionInScreen(){
        return (Vector2) cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
