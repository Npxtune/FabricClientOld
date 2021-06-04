using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    public int healthValue;
    public Health playerHealth;
    public bool takeDMG;

    private void OnTriggerEnter(Collider other)
    {
        switch (takeDMG)
        {
            case true:
                playerHealth.TakeDamage(healthValue);
                break;

            default:
                playerHealth.TakeHealth(healthValue);
                break;
        }
    }
}
