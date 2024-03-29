using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AFewDragons.DragonSound
{
    [CreateAssetMenu(fileName = "New Sound Profile", menuName = "A Few Dragons/Dragon Sound/Sound Profile")]
    public class SoundProfile : ScriptableObject
    {
        public AudioClip[] Clips;
        public AudioMixerGroup Group;
        [Range(0,1)]
        public float Volume = 1;

        [Range(0,1)]
        public float SpatialBlend = 0;

        public float MinDistance = 1;
        public float MaxDistance = 100;
        public AnimationCurve VolumeBlend = new AnimationCurve(new Keyframe[] {
            new Keyframe(0,1,0,0),
            new Keyframe(100,0,0,0),
        });
        public bool Spread3dSound = false;

        public void Play()
        {
            Play(null);
        }

        public void Play(Vector3 position)
        {
            SoundManager.PlaySound(this, null, position);
        }

        public void Play(SoundOptions options)
        {
            SoundManager.PlaySound(this, options);
        }

        public void Play(SoundOptions options, Vector3 position)
        {
            SoundManager.PlaySound(this, options, position);
        }
    }
}