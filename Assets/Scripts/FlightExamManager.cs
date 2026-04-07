// FlightExamManager.cs 
using UnityEngine; 
using TMPro; 
 
public class FlightExamManager : MonoBehaviour 
{ 
    [SerializeField] private TMP_Text statusText; 
    [SerializeField] private TMP_Text missionText; 
 
    private bool inDangerZone = false;
    private bool missileCountdownActive = false;
    private bool missileActive = false;
    private bool threatCleared = false;
    private bool missionComplete = false; 
 
    public void EnterDangerZone() 
    { 
        inDangerZone = true;
        threatCleared = false;

        missionText.text = "Entered a Dangerous Zone!";
        missionText.color = Color.red;
        statusText.text = "THREAT DETECTED";
    } 
 
    public void ExitDangerZone() 
    { 
        inDangerZone = false;

        if (missileActive || missileCountdownActive)
        {
            threatCleared = true;

            missionText.text = "Zone Cleared. You are Safe.";
            missionText.color = Color.green;
            statusText.text = "STABLE"; 
        }

        missileCountdownActive = false;
        missileActive = false;
    }

    public void StartMissileCountdown()
    {
        missileCountdownActive = true;
        missionText.text = "Missile lock detected!";
        missionText.color = Color.orange;
    }

    public void MissileLaunched()
    {
        missileCountdownActive = false;
        missileActive = true;

        missionText.text = "MISSILE INBOUND!";
        missionText.color = Color.red;
    }

    public void MissileHit()
    {
        missileActive = false;

        statusText.text = "Aircraft Destroyed!";
        missionText.text = "Mission Failed.";
    }

    public void ThreatEscaped()
    {
        threatCleared = true;
        missileActive = false;

        statusText.text = "Threat Avoided!";
        missionText.text = "Landing Allowed.";
    }

    public bool CanLand()
    {
        return !inDangerZone && threatCleared && !missionComplete;
    }

    public void CompleteMission()
    {
        missionComplete = true;
        
        missionText.text = "Mission Completed!";
        missionText.color = Color.green;
        statusText.text = "Victory";
    }
}