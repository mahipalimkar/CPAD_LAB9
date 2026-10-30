using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace WidgetDemoApp
{
    public partial class MainPage : ContentPage
    {
        // Counter that tracks how many times Like has been tapped
        int likeCount = 0;

        // Collection bound to the CollectionView in XAML
        public List<string> Skills { get; } = new List<string>
        {
            "C#", "Xamarin", ".NET", "Git", "XAML", "SQL"
        };

        public MainPage()
        {
            InitializeComponent();

            // Lets {Binding Skills} in XAML find the property above
            BindingContext = this;
        }

        // Like button: increase the counter and update the button text
        void OnLikeClicked(object sender, EventArgs e)
        {
            likeCount++;
            LikeButton.Text = $"Like ({likeCount})";
        }

        // Message button: show an alert, including any comment typed
        async void OnMessageClicked(object sender, EventArgs e)
        {
            string comment = string.IsNullOrWhiteSpace(CommentEntry.Text)
                ? "No comment entered."
                : "Comment: " + CommentEntry.Text;

            await DisplayAlert("Message", comment, "OK");
        }

        // Switch: update the label to show the current on/off value
        void OnAvailabilityToggled(object sender, ToggledEventArgs e)
        {
            AvailabilityLabel.Text =
                "Available for projects: " + (e.Value ? "Yes" : "No");
        }
    }
}