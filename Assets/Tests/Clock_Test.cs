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
        clock.incrementSeconds(3540);
        Assert.AreEqual(clock.seconds, 0);
        Assert.AreEqual(clock.hours, 1);
        clock.incrementSeconds(82800);
        Assert.AreEqual(clock.seconds, 0);
        Assert.AreEqual(clock.hours, 0);
        Assert.AreEqual(clock.days, 1);
        // Use the Assert class to test conditions
    }

    [Test]
    public void LightPosition_TestSimplePasses()
    {
        Clock clock = new Clock();
        GameObject obj1 = new GameObject();
        obj1.AddComponent<Day_Night_Cycle>();
        Day_Night_Cycle cycle = obj1.GetComponent<Day_Night_Cycle>();
        cycle.clock = clock;

        List<hour_position> key_times = new List<hour_position>();
        hour_position key_moment1 = new hour_position();
        hour_position key_moment2 = new hour_position();
        hour_position key_moment3 = new hour_position();
        hour_position key_moment4 = new hour_position();

        key_moment1.hour = 0;
        key_moment1.pos = new Vector3(270, 0, 0);
        key_moment1.state = "midnight";

        key_moment2.hour = 3;
        key_moment2.pos = new Vector3(315, 0, 0);
        key_moment2.state = "night";

        key_moment3.hour = 6;
        key_moment3.pos = new Vector3(0, 0, 0);
        key_moment3.state = "morning";

        key_moment4.hour = 9;
        key_moment4.pos = new Vector3(45, 0, 0);
        key_moment4.state = "morning";

        key_times.Add(key_moment1);
        key_times.Add(key_moment2);
        key_times.Add(key_moment3);
        key_times.Add(key_moment4);

        cycle.light_position = key_times;
        cycle.CheckForNewHour();
        Assert.AreEqual("midnight", cycle.current_day_state);
        clock.incrementSeconds(3600 * 3);
        cycle.CheckForNewHour();
        Assert.AreEqual("night", cycle.current_day_state);
        clock.incrementSeconds(3600 * 2);
        cycle.CheckForNewHour();
        Assert.AreEqual("night", cycle.current_day_state);

        clock.incrementSeconds(3600);
        cycle.CheckForNewHour();
        Assert.AreEqual("morning", cycle.current_day_state);

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
