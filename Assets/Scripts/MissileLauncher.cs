// MissileLauncher.cs 
using UnityEngine; 

public class MissileLauncher : MonoBehaviour 
{ 
    [SerializeField] private GameObject missilePrefab; 
    [SerializeField] private Transform launchPoint; 
    [SerializeField] private AudioSource launchAudioSource; 
 
    private GameObject activeMissile; 
 
    public GameObject Launch(Transform target) 
    { 
        if (activeMissile != null)
            Destroy(activeMissile);

        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();

        homing.SetTarget(target);

        if (launchAudioSource != null)
            launchAudioSource.Play();

        return activeMissile; 
    } 
 
    public void DestroyActiveMissile() 
    { 
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    } 
} 