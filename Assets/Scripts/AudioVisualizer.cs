using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    [SerializeField] private int sampleDataLength = 1024;
    [SerializeField] private float minSize = 0.4f;
    [SerializeField] private float maxSize = 2.5f;
    [SerializeField] private float clipLoudness;
    [SerializeField] private AudioSource levelMusicSource;

    private float[] clipSampleData;
    private float sizeFactor;

    void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    void FixedUpdate()
    {
        sizeFactor = Random.Range(1.5f, 6f);


        //Note: This code is performance heavy, use burst compiler, or threads or some time delay (0.01f) to reduce the performance cost
        Visualize();
    }


    void Visualize()
    {
        levelMusicSource.clip.GetData(clipSampleData, levelMusicSource.timeSamples);

        clipLoudness = 0f;

        for(int i = 0 ; i < clipSampleData.Length; i++)
        {
            clipLoudness += Mathf.Abs(clipSampleData[i]); 
        }

        clipLoudness /= sampleDataLength;

        clipLoudness *= sizeFactor;

        clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize); //Finding the y scale of the object based on clip samples.

        Vector3 newScale =  new Vector3(transform.localScale.x, clipLoudness, transform.localScale.z);

        transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.fixedDeltaTime * 5);
    }

    public void SetAudioSource(AudioSource audioSource)
    {
        levelMusicSource = audioSource;
    }
}
