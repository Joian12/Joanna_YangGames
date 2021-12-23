using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ImageTrackMixer : PlayableBehaviour
{   
    public float alpha;
    public Color color;
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        RawImage image = playerData as RawImage;
        float currentAlpha = 0f;
        Color currentColor = Color.clear;
        
     
        if(!image) { return; }
            
        
        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);

            if(inputWeight > 0)
            {
                ScriptPlayable<ImageTrackMixer> inputPlayable = (ScriptPlayable<ImageTrackMixer>)playable.GetInput(i);

                ImageTrackMixer input = inputPlayable.GetBehaviour();
                currentAlpha = input.alpha;
                currentColor = input.color;
                currentAlpha = input.alpha;
            }
        }
    
       image.color = new Color(currentColor[0], currentColor[1], currentColor[2], currentAlpha);
    }
}
