using UnityEngine;

public class WaveSpawnManagerExam04 : MonoBehaviour

{

    public Wave[] waveConfigurations;
    public WaveController waveController;
    public bool enableWaveCycling;
    private int currentWave = 0;
    private float waveEndTime = 0f;

    void Start()

    {

        waveController.StartWave(waveConfigurations[currentWave]);

    }

    void Update()

    {

        if (currentWave >= waveConfigurations.Length)
        {
            return;
        }
        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {
                Debug.Log("All waves completed!");
            }
            else
            {
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }
        }
        if (currentWave >= waveConfigurations.Length)
        {
            if (enableWaveCycling == true && waveController.IsComplete())
            {

                currentWave = 0;
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }
            return;

        }
        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            if (currentWave >= waveConfigurations.Length)

            {
                Debug.Log("All waves completed!");
            }
            else
            {
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }

        }

    }
}