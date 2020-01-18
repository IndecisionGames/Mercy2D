using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    [SerializeField] private GameObject player;
    private HealthStat stat;

    public Image currentHealthBar;
    public Text healthText;


    void Start(){
        stat = player.GetComponent<HealthStat>();
        currentHealthBar.enabled = true;
        healthText.enabled = true;
    }

    public void UpdatUI(){
        SetHealthBar();
    }


    void SetHealthBar(){
        float currentHealth = stat.CurrentHealth.GetValue();
        float maxHealth = stat.MaxHealth.GetValue();
        float roundedHealth = Mathf.Round(currentHealth);

        healthText.text = roundedHealth.ToString();
        currentHealthBar.fillAmount = (currentHealth / maxHealth);

    }
}
