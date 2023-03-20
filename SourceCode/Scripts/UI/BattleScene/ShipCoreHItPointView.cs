using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.BattleScene.Ship{ 
public class ShipCoreHItPointView : MonoBehaviour
{
    [SerializeField]
    private Slider ___HealthSlider;
    public void setHealth(float value) {

        DOTween.To(
            () => ___HealthSlider.value,
            (x) => ___HealthSlider.value = x,
            value,
            duration: 1.0f
            );
    }
}
}