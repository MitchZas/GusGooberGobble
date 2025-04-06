using Unity.VisualScripting;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public BaseAbility ability;
    float cooldownTime;
    float activeTime;

    public enum AbilityState { ready, active, cooldown }
    
    AbilityState state = AbilityState.ready;

    public GameObject pickupItem;

    public KeyCode key;
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                {
                if (Input.GetKeyDown(key) && pickupItem == null)
                {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                }
                    break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                    break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
    }
}
