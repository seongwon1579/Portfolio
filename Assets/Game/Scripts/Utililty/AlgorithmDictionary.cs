using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlgorithmDictionary 
{
    public static float[] QuickSorting(this float[] arr, int minIndex, int maxIndex)
    {
        int leftIndex = minIndex;
        int rightIndex = maxIndex;

        float pivotValue = arr[(int)((leftIndex + rightIndex) * 0.5f)];

        float temp;

        while (leftIndex <= rightIndex)
        {
            while (arr[leftIndex] < pivotValue)
                leftIndex++;
            while (pivotValue < arr[rightIndex])
                rightIndex--;
            if (leftIndex <= rightIndex)
            {
                temp = arr[leftIndex];
                arr[leftIndex] = arr[rightIndex];
                arr[rightIndex] = temp;
                leftIndex++;
                rightIndex--;
            }
        }
        if (minIndex < rightIndex)
        {
            QuickSorting(arr, minIndex, rightIndex);
        }
        if (leftIndex < maxIndex)
        {
            QuickSorting(arr, leftIndex, maxIndex);
        }
        return arr;
    }


    public static List<float> QuickSorting(this List<float> list, int minIndex, int maxIndex)
    {
        int leftIndex = minIndex;
        int rightIndex = maxIndex;

        float pivotValue = list[(int)((leftIndex + rightIndex) * 0.5f)];

        float temp;

        while (leftIndex <= rightIndex)
        {
            while (list[leftIndex] < pivotValue)
                leftIndex++;
            while (pivotValue < list[rightIndex])
                rightIndex--;
            if (leftIndex <= rightIndex)
            {
                temp = list[leftIndex];
                list[leftIndex] = list[rightIndex];
                list[rightIndex] = temp;
                leftIndex++;
                rightIndex--;
            }
        }
        if (minIndex < rightIndex)
        {
            QuickSorting(list, minIndex, rightIndex);
        }
        if (leftIndex < maxIndex)
        {
            QuickSorting(list, leftIndex, maxIndex);
        }
        return list;
    }
}
