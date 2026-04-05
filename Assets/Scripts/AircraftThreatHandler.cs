// AircraftThreatHandler.cs 
using UnityEngine; 
 
public class AircraftThreatHandler : MonoBehaviour 
{ 
    [SerializeField] private Transform respawnPoint; 
    [SerializeField] private AudioSource hitAudioSource; 
    [SerializeField] private FlightExamManager examManager; 
 
    private Rigidbody rb; 
 
    void Start() 
    { 
        rb = GetComponent<Rigidbody>(); 
    } 
 
    private void OnTriggerEnter(Collider collision) 
    { 
        if (!collision.CompareTag("Missile")) return;

        if (hitAudioSource != null)
            hitAudioSource.Play();

        rb.velocity = Vector3.zero;
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        examManager.MissileHit();

        Destroy(collision.gameObject); 
    } 
}