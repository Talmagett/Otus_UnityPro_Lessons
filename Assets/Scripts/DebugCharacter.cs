using System;
using Models;
using Presenters;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

public class DebugCharacter : MonoBehaviour
{
    private ICharacterPopup _characterPopup;

    [Inject]
    public void Construct(ICharacterPopup characterPopup)
    {
        _characterPopup = characterPopup;
    }

    [Button]
    public void SetUserData(string userName, string description, Sprite icon)
    {
        if (!userName.IsNullOrWhitespace())
            _characterPopup.CharacterInfo.ChangeName(userName);
        if (!description.IsNullOrWhitespace())
            _characterPopup.CharacterInfo.ChangeDescription(description);
        if (icon != null)
            _characterPopup.CharacterInfo.ChangeIcon(icon);
    }

    [Button]
    public void AddExperience(int xpValue)
    {
        _characterPopup.CharacterLevel.AddExperience(xpValue);
    }

    [Button]
    public void AddStat(string statName, int value)
    {
        try
        {
            _characterPopup.CharacterStatsInfo.GetStat(statName);
        }
        catch (Exception e)
        {
            _characterPopup.CharacterStatsInfo.AddStat(new CharacterStat(statName, value));
        }
    }

    [Button]
    public void RemoveStat(string statName)
    {
        try
        {
            var stat = _characterPopup.CharacterStatsInfo.GetStat(statName);
            _characterPopup.CharacterStatsInfo.RemoveStat(stat);
        }
        catch (Exception e)
        {
            print($"No such Stat {e}");
        }
    }

    [Button]
    public void ChangeStatValue(string statName, int newValue)
    {
        try
        {
            var stat = _characterPopup.CharacterStatsInfo.GetStat(statName);
            stat.ChangeValue(newValue);
        }
        catch (Exception e)
        {
            print($"No such Stat {e}");
        }
    }
}