using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ImageClip : PlayableAsset
{   
    public float alpha;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<ImageTrackMixer>.Create(graph);

        ImageTrackMixer imageBehaviour = playable.GetBehaviour();
        imageBehaviour.alpha = alpha;
      

        return playable;
    }
}
