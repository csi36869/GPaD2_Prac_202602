using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] bool canHeal = false;   // tick this in Inspector
    [SerializeField] int healAmount = 1;     // amount to heal if canHeal is true

    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            if (canHeal)
            {
                player.Heal(healAmount);
                Debug.Log($"Item collected: {itemName}");
            }
            else
            {
                Debug.Log($"Item collected: {itemName}");
            }

            Destroy(gameObject);
        }
    }

}
