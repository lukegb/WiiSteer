WiiSteer
========

WiiSteer is a weekend (one day, really) project that was originally meant to allow me (lukegb) to use my Wiimote as a steering-wheel substitute in Euro Truck Simulator 2.

It's a quick C# WinForms program that does actually manage to achieve this!

Tools
-----

 * Windows 8 :)
 * Visual Studio 2012
 * [vJoy](http://vjoystick.sf.net) (SDK: [vJoy202SDK-011112.zip](http://sourceforge.net/projects/vjoystick/files/Beta%202.x/SDK/vJoy202SDK-011112.zip/download), Driver: [vJoy_x86x64_I011112.exe](http://sourceforge.net/projects/vjoystick/files/Beta%202.x/2.0.2%20011112/vJoy_x86x64_I011112.exe/download))
 * [WiimoteLib](http://www.brianpeek.com/page/wiimotelib)

Install notes
-------------

I've included a precompiled "release" version that will run if you have .NET Framework 4.5 and vJoy installed. See v0.1.zip in the git repo (sorry!).

 * Download WiiSteer!
 * Install vJoy using [vJoy_x86x64_I011112.exe](http://sourceforge.net/projects/vjoystick/files/Beta%202.x/2.0.2%20011112/vJoy_x86x64_I011112.exe/download) - a reboot will be required!
 * Make sure you have .NET Framework 4.5 installed
 * Set up vJoy using the "Configure vJoy" program - needs admin rights!
	- Check the following settings are selected/correct:
		- Basic axes:
			* X
			* Y
			* Z
			* R/Rz/Rudder
			* (nothing else under Basic Axes should be selected)
		- Action:
			* Configure
		- Target Device:
			* Should be set to *1*
		- Number of Buttons:
			* Should be set to *12*
		- POV Hat Switch:
			* 4 Directions: unset
			* Continuous: unset
			* POVs: *0*
	- Click "OK" and wait...
	- If told you need to restart, click "Restart Later" (i.e. ignore it!)
 * Connect the Wiimote to your computer:
	- Windows 8:
		- Press "Windows key" and R simultaneously
		- Type "control" and press Enter
		- Click "Add a device"
		- Press 1 and 2 at the same time on the Wiimote
		- Click on Nintendo RVL-CNT-01 on the list
		- When prompted for a PIN, do not type anything and click Next
		- Wait...
 * Launch WiiSteer
 * Click "Connect" and wait a few seconds until "Connected" appears in the textbox
 * Run the Windows Joystick Calibration Wizard
	- Windows 8:
		- Press "Windows key" and R simultaneously
		- Type "control" and press Enter
		- In the search box in the top right, type "joystick"
		- Wait...
		- Under "Devices and Printers", click "Set up USB game controllers"
		- Double-click "vJoy Device"
		- Click the "Settings" tab at the top
		- Click "Calibrate..." and follow the instructions - the "idle" position for the Wiimote is *face up* on a *flat surface* (NB: Z rotation doesn't do anything - just skip it)

Button notes
------------

All the buttons on the Wiimote *apart from Power* are mapped to a joystick button.

Compilation notes
-----------------

Install the vJoy and Wiimotelib SDKs, and point Visual Studio at them manually using References. Everything should work fine.