using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
    public string subTitlesText;
    public TMP_FontAsset font;
    public float fontSize;
    public Color color;
 
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleTrackMixer>.Create(graph);

        SubtitleTrackMixer subTitleBehaviour = playable.GetBehaviour();
        subTitleBehaviour.subTitlesText = subTitlesText;
        subTitleBehaviour.font = font;
        subTitleBehaviour.fontSize = fontSize;
        subTitleBehaviour.color = color;

        return playable;
    }

}
