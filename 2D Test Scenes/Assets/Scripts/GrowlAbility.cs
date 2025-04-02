using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Growl")]
public class GrowlAbility : BaseAbility
{

    public bool isActive;
    public override void Activate(GameObject parent)
    {
            isActive = true;
            //Debug.Log("Growl Activated");
            AIChase ownerSpeed = parent.GetComponent<AIChase>();
            ownerSpeed.speed = 0f;
    }

    public override void BeginCooldown(GameObject parent)
    {
        isActive = false;
        AIChase ownerSpeed = parent.GetComponent<AIChase>();
        ownerSpeed.speed = 3f;
    }
}
