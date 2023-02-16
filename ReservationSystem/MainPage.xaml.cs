using System;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using TimePicker = Xamarin.Forms.TimePicker;

namespace ReservationSystem
{
    public partial class MainPage : ContentPage
    {
        // Initializes the meeting locations list
        string[] meetingLocations = { "Conference Room A", "Conference Room B", "Conference Room C" };

        //Creates Labels, Date Picker, Time Picker, Slider, Switch, Picker, and Button
        Label date = new Label
        {
            Text = "Select a date below:",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            TextColor = Color.Black,
        };
        Xamarin.Forms.DatePicker datePicker = new Xamarin.Forms.DatePicker
        {
            Format = "D",
            MinimumDate = DateTime.Today,
            MaximumDate = DateTime.Today.AddDays(7),
            TextColor = Color.Black,
        };
        Label startingTime = new Label
        {
            Text = "Please choose a starting time:",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            TextColor = Color.Black,
        };
        TimePicker timePicker = new Xamarin.Forms.TimePicker
        {
            Format = "T",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            TextColor = Color.Black,
        };
        Label duration = new Label
        {
            Text = "Move the slider base on the duration of your meeting:",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            TextColor = Color.Black,
        };
        Label sliderLabel = new Label
        {
            Text = "0 hours",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            TextColor = Color.Black,
        };
        Xamarin.Forms.Slider durationSlider = new Xamarin.Forms.Slider
        {
            Minimum = 0,
            Maximum = 4,
            Value = 0,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            WidthRequest = 20,
        };
        
        Label virtualQuestion = new Label
        {
            Text = "Will you be attending virtually?",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            TextColor = Color.Black,
        };
        Switch virtualAttendSwitch = new Switch
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.CenterAndExpand,
        };
        Label location = new Label
        {
            Text = "Please select a location for your meeting:",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            TextColor = Color.Black,
        };
        Xamarin.Forms.Picker locationPicker = new Xamarin.Forms.Picker
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.CenterAndExpand,

        };
        Button confirmEntry = new Button
        {
            Text = "Confirm Entry",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center,
        };


        public MainPage()
        {
            durationSlider.ValueChanged += (sender, e) =>
            {
                double value = e.NewValue;
                int hours = (int)value;
                string text = hours + " hours";
                sliderLabel.Text = text;
            };
            confirmEntry.Clicked += SubmitReservation;

            // Add the meeting locations to the picker control
            locationPicker.ItemsSource = meetingLocations;
            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    date, datePicker, startingTime, timePicker, duration, sliderLabel, durationSlider, virtualQuestion, virtualAttendSwitch, location, locationPicker, confirmEntry
                },
                HeightRequest = 100,
            };
            this.Content = stackLayout;
            this.BackgroundColor = Color.SeaGreen;
        }

        private async void SubmitReservation(object sender, EventArgs e)
        {
            // Retrieves the user inputs
            DateTime date = datePicker.Date;
            TimeSpan startTime = timePicker.Time;
            int duration = (int)durationSlider.Value;
            bool virtualAttend = virtualAttendSwitch.IsToggled;
            string location = locationPicker.SelectedItem?.ToString();

            // Validates the user inputs
            if (string.IsNullOrEmpty(location))
            {
                await DisplayAlert("Error", "Please fill out all fields", "OK");
            }
            else
            {
                // Creates a reservation object with the user inputs
                Reservation reservation = new Reservation(date, startTime, duration, virtualAttend, location);


                // Builds the information message
                string virtualAttendString = virtualAttend ? "virtual" : "nonvirtual";
                string formattedDate = date.ToString("MM/dd/yyyy");
                string formattedStartTime = startTime.ToString(@"hh\:mm");
                string output = $"Your reservation for a {virtualAttendString} meeting in {location} starting at {formattedStartTime} on {formattedDate} for {duration} hours has been added.";

                // Displays the confirmation message
                await DisplayAlert("Success", output, "OK");
            }

        }

        public class Reservation
        {
            public DateTime Date { get; set; }
            public TimeSpan StartTime { get; set; }
            public int Duration { get; set; }
            public bool VirtualAttend { get; set; }
            public string Location { get; set; }

            public Reservation(DateTime date, TimeSpan startTime, int duration, bool virtualAttend, string location)
            {
                Date = date;
                StartTime = startTime;
                Duration = duration;
                VirtualAttend = virtualAttend;
                Location = location;
            }
        }
    }
}