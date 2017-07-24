using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIResultManager : MonoBehaviour
{
    public static UIResultManager instance;

    public Text stackBlockText, riseHeightText, totalScoreText;

    public Slider heightChecker;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 결과 창을 표시합니다.
    /// </summary>
    /// <param name="_blockCount">블럭 쌓은 수</param>
    /// <param name="_currentHeight">올라간 높이</param>
    /// <param name="_maxHeight"></param>
    public void SetResult(int _blockCount, int _currentHeight, int _maxHeight)
    {
        stackBlockText.text = _blockCount.ToString();
        riseHeightText.text = _currentHeight.ToString();
        totalScoreText.text = (_blockCount * _currentHeight).ToString();
        OnChangeHeightViewer(_currentHeight, _maxHeight);
    }

    /// <summary>
    /// 높이 체크를 표시합니다.
    /// </summary>
    /// <param name="_currentHeight">현재 높이 값</param>
    /// <param name="_maxHeight">최대 높이 값</param>
    public void OnChangeHeightViewer(int _currentHeight, int _maxHeight)
    {
        heightChecker.value = (float)_currentHeight / _maxHeight;
    }

    public void OnRePlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
