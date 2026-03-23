using UnityEngine;
using Yarn;
using Yarn.Unity;

public class DaysHandler : MonoBehaviour
{

    public DialogueRunner dialogueRunner;
   
    //Основные методы, используются во всех днях
    [YarnFunction("setPref")]
    public static string setDialogue(int dialogueInd)
    {
        string clientDialogue = WorkDayCycle.instance.MakeDialogue(dialogueInd);
        
        return clientDialogue;
    }
    [YarnCommand("makeCocktail")]
    public void MakeCoctail()
    {
        ChangeView.instance.MoveCameraToMaker();
    }
    [YarnCommand("nextClient")]
    public void NextClient()
    {
        WorkDayCycle.instance.EndClientSession();
    }
}


