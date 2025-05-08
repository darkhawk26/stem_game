using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public Slider educationSlider;
    public Slider scienceSlider;
    public Slider economySlider;
    public Slider approvalSlider;
    public Slider industrySlider;

    public void ApplyEffect(CardEffect effect)
    {
        educationSlider.value += effect.educationChange;
        scienceSlider.value += effect.scienceChange;
        economySlider.value += effect.economyChange;
        approvalSlider.value += effect.approvalChange;
        industrySlider.value += effect.industryChange;
    }
}
