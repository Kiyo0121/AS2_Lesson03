using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("＊＊＊Reel Object")]
    [SerializeField] private Transform[] _reels;

    private int[,] _slot;
    // スロットの回転速度（1秒間に何行進むか）
    private float _speed = 5f;
    // 現在のスクロール位置を記憶する変数
    private float _scrollPosition = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float[] _reelAngles;
    private int _reelStoped;

    void Start()
    {
        _slot = new int[,]
        {
           { 0, 0, 0 },
           { 1, 1, 1 },
           { 2, 2, 2 },
           { 3, 3, 3 },
           { 4, 4, 4 },
        };

        _reelAngles = new float[_slot.GetLength(1)];
    }

    // Update is called once per frame
    void Update()
    {
        PlayingSlot();

        if(Keyboard.current.spaceKey.wasPressedThisFrame
            || Mouse.current. leftButton.wasPressedThisFrame)
        {
            _reelStoped++;
        }

        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            if (_reelStoped > 2)
                _reelStoped = 0;
        }

        RotateReelStoped();
    }

    public void PlayingSlot()
    {
        int reelLength = _slot.GetLength(1);
        for (int x = _reelStoped; x < reelLength; x++)
        {
            ReelLoop(x);
            _reelAngles[x] += 360 / _slot.GetLength(0);
        }
    }

    public void ReelLoop(int reelIndex)
    {
        int length = _slot.GetLength(0);
        int tenp = _slot[length - 1, reelIndex];

        for (int y = length - 1; y > 0; y--)
        {
            _slot[y, reelIndex] = _slot[y - 1, reelIndex];
        }

        _slot[0, reelIndex] = tenp;

        Debug.Log($"_slot[0,{reelIndex}] = {_slot[0, reelIndex]}");
    }

    public void RotateReelStoped()
    {
        for (int x = 0; x < _slot.GetLength(1); x++)
        {
            _reels[x].eulerAngles = Vector3.right * _reelAngles[x];
        }

    }

    private bool GethitReel(int[,] slot, int row)
    {
        bool hit = false;

        return hit;
    }
}