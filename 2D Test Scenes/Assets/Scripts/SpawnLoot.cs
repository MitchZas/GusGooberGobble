using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    [SerializeField] DogController dogControllerScript;
    [SerializeField] DroppingsManager dm;
    [SerializeField] AbilityHolder abilityHolderScript;

    void Update()
    {
        DropLoot();
    }

    public void DropLoot()
    {
        if (gameObject != null)
        {
            if (dm.digRate == 3)
            {
                GetComponent<LootBag>().InstantiateLoot(transform.position);
                Destroy(gameObject);
                abilityHolderScript.pickupItem.SetActive(true);
            }
        }
    }
}
