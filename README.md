Reservation System
This C# code contains a Xamarin.Forms application that allows users to create a reservation for a meeting. The application prompts the user to input a date, starting time, duration, whether the meeting will be attended virtually, and the location of the meeting. After submitting the reservation, the application displays a confirmation message.

Prerequisites
The following are required to run the application:

.NET Framework
Xamarin.Forms
Installation
Clone the repository to a local directory.
Open the solution file in Visual Studio.
Build and run the application.
Usage
Select a date using the date picker.
Select a starting time using the time picker.
Move the slider to set the duration of the meeting.
Toggle the switch to indicate whether the meeting will be attended virtually.
Select a location using the picker.
Click the "Confirm Entry" button to submit the reservation.
If all fields are filled out, a confirmation message will be displayed.
Class Documentation
MainPage
The MainPage class contains the user interface for the reservation system. It has the following components:

meetingLocations - An array of meeting locations.
date - A Label that prompts the user to select a date.
datePicker - A DatePicker that allows the user to select a date.
startingTime - A Label that prompts the user to select a starting time.
timePicker - A TimePicker that allows the user to select a starting time.
duration - A Label that prompts the user to move the slider to set the duration of the meeting.
sliderLabel - A Label that displays the current value of the slider.
durationSlider - A Slider that allows the user to set the duration of the meeting.
virtualQuestion - A Label that prompts the user to indicate whether the meeting will be attended virtually.
virtualAttendSwitch - A Switch that allows the user to indicate whether the meeting will be attended virtually.
location - A Label that prompts the user to select a location for the meeting.
locationPicker - A Picker that allows the user to select a location for the meeting.
confirmEntry - A Button that submits the reservation.
The MainPage class also contains the following methods:

SubmitReservation - A method that retrieves the user inputs, validates them, creates a reservation object, and displays a confirmation message.
Reservation - A class that represents a reservation. It has the following properties:
Date - The date of the meeting.
StartTime - The starting time of the meeting.
Duration - The duration of the meeting.
VirtualAttend - A boolean that indicates whether the meeting will be attended virtually.
Location - The location of the meeting.
