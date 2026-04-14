using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (AudioManager.instance != null)
        {
            audioSource.clip = AudioManager.instance.fire;
            audioSource.loop = true;
            audioSource.spatialBlend = 1f;
            audioSource.Play();
        }
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
        }

        if (audioSource != null)
        {
            audioSource.Stop();
        }

        Destroy(gameObject);
    }
}