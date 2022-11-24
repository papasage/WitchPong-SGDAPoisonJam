using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoisonUI : MonoBehaviour
{
    private PoisonPicker pp;
    public RawImage leftPoisonImage;
    public RawImage leftPoisonImageDropShadow;
    public RawImage rightPoisonImage;
    public RawImage rightPoisonImageDropShadow;

    [SerializeField] private Texture ScrewPoison;
    [SerializeField] private Texture CurveDownPoison;
    [SerializeField] private Texture DefaultPoison;
    [SerializeField] private Texture CurveUpPoison;
    [SerializeField] private Texture FastBallPoison;

    //GAMEOBJECTS FOR SHELF
    [SerializeField] private RectTransform leftMandrake;
    [SerializeField] private RectTransform leftNightshade;
    [SerializeField] private RectTransform leftHolyWater;
    [SerializeField] private RectTransform leftBerries;
    [SerializeField] private RectTransform leftShroom;
    
    [SerializeField] private RectTransform rightMandrake;
    [SerializeField] private RectTransform rightNightshade;
    [SerializeField] private RectTransform rightHolyWater;
    [SerializeField] private RectTransform rightBerries;
    [SerializeField] private RectTransform rightShroom;

    float unselectedSize = 65;
    float selectedSize = 125;

    // Start is called before the first frame update
    void Awake()
    {
        pp = FindObjectOfType<PoisonPicker>();
    }

    // Update is called once per frame
    void Update()
    {
        LeftPoisonIcon();
        RightPoisonIcon();
    }

    void LeftPoisonIcon()
    {
        if (pp.isLeftScrew == true)
        {
            ResetIngredientSizeLeft();
            leftMandrake.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            leftMandrake.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            leftMandrake.ForceUpdateRectTransforms();
        }
        if (pp.isLeftCurveDown == true)
        {
            ResetIngredientSizeLeft();
            leftNightshade.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            leftNightshade.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            leftNightshade.ForceUpdateRectTransforms();
        }
        if (pp.isLeftDefault == true)
        {
            ResetIngredientSizeLeft();
            leftHolyWater.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            leftHolyWater.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            leftHolyWater.ForceUpdateRectTransforms();
        }
        if (pp.isLeftCurveUp == true)
        {
            ResetIngredientSizeLeft();
            leftBerries.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            leftBerries.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            leftBerries.ForceUpdateRectTransforms();
        }
        if (pp.isLeftFast == true)
        {
            ResetIngredientSizeLeft();
            leftShroom.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            leftShroom.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            leftShroom.ForceUpdateRectTransforms();
        }

    }
    
    void RightPoisonIcon()
    {
        if (pp.isRightScrew == true)
        {
            ResetIngredientSizeRight();
            rightMandrake.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            rightMandrake.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            rightMandrake.ForceUpdateRectTransforms();
        }
        if (pp.isRightCurveDown == true)
        {
            ResetIngredientSizeRight();
            rightNightshade.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            rightNightshade.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            rightNightshade.ForceUpdateRectTransforms();
        }
        if (pp.isRightDefault == true)
        {
            ResetIngredientSizeRight();
            rightHolyWater.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            rightHolyWater.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            rightHolyWater.ForceUpdateRectTransforms();
        }
        if (pp.isRightCurveUp == true)
        {
            ResetIngredientSizeRight();
            rightBerries.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            rightBerries.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            rightBerries.ForceUpdateRectTransforms();
        }
        if (pp.isRightFast == true)
        {
            ResetIngredientSizeRight();
            rightShroom.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, selectedSize);
            rightShroom.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, selectedSize);
            rightShroom.ForceUpdateRectTransforms();
        }

    }

    void ResetIngredientSizeLeft()
    {
        leftMandrake.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        leftMandrake.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        leftMandrake.ForceUpdateRectTransforms();

        leftNightshade.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        leftNightshade.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        leftNightshade.ForceUpdateRectTransforms();
        
        leftHolyWater.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        leftHolyWater.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        leftHolyWater.ForceUpdateRectTransforms();

        leftBerries.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        leftBerries.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        leftBerries.ForceUpdateRectTransforms();

        leftShroom.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        leftShroom.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        leftShroom.ForceUpdateRectTransforms();
    }    
    
    void ResetIngredientSizeRight()
    {
        rightMandrake.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        rightMandrake.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        rightMandrake.ForceUpdateRectTransforms();

        rightNightshade.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        rightNightshade.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        rightNightshade.ForceUpdateRectTransforms();

        rightHolyWater.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        rightHolyWater.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        rightHolyWater.ForceUpdateRectTransforms();

        rightBerries.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        rightBerries.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        rightBerries.ForceUpdateRectTransforms();

        rightShroom.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, unselectedSize);
        rightShroom.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, unselectedSize);
        rightShroom.ForceUpdateRectTransforms();
    }
}
