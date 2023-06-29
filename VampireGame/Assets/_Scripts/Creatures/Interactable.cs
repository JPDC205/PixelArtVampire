using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField]
    private GameObject interacteButton;

    public bool inInteractionRange;

    public void enterInteractionRange(){
        inInteractionRange = true;
        
        interacteButton.SetActive(true);
    }

    public void exitInteractionRange(){
        inInteractionRange = false;
        interacteButton.SetActive(false);
    }

    public void interact(){
        DialogManager.Instance.inputDialog("001");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Player"))
            enterInteractionRange();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag.Equals("Player"))
            exitInteractionRange();
    }

}
