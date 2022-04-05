using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/AudioSourceContainer")]
public class AudioSourceContainerSO : ScriptableObject
{
    private List<AudioSource> sources;
    public void AddSource(AudioSource source) {
        if (sources == null)
            sources = new List<AudioSource>();
        if (!sources.Contains(source))
            sources.Add(source);
    }

    public void RemoveSource(AudioSource source) {
        if (sources != null && sources.Contains(source)) {
            sources[sources.IndexOf(source)].Stop();
            sources.Remove(source);
        }
    }

    public void RemoveAllSources() {
        if (sources != null) {
            List<AudioSource> _sources = new List<AudioSource>(sources);
            foreach (AudioSource src in _sources) {
                RemoveSource(src);
            }
        }
    }

    public void Clear() {
        if (sources != null) {
            sources.Clear();
        }
    }
}
