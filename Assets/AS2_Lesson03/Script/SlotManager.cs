using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private int[,] _slot;
    // スロットの回転速度（1秒間に何行進むか）
    private float _speed = 5f;
    // 現在のスクロール位置を記憶する変数
    private float _scrollPosition = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _slot = new int[,]
        {
           { 0, 0, 0 },
           { 1, 1, 1 },
           { 2, 2, 2 },
           { 3, 3, 3 },
           { 4, 4, 4 },
           { 5, 5, 5 },
        };
    }

    // Update is called once per frame
    void Update()
    {
        PlayingSlot();
    }

    public void PlayingSlot()
    {
        int reelLength = _slot.GetLength(1);
        for (int x = 0; x < reelLength; x++)
        {
            ReelLoop(x);
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
}