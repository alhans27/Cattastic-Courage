using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHealth { get; set; }

    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    [SerializeField] private GameObject deadMenuPanel;

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
        if (currentHealth > 0f)
        {
            // Hurt
            anim.SetTrigger("Hurt");
        }
        else
        {
            Dead();
        }
    }

    public void Dead()
    {
        // Dead
        anim.SetTrigger("Dead");
        GetComponent<Rigidbody2D>().velocity = new(0, 0);
        GetComponent<PlayerMovement>().enabled = false;
        deadMenuPanel.SetActive(true);
    }
}