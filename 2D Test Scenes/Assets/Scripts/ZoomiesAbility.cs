using UnityEditor.ShaderGraph;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Zoomies")]
public class ZoomiesAbility : BaseAbility
{
    public float moveSpeedIncrease;

    public override void Activate(GameObject parent)
    {
        DogController movement = parent.GetComponent<DogController>();
        movement.moveSpeed = movement.moveSpeed + moveSpeedIncrease;
        //Debug.Log(moveSpeedIncrease);
    }

    public override void BeginCooldown(GameObject parent)
    {
        DogController movement = parent.GetComponent<DogController>();
        movement.moveSpeed = movement.moveSpeed - moveSpeedIncrease;
    }
}
