using System;
using System.Reflection;

namespace BasicTest
{
    /// <summary>
    /// Manual test to verify ImageConverter fix without GitVersioning build issues
    /// </summary>
    public static class ImageConverterManualTest
    {
        public static void RunTests()
        {
            Console.WriteLine("=== ImageConverter Fix Verification ===");
            
            try
            {
                // Use reflection to access the internal ImageConverter class
                var converterType = Assembly.LoadFrom("../../src/TrackSeries.TheTVDB.Client/bin/Debug/netstandard2.0/TrackSeries.TheTVDB.Client.dll")
                    .GetType("TrackSeries.TheTVDB.Client.ImageConverter");
                
                if (converterType == null)
                {
                    Console.WriteLine("❌ Could not load ImageConverter type");
                    return;
                }

                var method = converterType.GetMethod("CheckAndConvertToCompleteUrl", 
                    BindingFlags.Static | BindingFlags.NonPublic);
                
                if (method == null)
                {
                    Console.WriteLine("❌ Could not find CheckAndConvertToCompleteUrl method");
                    return;
                }

                // Test the main issue case
                TestCase(method, "v4/series/462199/banners/67eef3239c55e.jpg", 
                    "https://artworks.thetvdb.com/banners/v4/series/462199/banners/67eef3239c55e.jpg",
                    "Main issue case");

                // Test other cases
                TestCase(method, "some-image.jpg", 
                    "https://artworks.thetvdb.com/banners/some-image.jpg",
                    "Simple image");

                TestCase(method, "banners/some-image.jpg", 
                    "https://artworks.thetvdb.com/banners/some-image.jpg",
                    "Already starts with banners/");

                TestCase(method, "path/to/banners/image.jpg", 
                    "https://artworks.thetvdb.com/banners/path/to/banners/image.jpg",
                    "Banners in middle of path");

                TestCase(method, "http://example.com/image.jpg", 
                    "http://example.com/image.jpg",
                    "Complete HTTP URL");

                Console.WriteLine("✅ All ImageConverter tests completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error running ImageConverter tests: {ex.Message}");
                Console.WriteLine("This is expected if the assembly hasn't been built yet.");
            }
            
            Console.WriteLine("=== End ImageConverter Verification ===\n");
        }

        private static void TestCase(MethodInfo method, string input, string expected, string description)
        {
            try
            {
                var result = method.Invoke(null, new object[] { input }) as string;
                bool passed = result == expected;
                
                Console.WriteLine($"{(passed ? "✓" : "✗")} {description}:");
                Console.WriteLine($"    Input: '{input}'");
                Console.WriteLine($"    Expected: '{expected}'");
                Console.WriteLine($"    Actual: '{result}'");
                
                if (!passed)
                {
                    Console.WriteLine("    ❌ TEST FAILED");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ {description}: Error - {ex.Message}");
            }
        }
    }
}