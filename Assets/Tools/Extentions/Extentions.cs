using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tools.Extentions
{
    public static class ConversionExtentions
    {
        public static Vector2 ScreenToCanvasPosition(this Vector2 screenPosition, Canvas canvas)
        {
            if (canvas.renderMode != RenderMode.ScreenSpaceCamera)
            {
                Debug.LogError("RenderMode should be ScreenSpaceCamera. Other render modes not supported yet!");
                return Vector2.zero;
            }

            var screenSize = new Vector2(Screen.width, Screen.height);

            var viewPortPosition = new Vector2(screenPosition.x / screenSize.x, screenPosition.y / screenSize.y);

            var canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;

            return new Vector2(canvasSize.x * (viewPortPosition.x - .5f), canvasSize.y * (viewPortPosition.y - .5f));
        }

        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            var radians = degrees * Mathf.Deg2Rad;
            var sin = Mathf.Sin(radians);
            var cos = Mathf.Cos(radians);

            var tx = v.x;
            var ty = v.y;

            return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
        }

        public static Vector3 Right(this Vector3 b, Vector3 refAxis)
        {
            var bSubA = b - refAxis;
            var cSubA = -refAxis;

            var cross = Vector3.Cross(bSubA, cSubA);

            return cross;
        }

        public static bool DistanceCheck(this Vector3 origin,  Vector3 pointToCheck, float distanceToCheck)
        {
            // square the distance we compare with 
            if ((origin - pointToCheck).sqrMagnitude < distanceToCheck * distanceToCheck)
                return true;
            else
                return false;
        }
    }

    public static class ListExtentions
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            return list.OrderBy(elem => Guid.NewGuid()).ToList();
        }

        public static T RandomItem<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T LastItem<T>(this List<T> list)
        {
            return list[list.Count - 1];
        }
    }

    public static class FloatExtensions
    {
        public static bool EqualTo(this float a, float b)
        {
            return Mathf.Abs(a - b) < Mathf.Epsilon;
        }

        public static bool GreaterThan(this float a, float b)
        {
            return a - b > Mathf.Epsilon;
        }

        public static bool LessThan(this float a, float b)
        {
            return a - b < Mathf.Epsilon;
        }
    }

    public static class StringExtensions
    {
        public static string RemoveDiacritics(this string text)
        {
            return String.Join("", text.Normalize(NormalizationForm.FormD)
                                    .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
                                    .Replace("ı", "i");

            //var normalizedString = text.Normalize(NormalizationForm.FormD);
            //var stringBuilder = new StringBuilder();

            //foreach (var c in normalizedString)
            //{
            //    var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            //    if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            //    {
            //        stringBuilder.Append(c);
            //    }
            //}

            //return stringBuilder.ToString().Normalize(NormalizationForm.FormC); 
        }

    }

    public static class BehaviourExtensions
    {

    }
}
