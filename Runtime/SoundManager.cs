using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AFewDragons.DragonSound
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager instance;

        private List<AudioSource> audioPool;

        // Start is called before the first frame update
        private void Awake()
        {
            audioPool = new List<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        private AudioSource GetSource()
        {
            foreach (var source in audioPool)
            {
                if (!source.isPlaying)
                    return source;
            }

            var gameObject = new GameObject("DragonAudioSource");
            gameObject.transform.parent = transform;
            var audio = gameObject.AddComponent<AudioSource>();
            audioPool.Add(audio);
            return audio;
        }

        public static void PlaySound(SoundProfile profile, SoundOptions options)
        {
            var audioSource = instance.GetSource();

            if(profile.Clips.Length <= 0)
            {
                Debug.LogError("Sound profile does not have any clips");
                return;
            }

            audioSource.clip = profile.Clips[Random.Range(0, profile.Clips.Length)];
            audioSource.outputAudioMixerGroup = profile.Group;
            audioSource.volume = profile.Volume;
            audioSource.spatialBlend = profile.SpatialBlend;

            audioSource.maxDistance = profile.MaxDistance;
            audioSource.minDistance = profile.MinDistance;

            if(profile.SpatialBlend > 0)
            {
                audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, profile.VolumeBlend);
            }

            if(options != null)
            {
                if(profile.SpatialBlend > 0)
                {
                    audioSource.transform.position = options.Position;
                }
            }
        }

        public static void PlayMusic(AudioClip clip)
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            instance = Instantiate(Resources.Load<SoundManager>("DragonSoundManager"));
        }
    }

    public class SoundOptions
    {
        public float Volume = 1;
        public float SpatialBlend = 1;
        public float Pitch = 1;
        public float MinDistance = 0.5f;
        public float MaxDistance = 5;
        public Vector3 Position;
    }
}
