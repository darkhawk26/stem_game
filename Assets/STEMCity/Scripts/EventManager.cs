using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    public EventCard[] eventCards;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public Button leftButton;
    public Button rightButton;

    private TextMeshProUGUI leftButtonText;
    private TextMeshProUGUI rightButtonText;

    public TextMeshProUGUI leftValueChangesText;
    public TextMeshProUGUI rightValueChangesText;

    
    public TextMeshProUGUI educationValueText;
    public TextMeshProUGUI economyValueText;
    public TextMeshProUGUI scienceValueText;
    public TextMeshProUGUI industryValueText;
    public TextMeshProUGUI approvalValueText;


    public StatsManager statsManager;

    private EventCard currentCard;

    void Start()
    {
        leftButtonText = leftButton.GetComponentInChildren<TextMeshProUGUI>();
        rightButtonText = rightButton.GetComponentInChildren<TextMeshProUGUI>();
        LoadRandomCard();
    }

    void LoadRandomCard()
    {
        currentCard = eventCards[Random.Range(0, eventCards.Length)];

        titleText.text = currentCard.title;
        descriptionText.text = currentCard.description;

        leftButtonText.text = currentCard.leftChoiceText;
        rightButtonText.text = currentCard.rightChoiceText;

        leftButton.onClick.RemoveAllListeners();
        rightButton.onClick.RemoveAllListeners();

        leftButton.onClick.AddListener(() => Choose(currentCard.leftEffect));
        rightButton.onClick.AddListener(() => Choose(currentCard.rightEffect));

        leftValueChangesText.text = FormatEffect(currentCard.leftEffect);
        rightValueChangesText.text = FormatEffect(currentCard.rightEffect);

        UpdateStatTexts();

    }

    string FormatEffect(CardEffect effect)
    {
        string s = "";
        if (effect.educationChange != 0) s += $"{Prefix(effect.educationChange)} Education\n";
        if (effect.scienceChange != 0) s += $"{Prefix(effect.scienceChange)} Science\n";
        if (effect.economyChange != 0) s += $"{Prefix(effect.economyChange)} Economy\n";
        if (effect.industryChange != 0) s += $"{Prefix(effect.industryChange)} Industry\n";
        if (effect.approvalChange != 0) s += $"{Prefix(effect.approvalChange)} Approval\n";
        return s.TrimEnd();
    }

    string Prefix(int value)
    {
        return value > 0 ? "+" + value.ToString() : value.ToString();
    }

    void UpdateStatTexts()
    {
        educationValueText.text = Mathf.RoundToInt(statsManager.educationSlider.value).ToString();
        scienceValueText.text =  Mathf.RoundToInt(statsManager.scienceSlider.value).ToString();
        economyValueText.text =  Mathf.RoundToInt(statsManager.economySlider.value).ToString();
        industryValueText.text =  Mathf.RoundToInt(statsManager.industrySlider.value).ToString();
        approvalValueText.text = Mathf.RoundToInt(statsManager.approvalSlider.value).ToString();
    }

    void Choose(CardEffect effect)
    {
        statsManager.ApplyEffect(effect);
        UpdateStatTexts();
        LoadRandomCard();
    }
}
