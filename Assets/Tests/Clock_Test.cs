using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Clock_Test
{
    
    // A Test behaves as an ordinary method
    [Test]
    public void Clock_TestSimplePasses()
    {
        Clock clock = new Clock();
        clock.incrementSeconds(1);
        Assert.AreEqual(clock.seconds, 1);
        clock.incrementSeconds(59);
        Assert.AreEqual(clock.seconds, 0);
        Assert.AreEqual(clock.minutes, 1);
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Clock_TestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
