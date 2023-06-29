using UnityEngine;

[System.Serializable]
public class NPCs
{
    public NPC[] npcs;

}

[System.Serializable]
public class NPC
{
    public string id;
    public string Name;
    public Dialogs[] dialogs;

}

[System.Serializable]
public class Dialogs
{
    public string id;
    public string Line;
    public string nextDialog;

}


