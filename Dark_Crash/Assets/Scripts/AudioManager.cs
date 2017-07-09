/***
 * 
 *    Title:   Dark Crash
 *    Description: 
 *              Function：unified manage the audio files when there are a great amount of audios
 *
 *    Author:   
 *    Date:      
 *    Version:   
 *    Modify recoder:
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;                                  

public class AudioManager : MonoBehaviour {
    public AudioClip[] AudioClipArray;                               
    public static float AudioBackgroundVolumns = 1F;                 //the volumn of  background music
    public static float AudioEffectVolumns = 1F;                     //the volumn of audio effects

    private static Dictionary<string, AudioClip> _DicAudioClipLib;   //audio library
    private static AudioSource[] _AudioSourceArray;                  //audiosource array
    private static AudioSource _AudioSource_BackgroundAudio;         //background musci
    private static AudioSource _AudioSource_AudioEffectA;            //audio effect source A
    private static AudioSource _AudioSource_AudioEffectB;            //audio effect source B

    /// <summary>
    /// load audio library resources
    /// </summary>
	void Awake() {
	    //load audio library
        _DicAudioClipLib = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClip in AudioClipArray){
            _DicAudioClipLib.Add(audioClip.name,audioClip);
        }
        //handle audio source
        _AudioSourceArray=this.GetComponents<AudioSource>();
        _AudioSource_BackgroundAudio = _AudioSourceArray[0]; // @@@@@@@@@@@@@@@@  the first element is background music
        _AudioSource_AudioEffectA = _AudioSourceArray[1];
        _AudioSource_AudioEffectB = _AudioSourceArray[2];

        //get the audo volumn form data persistence
        if (PlayerPrefs.GetFloat("AudioBackgroundVolumns")>=0){
            AudioBackgroundVolumns = PlayerPrefs.GetFloat("AudioBackgroundVolumns");
            _AudioSource_BackgroundAudio.volume = AudioBackgroundVolumns;
        }
        if (PlayerPrefs.GetFloat("AudioEffectVolumns")>=0){
            AudioEffectVolumns = PlayerPrefs.GetFloat("AudioEffectVolumns");
            _AudioSource_AudioEffectA.volume = AudioEffectVolumns;
            _AudioSource_AudioEffectB.volume = AudioEffectVolumns;
        }
	}//Start_end

    /// <summary>
    /// Play background music
    /// </summary>
    /// <param name="audioClip">audio clip</param>
    public static void PlayBackground(AudioClip audioClip){
        //prevent the background music from repeatedly playing
        if (_AudioSource_BackgroundAudio.clip == audioClip){
            return;
        }
        //handle global backgournd music volumn
        _AudioSource_BackgroundAudio.volume = AudioBackgroundVolumns;
        if (audioClip){
            _AudioSource_BackgroundAudio.clip = audioClip;
            _AudioSource_BackgroundAudio.Play();
        }else{
            Debug.LogWarning("[AudioManager.cs/PlayBackground()] audioClip==null !");
        }
    }

    //play background music
    public static void PlayBackground(string strAudioName){
        if (!string.IsNullOrEmpty(strAudioName)){
            PlayBackground(_DicAudioClipLib[strAudioName]);
        }else{
            Debug.LogWarning("[AudioManager.cs/PlayBackground()] strAudioName==null !");            
        }
    }

    /// <summary>
    /// play audio effect A
    /// </summary>
    /// <param name="audioClip">audio clip</param>
    private static void PlayAudioEffectA(AudioClip audioClip){
        //handle global audio effect volumn
        _AudioSource_AudioEffectA.volume = AudioEffectVolumns;

        if (audioClip){
            _AudioSource_AudioEffectA.clip = audioClip;
            _AudioSource_AudioEffectA.Play();
        }
        else{
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectA()] audioClip==null ! Please Check! ");
        }
    }

    /// <summary>
    /// play audio effect B
    /// </summary>
    /// <param name="audioClip">  </param>
    private static void PlayAudioEffectB(AudioClip audioClip){
        //handle global audio effect volumn
        _AudioSource_AudioEffectB.volume = AudioEffectVolumns;

        if (audioClip){
            _AudioSource_AudioEffectB.clip = audioClip;
            _AudioSource_AudioEffectB.Play();
        }
        else{
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectB()] audioClip==null ! Please Check! ");
        }
    }

    /// <summary>
    /// play audio effect A
    /// </summary>
    /// <param name="strAudioEffctName">audio effect name</param>
    public static void PlayAudioEffectA(string strAudioEffctName)
    {
        if (!string.IsNullOrEmpty(strAudioEffctName)){
            PlayAudioEffectA(_DicAudioClipLib[strAudioEffctName]);
        }
        else{
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectA()] strAudioEffctName==null ! Please Check! ");
        }
    }

    /// <summary>
    /// play audio effect B
    /// </summary>
    /// <param name="strAudioEffctName">audio effect name</param>
    public static void PlayAudioEffectB(string strAudioEffctName)
    {
        if (!string.IsNullOrEmpty(strAudioEffctName))
        {
            PlayAudioEffectB(_DicAudioClipLib[strAudioEffctName]);
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectB()] strAudioEffctName==null ! Please Check! ");
        }
    }

    /// <summary>
    /// change the backgournd audio volumn
    /// </summary>
    /// <param name="floAudioBGVolumns"></param>
    public static void SetAudioBackgroundVolumns(float floAudioBGVolumns){
        _AudioSource_BackgroundAudio.volume = floAudioBGVolumns;
        AudioBackgroundVolumns = floAudioBGVolumns;
        //data persistence
        PlayerPrefs.SetFloat("AudioBackgroundVolumns", floAudioBGVolumns);
    }

    /// <summary>
    /// change the volumn of audio effect
    /// </summary>
    /// <param name="floAudioEffectVolumns"></param>
    public static void SetAudioEffectVolumns(float floAudioEffectVolumns){
        _AudioSource_AudioEffectA.volume = floAudioEffectVolumns;
        _AudioSource_AudioEffectB.volume = floAudioEffectVolumns;
        AudioEffectVolumns = floAudioEffectVolumns;
        //data persistence
        PlayerPrefs.SetFloat("AudioEffectVolumns", floAudioEffectVolumns);
    }
}//Class_end

