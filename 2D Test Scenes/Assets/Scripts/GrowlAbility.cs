using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Growl")]
public class GrowlAbility : BaseAbility
{
    public override void Activate(GameObject parent)
    {
            //Debug.Log("Growl Activated");
            AIChase ownerSpeed = parent.GetComponent<AIChase>();
            ownerSpeed.speed = 0f;
    }

    public override void BeginCooldown(GameObject parent)
    {
        AIChase ownerSpeed = parent.GetComponent<AIChase>();
        ownerSpeed.speed = 3f;
    }
}
