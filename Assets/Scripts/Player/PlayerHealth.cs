using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField]
    private float startHealth { get; set; }
    public float currentHealth { get; private set; }

    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private Animator anim;

    private void Awake()
    {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        totalhealthBar.fillAmount = currentHealth / startHealth;

    }

    private void Update()
    {
        currenthealthBar.fillAmount = currentHealth / startHealth;
    }

    public void GetDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);
        Debug.Log(currentHealth);
        if (currentHealth > 0f)
        {
            // Hurt
            anim.SetTrigger("Hurt");
        }
        else
        {
            // Dead
            anim.SetTrigger("Dead");
            GetComponent<PlayerMovement>().enabled = false;
        }
    }
}