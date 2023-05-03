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

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Setup()
        {
            var gameObject = new GameObject("SoundManager");
            instance = gameObject.AddComponent<SoundManager>();
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

        public static void PlaySound(SoundProfile profile, Vector3 position)
        {
            PlaySound(profile, null, position);
        }

        public static void PlaySound(SoundProfile profile, SoundOptions options)
        {
            PlaySound(profile, options, Vector3.zero);
        }

        public static void PlaySound(SoundProfile profile, SoundOptions options, Vector3 position)
        {
            var audioSource = instance.GetSource();

            if(profile.Clips.Length <= 0)
            {
                Debug.LogError("Sound profile does not have any clips");
                return;
            }

            if (options == null)
            {
                options = new SoundOptions();
            }

            audioSource.clip = profile.Clips[Random.Range(0, profile.Clips.Length)];
            audioSource.outputAudioMixerGroup = profile.Group;
            audioSource.volume = options.Volume ?? profile.Volume;
            audioSource.spatialBlend = options.SpatialBlend ?? profile.SpatialBlend;

            audioSource.maxDistance = options.MaxDistance ?? profile.MaxDistance;
            audioSource.minDistance = options.MinDistance ?? profile.MinDistance;

            if(audioSource.spatialBlend > 0)
            {
                audioSource.rolloffMode = AudioRolloffMode.Custom;
                audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, profile.VolumeBlend);
                audioSource.spread = profile.Spread3dSound ? 180 : 0;
                audioSource.transform.position = position;
            }
            else
            {
                audioSource.spread = 0;
            }

            audioSource.Play();
        }

        public static void PlayMusic(AudioClip clip)
        {

        }
    }

    public class SoundOptions
    {
        public float? Volume = null;
        public float? SpatialBlend = null;
        public float? Pitch = null;
        public float? MinDistance = null;
        public float? MaxDistance = null;
    }
}
