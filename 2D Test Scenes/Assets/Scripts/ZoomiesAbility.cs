using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Powerups/Zoomies")]
public class ZoomiesAbility : BaseAbility
{
    public float moveSpeedIncrease;
    
    void Start()
    {

    }

    public override void Activate(GameObject parent)
    {
        DogController movement = parent.GetComponent<DogController>();
        movement.moveSpeed = movement.moveSpeed + moveSpeedIncrease;
    }

    public override void BeginCooldown(GameObject parent)
    {
        DogController movement = parent.GetComponent<DogController>();
        movement.moveSpeed = movement.moveSpeed - moveSpeedIncrease;
    }
}
