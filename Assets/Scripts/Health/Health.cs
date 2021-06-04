using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;
    public GameObject state1;
    public GameObject state2;

    private void Start()
    {
        currentHealth = maxHealth;
    }
   
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        switch (currentHealth)
        {
            case 0:
                state1.SetActive(false);
                state2.SetActive(true);
                Debug.Log("Health is at 0");
                break;

            case 1:
                state1.SetActive(true);
                state2.SetActive(false);
                Debug.Log("Health is at 1");
                break;

            case 2:
                state1.SetActive(false);
                state2.SetActive(false);
                Debug.Log("Health is at 2");
                break;

            default:
                currentHealth = 0;
                state1.SetActive(false);
                state2.SetActive(true);
                Debug.Log("Corrected Health");
                break;
        }
    }

    public void TakeHealth(int heal)
    {
        currentHealth += heal;

        switch (currentHealth)
        {
            case 0:
                state1.SetActive(false);
                state2.SetActive(true);
                Debug.Log("Health is at 0");
                break;

            case 1:
                state1.SetActive(true);
                state2.SetActive(false);
                Debug.Log("Health is at 1");
                break;

            case 2:
                state1.SetActive(false);
                state2.SetActive(false);
                Debug.Log("Health is at 2");
                break;

            default:
                currentHealth = 2;
                state1.SetActive(false);
                state2.SetActive(false);
                Debug.Log("Corrected Health");
                break;
        }
    }
}
