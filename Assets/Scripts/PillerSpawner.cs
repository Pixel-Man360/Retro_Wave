using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnStartPoints;
    [SerializeField] private int pillerCount;
    [SerializeField] private AudioVisualizer pillerPrefab;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        SpawnPillers();
    }

    private void SpawnPillers()
    {
        for (int i = 0; i < spawnStartPoints.Count; i++)
        {
            for(int j = 0; j < pillerCount; j++)
            {
                AudioVisualizer piller = Instantiate(pillerPrefab);
                piller.transform.position = spawnStartPoints[i].position + new Vector3(0, 0, j * 0.75f);  
                piller.transform.parent = this.transform;
                piller.SetAudioSource(audioSource);
            }
        }
    }
}
