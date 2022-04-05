using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
   public AudioClip clip;
    public string name;
    [Range(0f, 1f)]
   public float volume;
   [Range(.1f, 3)]
   public float pitch;

    [HideInInspector]
   public AudioSource source;
}
