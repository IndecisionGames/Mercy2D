using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour {

    public string abilityButtonAxisName = "Ability1";
    public Image abilityIconCooldownEffect;
    public Image abilityIconActiveEffect;
    public Text timerText;

    [SerializeField] private Ability ability;
    [SerializeField] private GameObject player;

    private Image abilityIcon;
    private AudioSource abilitySource;
    private float cooldownDuration;
    private float cooldownEnd;
    private float cooldownTimeLeft;
    private bool isOnCooldown;

    private float activeDuration;
    private float activeTimeLeft;
    private float activeEnd;
    private bool isActive;

    public void Initialize(Ability selectedAbility, GameObject player, string keyBinding){
        ability = selectedAbility;
        abilityButtonAxisName = keyBinding;
        abilityIcon = GetComponent<Image> ();
        abilitySource = GetComponent<AudioSource> ();
        abilityIcon.sprite = ability.Sprite;

        cooldownDuration = ability.BaseCooldown;
        activeDuration = ability.ActiveTime;
        ability.Initialize(player);
        Ready();
    }

    // Update is called once per frame
    void Update(){

        bool isStillActive = (Time.time < activeEnd);
        if(isActive && !isStillActive){
            StartCooldown();
        }

        bool isStillOnCooldown = (Time.time < cooldownEnd);
        if(isOnCooldown && !isStillOnCooldown){
            isOnCooldown = false;
        }

        if(!isOnCooldown && !isActive){
            Ready();
            if(Input.GetButtonDown(abilityButtonAxisName)){
                Activate();
            }
        }else if(isActive){
            Active();
        }else{
            Cooldown();
        }
    }

    private void Ready(){
        isOnCooldown = false;
        isActive = false;
        timerText.enabled = false;
        abilityIconCooldownEffect.enabled = false;
        abilityIconActiveEffect.enabled = false;
    }


    private void Active(){
        activeTimeLeft -= Time.deltaTime;

        float roundedCd = Mathf.Round(activeTimeLeft);
        timerText.text = roundedCd.ToString();
        abilityIconActiveEffect.fillAmount = (activeTimeLeft / activeDuration);
    }

    private void Cooldown(){
        cooldownTimeLeft -= Time.deltaTime;

        float roundedCd = Mathf.Round(cooldownTimeLeft);
        timerText.text = roundedCd.ToString();
        abilityIconCooldownEffect.fillAmount = (cooldownTimeLeft / cooldownDuration);
    }

    private void Activate(){
        activeEnd = Time.time + activeDuration;
        activeTimeLeft = activeDuration;
        isActive = true;

        abilityIconActiveEffect.enabled = true;
        timerText.enabled = true;

        // abilitySource.clip = ability.aSound;
        // abilitySource.Play ();
        ability.TriggerAbility();
    }

    private void StartCooldown(){

        isActive = false;
        abilityIconActiveEffect.enabled = false;

        isOnCooldown = true;
        cooldownEnd = Time.time + cooldownDuration;
        cooldownTimeLeft = cooldownDuration;
        abilityIconCooldownEffect.enabled = true;
        timerText.enabled = true;
        ability.OnAbilityEnd();
    }
}