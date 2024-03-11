using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<ParticleSystem> particles;
    public TextMeshProUGUI breathe;
    public AudioSource breatheAudio;
    private float lastBreatheTime;

    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 24;
        lastBreatheTime = Time.timeSinceLevelLoad;
    }


    void Update()
    {
        if ((Time.time - lastBreatheTime) >= 5)
        {
            breathe.enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                breatheAudio.Play();
                lastBreatheTime = Time.time;
            }
        }
        else
        {
            breathe.enabled = false;
        }
    }

    public void AdjustTime(float amount)
    {
        foreach (var particle in particles)
        {
            ParticleSystem.MainModule mainModule = particle.main;
            mainModule.simulationSpeed = 1 * amount;
        }
    }

    public void AdjustRain(float amount)
    {
        foreach (var particle in particles)
        {
            ParticleSystem.EmissionModule emission = particle.emission;
            emission.rateOverTime = 1000 * amount;
        }
    }

    public void AdjustHorizontalWind(float amount)
    {
        foreach (var particle in particles)
        {
            ParticleSystem.ForceOverLifetimeModule windForce = particle.forceOverLifetime;
            windForce.x = 200 * amount;
        }
    }

    public void AdjustVerticalWind(float amount)
    {
        foreach (var particle in particles)
        {
            ParticleSystem.ForceOverLifetimeModule windForce = particle.forceOverLifetime;
            windForce.y = 75 * amount;
        }
    }
}
