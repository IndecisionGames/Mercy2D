using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Abilities/MovementAbility")]
public class MovementAbility : Ability {

    public float maxSpeedPercentage = 0f;
    public float accelerationPercentage = 0f;

    private Transform objTransform;
    private Rigidbody2D objRigidbody2D;
    private PlayerMovementStat objPlayerMovementStat;

    public override void Initialize(GameObject obj){

        objTransform = obj.GetComponent<Transform>();
        objRigidbody2D = obj.GetComponent<Rigidbody2D>();
        objPlayerMovementStat = obj.GetComponent<PlayerMovementStat>();

    }

    public override void TriggerAbility(){

        objPlayerMovementStat.MaxSpeed.AddModifier("Sprint", maxSpeedPercentage, ModifierType.MultiplicativePercentage);
        objPlayerMovementStat.Acceleration.AddModifier("Sprint", accelerationPercentage, ModifierType.MultiplicativePercentage);


    }

    public override void OnAbilityEnd(){

        objPlayerMovementStat.MaxSpeed.RemoveModifier("Sprint");
        objPlayerMovementStat.Acceleration.RemoveModifier("Sprint");
    }

}