using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.PerformanceTesting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Profiling;
using System;
using System.Runtime.InteropServices;
using TMPro;
namespace Tests
{
    public class PerformanceTest
    {
        // Testing for Login
        [UnityTest, Performance]
        public IEnumerator Login()
        {
            // stopwatch to measure execution time 
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            
            using (Measure.Scope(new SampleGroupDefinition("Setup.LoadScene")))
            {
                SceneManager.LoadScene("Login");
            }
            yield return null;


            yield return new WaitForSeconds(.001f);

            TMP_InputField Email = GameObject.Find("login_username").GetComponent<TMP_InputField>();
            Email.text = "a";


            TMP_InputField Password = GameObject.Find("login_password").GetComponent<TMP_InputField>();

            Password.text = "a";

            yield return new WaitForSeconds(.001f);

            UnityEngine.UI.Button LoginButton = GameObject.Find("Login Button").GetComponent<UnityEngine.UI.Button>();
            LoginButton.onClick.Invoke();

            yield return Measure.Frames().Run();
            stopwatch.Stop();
            Debug.Log(stopwatch.ElapsedMilliseconds);
        }
        // measure memory << server side performance measurement 
        [UnityTest, Performance]
        public void Measure_Memory()
        {
            var allocated = new SampleGroupDefinition("TotalAllocatedMemory", SampleUnit.Megabyte);
            var reserved = new SampleGroupDefinition("TotalReservedMemory", SampleUnit.Megabyte);
            for (var i = 0; i < 60; i++)
            {
                Measure.Custom(allocated, Profiler.GetTotalAllocatedMemoryLong() / 1048576f);
                Measure.Custom(reserved, Profiler.GetTotalReservedMemoryLong() / 1048576f);
                yield return null;
            }
        }
        // Scene Measurement
        [UnityTest, Performance]
        public IEnumerator Rendering_Scene()
        {
            stopwatch.Reset();
            stopwatch.Start();

            using (Measure.Scope(new SampleGroupDefinition("Test LandingPage")))
            {
                SceneManager.LoadScene("LandingPage");
            }
            yield return null;

            yield return Measure.Frames().Run();

            //yield return Measure.Frames().Run();
            stopwatch.Stop();
            Debug.Log(stopwatch.ElapsedMilliseconds);
        }
        //Leaderboard test
        [UnityTest, Performance]
        public IEnumerator Gameflow_Test()
        {
            stopwatch.Reset();
            stopwatch.Start();

            using (Measure.Scope(new SampleGroupDefinition("Setup.LoadScene")))
            {
                SceneManager.LoadScene("Login");
            }
            yield return null;


            yield return new WaitForSeconds(.001f);

            TMP_InputField Email = GameObject.Find("login_username").GetComponent<TMP_InputField>();
            Email.text = "a";


            TMP_InputField Password = GameObject.Find("login_password").GetComponent<TMP_InputField>();

            Password.text = "a";

            yield return new WaitForSeconds(.001f);

            UnityEngine.UI.Button LoginButton = GameObject.Find("Login Button").GetComponent<UnityEngine.UI.Button>();
            LoginButton.onClick.Invoke();

            yield return new WaitForSeconds(1);

            UnityEngine.UI.Button leaderBoardButton = GameObject.Find("Leaderboard Button").GetComponent<UnityEngine.UI.Button>();
            leaderBoardButton.onClick.Invoke();

            yield return new WaitForSeconds(2);

            UnityEngine.UI.Button LoginButton = GameObject.Find("Button").GetComponent<UnityEngine.UI.Button>(); // back button 
            LoginButton.onClick.Invoke();

            yield return new WaitForSeconds(1);

            UnityEngine.UI.Button StartButton = GameObject.Find("Start Button").GetComponent<UnityEngine.UI.Button>(); // start button 
            StartButton.onClick.Invoke();

            yield return new WaitForSeconds(2);

            //DungeonMode Button
            UnityEngine.UI.Button DungeonModeButton = GameObject.Find("DungeonMode Button").GetComponent<UnityEngine.UI.Button>(); 
            DungeonModeButton.onClick.Invoke();

            yield return new WaitForSeconds(2);

            //World Button
            UnityEngine.UI.Button World1 = GameObject.Find("World1").GetComponent<UnityEngine.UI.Button>(); 
            World1.onClick.Invoke();

            yield return new WaitForSeconds(2);

            //Section 1 Button
            UnityEngine.UI.Button Section1 = GameObject.Find("Section 1 Button").GetComponent<UnityEngine.UI.Button>(); 
            Section1.onClick.Invoke();

            yield return new WaitForSeconds(1);

            // Character - Warrior
            //Warrior Button
            UnityEngine.UI.Button Warrior = GameObject.Find("Warrior").GetComponent<UnityEngine.UI.Button>(); 
            Warrior.onClick.Invoke();

            //Mage Button
            UnityEngine.UI.Button Mage = GameObject.Find("Mage").GetComponent<UnityEngine.UI.Button>();  
            Mage.onClick.Invoke();

            //Barbarian Button
            UnityEngine.UI.Button Barbarian = GameObject.Find("Barbarian").GetComponent<UnityEngine.UI.Button>();  
            Barbarian.onClick.Invoke();

            //Confirm Button
            UnityEngine.UI.Button ConfirmButton = GameObject.Find("Confirm Button").GetComponent<UnityEngine.UI.Button>(); 
            ConfirmButton.onClick.Invoke();

            yield return Measure.Frames().Run();

            //yield return Measure.Frames().Run();
            stopwatch.Stop();
            Debug.Log(stopwatch.ElapsedMilliseconds);
        }
    }
}
