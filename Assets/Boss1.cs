using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public enum BossState
    {
        Idle,
        LaserAttack,
        RotatingCannonAttack,
        PrimaryCannonAttack,
        HighSpeedBulletAttack
    }

    [Header("Boss Components")]
    [SerializeField] BossLaser[] fireLaserBoss;
    [SerializeField] RotatingCannon rotatingCannon;
    [SerializeField] PrimaryCannonBoss1 primaryCannon;
    [SerializeField] FireHighSpeedBulletsBoss fireHighSpeedBulletsBoss;

    [Header("State Management")]
    public BossState currentState = BossState.Idle;
    private float stateTimer;
    bool once = true;
    // Dictionary to store the duration of each state
    private Dictionary<BossState, float> stateDurations;

    void Start()
    {
        // Initialize the state durations
        stateDurations = new Dictionary<BossState, float>
        {
            { BossState.Idle, 3f },
            { BossState.LaserAttack, 6f },
            { BossState.RotatingCannonAttack, 7f },
            { BossState.PrimaryCannonAttack, 16f },
            { BossState.HighSpeedBulletAttack, 4f }
        };

        // Start in Idle state
        stateTimer = stateDurations[currentState];
    }

    void Update()
    {
        // Decrease the timer
        stateTimer -= Time.deltaTime;

        // Check if it's time to switch states
        if (stateTimer <= 0)
        {
            SwitchState();
            stateTimer = stateDurations[currentState]; // Set the new timer based on the new state
            once = true;
        }

        // Handle the current state
        HandleState();
    }

    void HandleState()
    {
        switch (currentState)
        {
            case BossState.Idle:
                if (once)
                {
                    Debug.Log("Boss is idle.");
                    once = false;
                }

                break;

            case BossState.LaserAttack:
                TriggerLaserAttack();
                break;

            case BossState.RotatingCannonAttack:
                TriggerRotatingCannonAttack();
                break;

            case BossState.PrimaryCannonAttack:
                TriggerPrimaryCannonAttack();
                break;

            case BossState.HighSpeedBulletAttack:
                TriggerHighSpeedBulletAttack();
                break;
        }
    }

    void SwitchState()
    {
        // Get the number of states in the enum
        int stateCount = System.Enum.GetValues(typeof(BossState)).Length;

        // Randomly select a new state, ensuring it's not the same as the current state
        BossState newState;
        do
        {
            newState = (BossState)Random.Range(0, stateCount);
        }
        while (newState == currentState); // Avoid selecting the same state consecutively

        currentState = newState;

        Debug.Log($"Switched to state: {currentState}");
    }

    void TriggerLaserAttack()
    {
        if (once)
        {
            foreach (var laser in fireLaserBoss)
            {
                StartCoroutine(laser.CirculateLaserStates());
            }

            Debug.Log("Laser Attack Triggered!");
        }
        once = false;
    }

    void TriggerRotatingCannonAttack()
    {
        if (rotatingCannon != null && once)
        {
            rotatingCannon.StartFire();
            Debug.Log("Rotating Cannon Attack Triggered!");
            Invoke(nameof(StopRotatingCannonAttack), stateDurations[BossState.RotatingCannonAttack]);
            once = false;
        }
    }

    void StopRotatingCannonAttack()
    {
        if (rotatingCannon != null)
        {
            rotatingCannon.StopFire();
            Debug.Log("Rotating Cannon Attack stopped!");
        }
    }

    void TriggerPrimaryCannonAttack()
    {
        if (primaryCannon != null && once)
        {
            primaryCannon.ChangeCannonState(PrimaryCannonState.Load);
            Debug.Log("Primary Cannon Attack Triggered!");
        }
        once = false;
    }

    void TriggerHighSpeedBulletAttack()
    {
        if (fireHighSpeedBulletsBoss != null && once)
        {
            fireHighSpeedBulletsBoss.StartFire();
            Debug.Log("High-Speed Bullet Attack Triggered!");
            Invoke(nameof(StopHighSpeedBulletAttack), stateDurations[BossState.HighSpeedBulletAttack]);
        }
        once = false;
    }

    void StopHighSpeedBulletAttack()
    {
        if (fireHighSpeedBulletsBoss != null)
        {
            fireHighSpeedBulletsBoss.StopFire();
            Debug.Log("High-Speed Bullet Attack off!");
        }
    }
}
