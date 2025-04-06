using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    public BaseAbility ability;
    float cooldownTime;
    float activeTime;

    public enum AbilityState { ready, active, cooldown }
    
    AbilityState state = AbilityState.ready;

    public GameObject pickupItem;

    public KeyCode key;

    [SerializeField] Image abilityImage;

    void Start()
    {
        //ability = GetComponent<BaseAbility>();

        Color c =abilityImage.color;
        c.a = 0;
        abilityImage.color = c;
    }

    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                {
                    if (pickupItem == null)
                    {
                        Color c = abilityImage.color;
                        c.a = 1;
                        abilityImage.color = c;
                    }
                    
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
                    Color c = abilityImage.color;
                    c.a = .5f;
                    abilityImage.color = c;
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
