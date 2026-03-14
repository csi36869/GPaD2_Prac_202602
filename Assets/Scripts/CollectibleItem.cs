using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Item collected: {itemName}");
        
        PlayerCharacter character = other.GetComponent<PlayerCharacter>();
        if (itemName.Equals("Battery")&&(character!=null))
        {
            character.Heal(1);
        }

        Destroy(this.gameObject);

    }
}