# DragonSound
An enhanced sound framework for unity games

[![Discord](https://img.shields.io/discord/686737735356252191.svg)](https://discord.gg/M7Gv6ER)
[![GitHub issues](https://img.shields.io/github/issues/AFewDragons/GlobalState.svg)](https://github.com/AFewDragons/DragonSound/issues)
[![GitHub Wiki](https://img.shields.io/badge/wiki-available-brightgreen.svg)](https://github.com/AFewDragons/DragonSound/wiki)

Make sound profiles for your sounds and then use them anywhere.

DragonSound is based off of making sound profiles that wrap around one or more sounds and lets you play that instead of the base AudioClip and AudioSource.

### Features
* Sound profiles that match the unity audio source settings
* Create profiles with multiple clips and choose sequential or random
* No setup required. Just play a sound, tell it to play in 3d/2d or follow an object

### Install

#### Unity Package Manager

To install this project using the Unity Package Manager,
add the following via the Package 

```
https://github.com/AFewDragons/DragonSound.git
```

You will need to have Git installed and available in your system's PATH.

#### Asset Folder

Simply copy/paste the source files into your assets folder.

### How To Use

#### Play

```
using AFewDragons.DragonSound;

public class PlayerFootstep : MonoBehaviour
{
    [SerializeField]
    private SoundProfile soundProfile;

    public void Foostep() {
        SoundProfile.Play(transform.position);
    }
}
```

### Community

Create issues for bugs or feature requests.