using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFewDragons.DragonSound
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField]
        private new AudioClip audio;

        [SerializeField]
        private bool is2d; 

        public void Play()
        {
            if (!audio) return;
            SoundManager.PlaySound(audio, new SoundOptions
            {
                SpatialBlend = is2d ? 0 : 1,
                Position = transform.position
            });
        }
    }
}