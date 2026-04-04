// DangerZoneController.cs 
using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour 
{
    [SerializeField] private FlightExamManager examManager; 
    //[SerializeField] private MissileLauncher missileLauncher; 
    [SerializeField] private float missileDelay = 5f; 
 
    private Coroutine activeCountdown; 
 
    private void OnTriggerEnter(Collider collision) 
    { 
        if (collision.CompareTag("Player"))
        {
            examManager.EnterDangerZone();

            activeCountdown = StartCoroutine(MissileCountdown());
        }
    } 
 
    private void OnTriggerExit(Collider collision) 
    { 
        if (collision.CompareTag("Player"))
        {
            if (activeCountdown != null) StopCoroutine(activeCountdown);
 
            examManager.ExitDangerZone();
        }
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
    }
}