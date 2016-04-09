Feature: ChangeDateTime
	In order to change my devices date and time
	As a user
	I want to be change my device date time to feature

Background: 
	Given I use 'Android' device with uid '015d2a4ff71bee08' and device name 'test'
	And   I start app with appActivity '.Settings' and appPackage 'com.android.settings'
	And   Appium server has address '127.0.0.1' with port listen '6969'
	
Scenario: Change date time to feature with nexus 7
	Given I Have open setting on device
	
