using UnityEngine;

public class LandingArea : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager; 

    public AudioSource landingAudio;

    private void OnTriggerEnter(Collider collision)
    {
        if (examManager.CanLand())
        {
            landingAudio.Play();

            examManager.CompleteMission();
        }
        else
        {
            Debug.Log("Landing Rejected - Mission Not Completed Yet");
        }
    }
}
