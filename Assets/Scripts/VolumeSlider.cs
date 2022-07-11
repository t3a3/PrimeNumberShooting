using UnityEngine;
using KanKikuchi.AudioManager;

public class VolumeSlider : MonoBehaviour
{

    /// <summary>
    /// スライダーに合わせてBGMのボリュームを変更する(再生中のものも)
    /// </summary>
    public void ChangeBGMVolume(float volume)
    {
        BGMManager.Instance.ChangeBaseVolume(volume);
    }

    /// <summary>
    /// スライダーに合わせてSEのボリュームを変更する(再生中のものも)
    /// </summary>
    public void ChangeSEVolume(float volume)
    {
        SEManager.Instance.ChangeBaseVolume(volume);
    }

}