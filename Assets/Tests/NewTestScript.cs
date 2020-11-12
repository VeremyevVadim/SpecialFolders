using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

namespace Tests
{
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [Test, Performance]
        public void TestDistance()
        {
            Measure.Method(() => distance())
                .WarmupCount(100)
                .MeasurementCount(10000).Run();
        }          
        
        [Test, Performance]
        public void TestSqrMagnitude()
        {
            Measure.Method(() => sqrmag())
                .WarmupCount(100)
                .MeasurementCount(10000).Run();
        }

        private static float distance()
        {
            return Vector3.Distance(v2, v1);
        }

        private static float sqrmag()
        {
            return Vector3.SqrMagnitude(v2 - v1);
        }
        
        private static Vector3 v1 => new Vector3(Random.value, Random.value, Random.value);
        private static Vector3 v2 => new Vector3(Random.value, Random.value, Random.value);
        
    }
}
