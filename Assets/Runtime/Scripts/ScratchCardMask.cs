using System;
using UnityEngine;

namespace ScratchCard
{
    public abstract class ScratchCardMask : MonoBehaviour
    {
        public Action<float, bool> RevealProgressChanged;
        
        public bool IsRevealed => GetRevealProgress() >= revealedAt;
        
        [Header("Mask")]
        [SerializeField]
        [Range(0.0f, 1.0f)]
        protected float revealedAt = 0.95f;

        public abstract float GetRevealProgress();

        protected void OnRevealProgressChanged()
        {
            var progress = GetRevealProgress();
            var isRevealed = progress >= revealedAt;
            Debug.Log(progress);
            
            RevealProgressChanged?.Invoke(progress, isRevealed);
        }
    }
}