// FlightExamManager.cs 
using UnityEngine; 
using TMPro; 
 
public class FlightExamManager : MonoBehaviour 
{ 
    [SerializeField] private TMP_Text statusText; 
    [SerializeField] private TMP_Text missionText; 
 
    private bool hasTakenOff = false; 
    private bool threatCleared = false; 
    private bool missionComplete = false; 
 
    public void EnterDangerZone() 
    { 
        threatCleared = false;
        missionText.text = "Entered a Dangerous Zone!";
        missionText.color = Color.red;
        
        statusText.text = "THREAT DETECTED";
    } 
 
    public void ExitDangerZone() 
    { 
        threatCleared = true;
        missionText.text = "Zone Cleared. You are Safe.";
        missionText.color = Color.green;
        
        statusText.text = "STABLE"; 
    } 
}