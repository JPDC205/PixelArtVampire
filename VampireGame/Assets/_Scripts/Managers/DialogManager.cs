using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    public static DialogManager Instance;

    [SerializeField]
    private TextAsset jsonDialogFile;
    [SerializeField]
    private bool inDialog;
    [SerializeField]
    private string nextDialog;
    private string currentDialog;
    public Canvas dialogUI;
    public TextMeshProUGUI dialogLine;
    public int charCounter = 0;
    public float writtingSpeed = 0.1f;
    private float writtingCounter = 0.0f;

    // Start is called before the first frame update


    private void Awake() {
        if(Instance != null)
            Destroy(this);
        else
            Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inDialog){
            if(charCounter < currentDialog.Length){
                writtingCounter -= Time.deltaTime;
                if(writtingCounter <= 0){
                    dialogLine.text += currentDialog[charCounter++];
                    writtingCounter = writtingSpeed;
                }
            }
        }
        
    }

    public void openDialogWindow(){
        setDialogLine("");
        dialogUI.gameObject.SetActive(true);
        inDialog = true;
    }

    public void closeDialogWindow(){
        setDialogLine("");
        dialogUI.gameObject.SetActive(false);
        inDialog = false;
    }

    public void inputDialog(string dialogID){
        string[] result;
        
        if(inDialog){
            if(charCounter < currentDialog.Length){
                finishTyping();
                return;
            }
            if(nextDialog.Equals("STOP")){
                closeDialogWindow();
                return;
            }
            else
                result = getDialogLine(nextDialog);
        }
        else{
            result = getDialogLine(dialogID);
            openDialogWindow();
        }

        charCounter = 0;
        nextDialog = result[1];
        setDialogLine(result[0]);
    }

    public void setDialogLine(string line){
        currentDialog = line;
        dialogLine.text = "";
    }

    public void finishTyping(){
        dialogLine.text = currentDialog;
        charCounter = currentDialog.Length;
    }

    private string[] getDialogLine(string dialogID){
        string[] result = new string[2];

        string userID = "" + dialogID[0];

        NPCs npcsInJson = JsonUtility.FromJson<NPCs>(jsonDialogFile.text);

        Debug.Log(npcsInJson);
        foreach(NPC npc in npcsInJson.npcs){
            Debug.Log(npc.id.Equals(userID));
            if(npc.id.Equals(userID)){
                Debug.Log("here");
                foreach(Dialogs dialog in npc.dialogs){
                    if(dialog.id.Equals(dialogID)){
                        Debug.Log("there");
                        result[0] = dialog.Line;
                        result[1] = dialog.nextDialog;
                    }
                }
                break;
            }
        }



        Debug.Log("NPC ID: " + userID + " | Dialog ID: " + dialogID);
        Debug.Log(result[0]);
        Debug.Log(result[1]);



        return result;
    }
}
