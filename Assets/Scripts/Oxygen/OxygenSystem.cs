using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenSystem : MonoBehaviour
{
    [HideInInspector] public float maxOxygenLevel = 100;
    [HideInInspector] public float currentOxygenLevel;
    [HideInInspector] public int currentOxygenTanks;
    [HideInInspector] public int maxOxygenTanks = 0;

    [Range(0.0f, 5f)] public float oxygenDisminutionRatio;
    [SerializeField] private Slider oxygenBar;
    [SerializeField] private TMP_Text text;
    public static bool hasUpgradeSuit = false;

    private void Start()
    {
        currentOxygenLevel = maxOxygenLevel;
    }

    private void Update()
    {
        currentOxygenLevel -= Time.deltaTime * oxygenDisminutionRatio;
        oxygenBar.value = currentOxygenLevel;
        text.text = currentOxygenTanks.ToString();

        if(currentOxygenLevel <= 0)
        {
            if (currentOxygenTanks > 0)
            {
                currentOxygenLevel = maxOxygenLevel;
                currentOxygenTanks--;
            }
            else
            {
                GetComponent<UpdateAnimations>().Death();
                PlayerInput.canMove = false;
            }
        }
            
    }
}
