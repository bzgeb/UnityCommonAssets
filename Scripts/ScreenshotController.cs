using UnityEngine;
using System.Collections;

public class ScreenshotController : MonoBehaviour
{
    void Update() {
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize1-" + Time.timeSinceLevelLoad + ".png", 1 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha2 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize2-" + Time.timeSinceLevelLoad + ".png", 2 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha3 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize3-" + Time.timeSinceLevelLoad + ".png", 3 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha4 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize4-" + Time.timeSinceLevelLoad + ".png", 4 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha5 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize5-" + Time.timeSinceLevelLoad +  ".png", 5 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha6 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize6-" + Time.timeSinceLevelLoad + ".png", 6 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha7 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize7-" + Time.timeSinceLevelLoad + ".png", 7 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha8 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize8-" + Time.timeSinceLevelLoad + ".png", 8 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha9 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize9-" + Time.timeSinceLevelLoad + ".png", 9 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha0 ) ) {
            Application.CaptureScreenshot( "ScreenshotSize10-" + Time.timeSinceLevelLoad + ".png", 10 );
        }
    }
}
