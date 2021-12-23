using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Timeline;

[TrackBindingType(typeof(RawImage))]
[TrackClipType(typeof(ImageClip))]
public class ImageTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<ImageTrackMixer>.Create(graph, inputCount);
    }
}
