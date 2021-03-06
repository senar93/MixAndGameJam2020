﻿using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Card 0", menuName = "Game/Card", order = 1)]
public class SC_Card : SerializedScriptableObject
{
    [Space, AssetSelector, PreviewField]
    public Sprite iconSprite;
    [AssetSelector, PreviewField]
    public Sprite textSprite;

    public int weight = 1;

    [Space]
    public List<Effect> effects = new List<Effect>();

    public void Play()
    {
        foreach(Effect effect in effects)
        {
            effect.cardEffect.Invoke(effect.needType, effect.floatValue);
		}
	}

    public struct Effect 
    {
        [AssetSelector]
        public GameEvent_CardEffect cardEffect;
        [ShowIf("CheckUseNeedType"), AssetSelector, Required]
        public SC_NeedBar needType;
        [ShowIf("CheckUseFloatValue")]
        public float floatValue;

        private bool CheckUseNeedType()
        {
            return cardEffect != null && cardEffect.useNeedType;
        }

        private bool CheckUseFloatValue()
        {
            return cardEffect != null && cardEffect.useFloatValue;
        }
    }
}