﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class ListAsDeckUtility {

    public static void Shuffle<T> ( this List<T> targetList, int firstCardPosition = 0, int lastCardPosition = -1 ) {
        if ( targetList != null ) {
            if ( firstCardPosition < 0 || firstCardPosition >= targetList.Count ) {
                firstCardPosition = 0;
            }
            if ( lastCardPosition < firstCardPosition ) {
                lastCardPosition = targetList.Count;
            }

            for ( int i = firstCardPosition; i < lastCardPosition; i++ ) {
                int swapIndex = Random.Range(firstCardPosition, lastCardPosition);
                T tmp = targetList[i];
                targetList[i] = targetList[swapIndex];
                targetList[swapIndex] = tmp;
            }
        }
    }


    public static void InsertInRandomPosition<T> ( this List<T> targetList, T card, int firstCardPosition = 0, int lastCardPosition = -1 ) {
        if ( targetList != null ) {
            if ( firstCardPosition < 0 || firstCardPosition >= targetList.Count ) {
                firstCardPosition = 0;
            }
            if ( lastCardPosition < firstCardPosition ) {
                lastCardPosition = targetList.Count;
            }

            int insertIndex = Random.Range(firstCardPosition, lastCardPosition);
            targetList.Insert( insertIndex, card );
        }
    }


    public static T Draw<T> ( this List<T> targetList, bool removeFromList = true ) where T : Object {
        if ( targetList != null && targetList.Count > 0 ) {
            T tmp = targetList[0];
            if ( removeFromList )
                targetList.RemoveAt( 0 );
            return tmp;
        }
        else {
#if UNITY_EDITOR
            Debug.LogError( "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" );
#endif
            return null;
        }
    }


    public static void InsertInRandomPosition<T>(this List<T> targetList, List<T> cards, int firstCardPosition = 0)
    {
        if (targetList != null && cards != null)
        {
            for(int i = 0; i < cards.Count; i++)
            {
                targetList.InsertInRandomPosition(cards[i], firstCardPosition);
            }
        }
    }


}
