using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGameManager : MonoBehaviour {

    public static UIInGameManager instance;

    public Image blockInfoIcon;
    public Text blockInfoText;

    public Text maxHeightText, currentHeightText;

    public Slider heightChecker;

    public Text timerText;

    public GameObject resultPage;

    private void Awake()
    {
        instance = this;
    }

    public void OnResult() {
        resultPage.SetActive(true);
    }

    /// <summary>
    /// 타이머를 표시합니다.
    /// </summary>
    /// <param name="min">분</param>
    /// <param name="sec">초</param>
    public void OnChangeTimer(string _str) {
		timerText.text = _str;
    }

    /// <summary>
    /// 블럭 정보를 표시합니다.
    /// </summary>
    /// <param name="_category"></param>
    /// <param name="_icon"></param>
    public void OnChangeBlockInfo(string _category, Sprite _icon)
    {
        blockInfoText.text = _category;
        blockInfoIcon.sprite = _icon;
    }

    /// <summary>
    /// 인게임의 높이 체크의 최대값을 변경합니다.
    /// </summary>
    /// <param name="_maxHeight">최대 높이 값</param>
    public void OnChangeMaxHeightViewer(int _maxHeight) {
        heightChecker.maxValue = (float)_maxHeight;
        maxHeightText.text = _maxHeight + " m";
    }

    /// <summary>
    /// 인게임의 높이 체크를 표시합니다.
    /// </summary>
    /// <param name="_currentHeight">현재 높이 값</param>
    /// <param name="_maxHeight">최대 높이 값</param>
    public void OnChangeHeightViewer(int _currentHeight, int _maxHeight) {
        heightChecker.value = _currentHeight;
        currentHeightText.text = _currentHeight + " m";
        maxHeightText.text = _maxHeight + " m";
    }

}
