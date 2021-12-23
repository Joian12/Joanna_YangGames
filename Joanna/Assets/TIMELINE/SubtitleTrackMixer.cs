using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class SubtitleTrackMixer : PlayableBehaviour
{
    public string subTitlesText;
    public TMP_FontAsset font;
    public float fontSize; 
    public Color color;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        float currentAlpha = 0f;
        TMP_FontAsset currentFont = null;
        float currentFontSize = 0f;
        Color currentColor = Color.clear; 
     
        if(!text) { return; }
            
        
        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);

            if(inputWeight > 0)
            {
                ScriptPlayable<SubtitleTrackMixer> inputPlayable = (ScriptPlayable<SubtitleTrackMixer>)playable.GetInput(i);

                SubtitleTrackMixer input = inputPlayable.GetBehaviour();
                currentText = input.subTitlesText;
                currentAlpha = inputWeight;
                currentFont = input.font;
                currentFontSize = input.fontSize;
                currentColor = input.color;
            }
        }

        text.text = currentText;
        text.color = new Color(currentColor[0], currentColor[1], currentColor[2], currentAlpha);
        text.font = currentFont;
        text.fontSize = currentFontSize;
    }
}
