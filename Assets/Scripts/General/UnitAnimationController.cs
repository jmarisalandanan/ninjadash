using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MagicSpace.NinjaDash
{
    [RequireComponent(typeof(Animator))]
    public class UnitAnimationController : MonoBehaviour
    {
        private readonly int IDLE_ANIMATION_HASH = Animator.StringToHash("Idle");
        private readonly int ATTACK_ANIMATION_HASH = Animator.StringToHash("Attack");
        private readonly int DASH_ANIMATION_HASH = Animator.StringToHash("isDashing");
        private readonly int HIT_ANIMATION_HASH = Animator.StringToHash("Hit");
        private readonly int DIE_ANIMATION_HASH = Animator.StringToHash("Die");

        private Animator unitAnimator;
        private Dictionary<UnitAnimation, Action> animationMap = new Dictionary<UnitAnimation, Action>();

        public void Animate(UnitAnimation unitAnimation)
        {
            animationMap[unitAnimation]();
        }

        public void PlayIdle()
        {
            unitAnimator.Play(IDLE_ANIMATION_HASH);
        }

        public void PlayAttack()
        {
            unitAnimator.Play(ATTACK_ANIMATION_HASH);
        }

        public void PlayHit()
        {
            unitAnimator.Play(HIT_ANIMATION_HASH);
        }

        public void PlayDie()
        {
            unitAnimator.Play(DIE_ANIMATION_HASH);
        }

        public void PlayDash()
        {
            var toggle = unitAnimator.GetBool(DASH_ANIMATION_HASH);
            unitAnimator.SetBool(DASH_ANIMATION_HASH, !toggle);
        }

        private void Awake()
        {
            unitAnimator = this.GetComponent<Animator>();

            animationMap.Add(UnitAnimation.Idle, PlayIdle);
            animationMap.Add(UnitAnimation.Attack, PlayAttack);
            animationMap.Add(UnitAnimation.Hit, PlayHit);
            animationMap.Add(UnitAnimation.Die, PlayDie);
            animationMap.Add(UnitAnimation.Dash, PlayDash);
        }
    }
}
