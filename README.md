# Override-OVRTelemetry-Registry
Override OVRTelemetry TelemetryEnabled in Registry to remove annoying popup

Problem:
If you can not get rid of this Popup:

Help to Improve Meta SDKs

Allow Meta to collect usage data on its SDKs, such as package name, class names and plugin configuration in your projects using Meta SDKs on this machine. This data helps improve the Meta SDKs and is collected in accordance with Meta's Privacy Policy.

You can always change your selection at:  Edit > Preferences > Meta XR > Telemetry


Solution:
1. Place OVRTelemetryEditorPrefs.cs in Editor folder inside the Assets folder of your Unity project!

2. In menu select EditorPrefs/OVRTelemetry TelemetryEnabled

3. Click on Button "Save value: 0" to add the Key "OVRTelemetry.TelemetryEnabled" with REG_DWORD value 0 to your registry.

4. Enjoy the silence!
