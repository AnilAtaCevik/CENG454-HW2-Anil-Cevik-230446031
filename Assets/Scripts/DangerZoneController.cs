// DangerZoneController.cs 
using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour 
{
    [SerializeField] private FlightExamManager examManager; 
    [SerializeField] private MissileLauncher missileLauncher; 
    [SerializeField] private float missileDelay = 5f; 
 
    private Coroutine activeCountdown;
    private Transform playerTransform;
 
    private void OnTriggerEnter(Collider collision) 
    { 
        if (!collision.CompareTag("Player")) return;

        playerTransform = collision.transform;

        examManager.EnterDangerZone();

        if (activeCountdown == null)
            activeCountdown = StartCoroutine(MissileCountdown());
    } 
 
    private void OnTriggerExit(Collider collision) 
    { 
        if (!collision.CompareTag("Player")) return;

        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }

        missileLauncher.DestroyActiveMissile();

        examManager.ExitDangerZone();
    }

    private IEnumerator MissileCountdown()
    {
        examManager.StartMissileCountdown();

        yield return new WaitForSeconds(missileDelay);

        missileLauncher.Launch(playerTransform);
        examManager.MissileLaunched();

        activeCountdown = null;
    }
}