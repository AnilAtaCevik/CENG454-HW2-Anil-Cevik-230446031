// DangerZoneController.cs 
using UnityEngine; 
 
public class DangerZoneController : MonoBehaviour 
{ 
    //[SerializeField] private FlightExamManager examManager; 
    //[SerializeField] private MissileLauncher missileLauncher; 
    [SerializeField] private float missileDelay = 5f; 
 
    private Coroutine activeCountdown; 
 
    private void OnTriggerEnter(Collider collision) 
    { 
        // TODO: confirm the Player tag 
        // TODO: push the warning message "Entered a Dangerous Zone!" to the HUD 
        // TODO: start the delayed missile launch countdown 
    } 
 
    private void OnTriggerExit(Collider collision) 
    { 
        // TODO: confirm the Player tag 
        // TODO: cancel any pending launch countdown 
        // TODO: destroy the active missile and clear the HUD warning 
    } 
}