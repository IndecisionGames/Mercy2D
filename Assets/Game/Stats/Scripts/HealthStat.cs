using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStat : MonoBehaviour
{

    public StatHolder CurrentHealth;
    public StatHolder MaxHealth;
    public StatHolder HealthRegen;

    [SerializeField] private GameEvent HealthChange;

    private

    void Start(){
        CurrentHealth.Initialize();
        MaxHealth.Initialize();
        HealthRegen.Initialize();
        HealthChange.Raise();
    }


    public void Heal(){
        HealthChange.Raise();
    }

    public void TakeDamage(float damage){
        CurrentHealth.SetValue(CurrentHealth.GetValueUnmodified() - damage);
        HealthChange.Raise();
    }

    public void IsDead(){}

}
