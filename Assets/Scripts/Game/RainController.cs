using UnityEngine;

public class RainController : MonoBehaviour
{
    ParticleSystem myParticleSystem;
    ParticleSystem.EmissionModule emissionModule;
    ParticleSystem.MainModule mainModule;
    public static RainController Instance { get { return _instance; } }
    private static RainController _instance;
    float initialAmount = 1000;
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            myParticleSystem = GetComponent<ParticleSystem>();
            emissionModule = myParticleSystem.emission;
            mainModule = myParticleSystem.main;
            emissionModule.rateOverTime = initialAmount;
        }
    }

    public void ReduceRainLevel()
    {
        emissionModule.rateOverTime = initialAmount / 2;
    }
}
