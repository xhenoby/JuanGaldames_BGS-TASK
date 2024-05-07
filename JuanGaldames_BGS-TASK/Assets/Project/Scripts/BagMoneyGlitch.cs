using UnityEngine;

public class BagMoneyGlitch : MonoBehaviour, IInteractable
{
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] AudioSource coinAudioSource;
    [SerializeField] ParticleSystem coinParticleSystem;
    public void Interact()
    {
        playerInventory.AddMoney(1);
        coinAudioSource.pitch = (Random.Range(1, 1.1f));
        coinAudioSource.PlayOneShot(coinAudioSource.clip);
        coinParticleSystem.Play();
    }
}
