using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HotAirSteamHandler : MonoBehaviour
{
    [SerializeField]private float SteamSpots;
    [SerializeField]private ParticleSystem[] SteamParticles;
    //[SerializeField]private bool[] SteamLeaking;
    [SerializeField] private int Steam;

    [SerializeField] private AudioSource[] SteamAudioSources;

    // Start is called before the first frame update
    void Start()
    {
        /*if (SteamSpots == 1)
        {
            SteamParticles[0].Play();
        }
        if (SteamSpots >= 2)
        {
            SteamParticles[0].Play();
            SteamParticles[1].Stop();
        }*/
        FindAudioSources();
    }

    void FindAudioSources()
    {
        SteamAudioSources = new AudioSource[SteamParticles.Length];

        for (int i = 0; i < SteamParticles.Length; i++)
        {
            SteamAudioSources[i] = SteamParticles[i].GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Steam == -1 && SteamSpots == 1)
        {
            SteamParticles[0].Stop();
            SteamAudioSources[0].Stop();
        }

        if (Steam == 0 && SteamSpots == 1)
        {
            SteamParticles[0].Play();
            SteamAudioSources[0].Play();
        }

        if (Steam == 0 && SteamSpots == 2)
        {
            SteamParticles[0].Play();
            SteamParticles[1].Stop();
            SteamAudioSources[0].Play();
            SteamAudioSources[1].Stop();
        }

        if (Steam == 1 && SteamSpots == 2)
        {
            SteamParticles[1].Play();
            SteamParticles[0].Stop();
            SteamAudioSources[1].Play();
            SteamAudioSources[0].Stop();
        }

        if (Steam == 0 && SteamSpots >= 3)
        {
            SteamParticles[1].Stop();
            SteamParticles[0].Play();
            SteamParticles[2].Stop();
            SteamParticles[3].Stop();
            SteamParticles[4].Stop();
            SteamParticles[5].Stop();
            SteamParticles[6].Stop();
            SteamParticles[7].Stop();
            SteamParticles[8].Stop();

            SteamAudioSources[1].Stop();
            SteamAudioSources[0].Play();
            SteamAudioSources[2].Stop();
            SteamAudioSources[3].Stop();
            SteamAudioSources[4].Stop();
            SteamAudioSources[5].Stop();
            SteamAudioSources[6].Stop();
            SteamAudioSources[7].Stop();
            SteamAudioSources[8].Stop();
        }

        if (Steam == 0 && SteamSpots >= 3)
        {
            SteamParticles[1].Stop();
            SteamParticles[0].Play();
            SteamParticles[2].Stop();
            SteamParticles[3].Stop();
            SteamParticles[4].Stop();
            SteamParticles[5].Stop();
            SteamParticles[6].Stop();
            SteamParticles[7].Stop();

            SteamAudioSources[1].Stop();
            SteamAudioSources[0].Play();
            SteamAudioSources[2].Stop();
            SteamAudioSources[3].Stop();
            SteamAudioSources[4].Stop();
            SteamAudioSources[5].Stop();
            SteamAudioSources[6].Stop();
            SteamAudioSources[7].Stop();
        }

        if (Steam == 1 && SteamSpots >= 3)
        {
            SteamParticles[1].Play();
            SteamParticles[0].Stop();
            SteamParticles[2].Stop();
            SteamParticles[3].Stop();
            SteamParticles[4].Stop();
            SteamParticles[5].Stop();
            SteamParticles[6].Stop();
            SteamParticles[7].Stop();

            SteamAudioSources[1].Play();
            SteamAudioSources[0].Stop();
            SteamAudioSources[2].Stop();
            SteamAudioSources[3].Stop();
            SteamAudioSources[4].Stop();
            SteamAudioSources[5].Stop();
            SteamAudioSources[6].Stop();
            SteamAudioSources[7].Stop();
        }

        if (Steam == 2 && SteamSpots >= 3)
        {
            SteamParticles[1].Stop();
            SteamParticles[0].Stop();
            SteamParticles[2].Play();
            SteamParticles[3].Stop();
            SteamParticles[4].Stop();
            SteamParticles[5].Stop();
            SteamParticles[6].Stop();
            SteamParticles[7].Stop();

            SteamAudioSources[1].Stop();
            SteamAudioSources[0].Stop();
            SteamAudioSources[2].Play();
            SteamAudioSources[3].Stop();
            SteamAudioSources[4].Stop();
            SteamAudioSources[5].Stop();
            SteamAudioSources[6].Stop();
            SteamAudioSources[7].Stop();
        }

        if (Steam == 3 && SteamSpots >= 3)
        {
            SteamParticles[1].Stop();
            SteamParticles[0].Stop();
            SteamParticles[2].Stop();
            SteamParticles[3].Play();
            SteamParticles[4].Stop();
            SteamParticles[5].Stop();
            SteamParticles[6].Stop();
            SteamParticles[7].Stop();

            SteamAudioSources[1].Stop();
            SteamAudioSources[0].Stop();
            SteamAudioSources[2].Stop();
            SteamAudioSources[3].Play();
            SteamAudioSources[4].Stop();
            SteamAudioSources[5].Stop();
            SteamAudioSources[6].Stop();
            SteamAudioSources[7].Stop();
        }

        if (Steam == 4 && SteamSpots >= 3)
        {
            SteamParticles[1].Stop();
            SteamParticles[0].Stop();
            SteamParticles[2].Stop();
            SteamParticles[3].Stop();
            SteamParticles[4].Play();
            SteamParticles[5].Stop();
            SteamParticles[6].Stop();
            SteamParticles[7].Stop();

            SteamAudioSources[1].Stop();
            SteamAudioSources[0].Stop();
            SteamAudioSources[2].Stop();
            SteamAudioSources[3].Stop();
            SteamAudioSources[4].Play();
            SteamAudioSources[5].Stop();
            SteamAudioSources[6].Stop();
            SteamAudioSources[7].Stop();
        }

        if (Steam == 5 && SteamSpots >= 3)
        {
            SteamParticles[1].Stop();
            SteamParticles[0].Stop();
            SteamParticles[2].Stop();
            SteamParticles[3].Stop();
            SteamParticles[4].Stop();
            SteamParticles[5].Play();
            SteamParticles[6].Stop();
            SteamParticles[7].Stop();

            SteamAudioSources[1].Stop();
            SteamAudioSources[0].Stop();
            SteamAudioSources[2].Stop();
            SteamAudioSources[3].Stop();
            SteamAudioSources[4].Stop();
            SteamAudioSources[5].Play();
            SteamAudioSources[6].Stop();
            SteamAudioSources[7].Stop();
        }

        if (Steam == 6 && SteamSpots >= 3)
        {
            SteamParticles[1].Stop();
            SteamParticles[0].Stop();
            SteamParticles[2].Stop();
            SteamParticles[3].Stop();
            SteamParticles[4].Stop();
            SteamParticles[5].Stop();
            SteamParticles[6].Play();
            SteamParticles[7].Stop();

            SteamAudioSources[1].Stop();
            SteamAudioSources[0].Stop();
            SteamAudioSources[2].Stop();
            SteamAudioSources[3].Stop();
            SteamAudioSources[4].Stop();
            SteamAudioSources[5].Stop();
            SteamAudioSources[6].Play();
            SteamAudioSources[7].Stop();
        }

        if (Steam == 7 && SteamSpots >= 3)
        {
            SteamParticles[1].Stop();
            SteamParticles[0].Stop();
            SteamParticles[2].Stop();
            SteamParticles[3].Stop();
            SteamParticles[4].Stop();
            SteamParticles[5].Stop();
            SteamParticles[6].Stop();
            SteamParticles[7].Play();

            SteamAudioSources[1].Stop();
            SteamAudioSources[0].Stop();
            SteamAudioSources[2].Stop();
            SteamAudioSources[3].Stop();
            SteamAudioSources[4].Stop();
            SteamAudioSources[5].Stop();
            SteamAudioSources[6].Stop();
            SteamAudioSources[7].Play();
        }

        if (Steam == 8 && SteamSpots >= 3)
        {
            SteamParticles[1].Play();
            SteamParticles[0].Play();
            SteamParticles[2].Play();
            SteamParticles[3].Play();
            SteamParticles[4].Play();
            SteamParticles[5].Play();
            SteamParticles[6].Play();
            SteamParticles[7].Play();

            SteamAudioSources[1].Play();
            SteamAudioSources[0].Play();
            SteamAudioSources[2].Play();
            SteamAudioSources[3].Play();
            SteamAudioSources[4].Play();
            SteamAudioSources[5].Play();
            SteamAudioSources[6].Play();
            SteamAudioSources[7].Play();
        }

        if (Steam == 9 && SteamSpots >= 3)
        {
            SteamParticles[1].Stop();
            SteamParticles[0].Play();
            SteamParticles[2].Play();
            SteamParticles[3].Stop();
            SteamParticles[4].Play();
            SteamParticles[5].Stop();
            SteamParticles[6].Play();
            SteamParticles[7].Stop();

            SteamAudioSources[1].Stop();
            SteamAudioSources[0].Play();
            SteamAudioSources[2].Play();
            SteamAudioSources[3].Stop();
            SteamAudioSources[4].Play();
            SteamAudioSources[5].Stop();
            SteamAudioSources[6].Play();
            SteamAudioSources[7].Stop();
        }

        if (Steam == 10 && SteamSpots >= 3)
        {
            SteamParticles[1].Play();
            SteamParticles[0].Stop();
            SteamParticles[2].Stop();
            SteamParticles[3].Play();
            SteamParticles[4].Stop();
            SteamParticles[5].Play();
            SteamParticles[6].Stop();
            SteamParticles[7].Play();

            SteamAudioSources[1].Play();
            SteamAudioSources[0].Stop();
            SteamAudioSources[2].Stop();
            SteamAudioSources[3].Play();
            SteamAudioSources[4].Stop();
            SteamAudioSources[5].Play();
            SteamAudioSources[6].Stop();
            SteamAudioSources[7].Play();
        }
    }
}
