using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SoundsData")]
public class SoundsData_SO : ScriptableObject
{
    public SoundEnum soundType;
    public AudioClip sound;
    public void Rename() {
#if UNITY_EDITOR
        //Set name for the SO
        string assetPath =  AssetDatabase.GetAssetPath(this.GetInstanceID());
        AssetDatabase.RenameAsset(assetPath, soundType.ToString() + "_SO");
        AssetDatabase.SaveAssets();

        //Set name for the sound
        if(sound == null)
            return;

        assetPath =  AssetDatabase.GetAssetPath(sound.GetInstanceID());
        AssetDatabase.RenameAsset(assetPath, soundType.ToString() + "_Audio");
        AssetDatabase.SaveAssets();
#endif        
    }
    public void PlaySound()
    {
        if(AudioManager.Instance.isSfxOn())
        {
            if(soundType == SoundEnum.Shoot)
                AudioManager.Instance.shootAud.PlayOneShot(sound);
            else
                AudioManager.Instance.sfxAud.PlayOneShot(sound);
        }
    }
}
