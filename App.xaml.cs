﻿using UTSLostAndFound.Views;

namespace UTSLostAndFound;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new LoginPage();
    }
}
