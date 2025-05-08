using UnityEngine;

[CreateAssetMenu(fileName = "NewEventCard", menuName = "STEM/Event Card")]
public class EventCard : ScriptableObject
{
    public string title;
    public string description;

    public string leftChoiceText;
    public CardEffect leftEffect;

    public string rightChoiceText;
    public CardEffect rightEffect;
}