using UnityEngine;

public class SoundAndParticleController : MonoBehaviour
{
    public ParticleSystem particlesSystem; // Assign your particle system in the inspector
    public AudioSource audioSource;       // Assign your audio source in the inspector

    // Call this function to start playing sound and particles
    public void PlaySoundAndParticles()
    {
        if (particlesSystem != null && audioSource != null)
        {
            particlesSystem.gameObject.SetActive(true); // Make sure the particle system is active
            particlesSystem.Play(); // Start the particle system
            audioSource.Play();    // Start playing the sound

            // Call DeactivateParticleSystemAfterSound in the length of the audio clip
            Invoke("DeactivateParticleSystemAfterSound", audioSource.clip.length);
        }
    }

    // Function to deactivate the particle system
    private void DeactivateParticleSystemAfterSound()
    {
        Debug.Log("stop audio and particles");
        if (particlesSystem != null)
        {
            particlesSystem.gameObject.SetActive(false); // Deactivate the particle system GameObject
        }
    }
}
