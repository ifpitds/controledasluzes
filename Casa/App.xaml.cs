using System.Net;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechRecognition;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;

namespace Casa
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
           
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
            try
            {
                var vcd = await Package.Current.InstalledLocation.GetFileAsync(@"Controle.xml");
                await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(vcd);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        /// 
        protected override async void OnActivated(IActivatedEventArgs e)

        {
            // Handle when app is launched by Cortana
            if (e.Kind == ActivationKind.VoiceCommand)
            {
                VoiceCommandActivatedEventArgs commandArgs = e as VoiceCommandActivatedEventArgs;
                SpeechRecognitionResult speechRecognitionResult = commandArgs.Result;

                string voiceCommandName = speechRecognitionResult.RulePath[0];
                string textSpoken = speechRecognitionResult.Text;
                IReadOnlyList<string> recognizedVoiceCommandPhrases;

                System.Diagnostics.Debug.WriteLine("voiceCommandName: " + voiceCommandName);
                System.Diagnostics.Debug.WriteLine("textSpoken: " + textSpoken);

                MessageDialog messageDialog = new MessageDialog("");

                switch (voiceCommandName)
                {
                    case "Ligar Sala":
                        System.Diagnostics.Debug.WriteLine("Ligar Sala");
                      //  HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create ("http://192.168.0.99/?l5");
                        var client = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?l5") };
                        await client.GetAsync("http://192.168.0.99/?l5");
                        //    public class HttpClient = 
                        //messageDialog.Content = "Ligar_Sala command";
                        break;
                        

                    case "Desligar Sala":
                        var client1 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?d5") };
                        await client1.GetAsync("http://192.168.0.99/?d5");

                        //string temperature = "";

                        //  if (speechRecognitionResult.SemanticInterpretation.Properties.TryGetValue("temperature", out recognizedVoiceCommandPhrases))
                        // {
                        //    temperature = recognizedVoiceCommandPhrases.First();
                        // }

                        // messageDialog.Content = "Change_Temperature command. The passed PhraseTopic value is " + temperature;
                        break;

                    case "Ligar Sala 2":
                        var client2 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?l6") };
                        await client2.GetAsync("http://192.168.0.99/?l6");
                        break;

                    case "Desligar Sala 2":
                        var client3 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?d6") };
                        await client3.GetAsync("http://192.168.0.99/?d6");
                        break;

                    case "Ligar Sala 3":
                        var client4 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?l7") };
                        await client4.GetAsync("http://192.168.0.99/?l7");
                        break;

                    case "Desligar Sala 3":
                        var client5 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?d7") };
                        await client5.GetAsync("http://192.168.0.99/?d7");
                        break;

                    case "Ligar Jardim":
                        var client6 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?l2") };
                        await client6.GetAsync("http://192.168.0.99/?l2");
                        break;

                    case "Desligar Jardim":
                        var client7 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?d2") };
                        await client7.GetAsync("http://192.168.0.99/?d2");
                        break;

                    case "Ligar Jardim 2":
                        var client8 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?l3") };
                        await client8.GetAsync("http://192.168.0.99/?l3");
                        break;

                    case "Desligar Jardim 2":
                        var client9 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?d3") };
                        await client9.GetAsync("http://192.168.0.99/?d3");
                        break;

                    case "Ligar Garagem":
                        var client10 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?l4") };
                        await client10.GetAsync("http://192.168.0.99/?l4");
                        break;

                    case "Desligar Garagem":
                        var client11 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?d4") };
                        await client11.GetAsync("http://192.168.0.99/?d4");
                        break;

                    case "Ligar Copa":
                        var client12 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?l8") };
                        await client12.GetAsync("http://192.168.0.99/?l8");
                        break;

                    case "Desligar Copa":
                        var client13 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?d8") };
                        await client13.GetAsync("http://192.168.0.99/?d8");
                        break;

                    case "Ligar Cozinha":
                        var client14 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?l9") };
                        await client14.GetAsync("http://192.168.0.99/?l9");
                        break;

                    case "Desligar Cozinha":
                        var client15 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?d9") };
                        await client15.GetAsync("http://192.168.0.99/?d9");
                        break;

                    case "Ligar Tudo":
                        var client16 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?l2,?l3,?l4,?l5,?l6,?l7,?l8,?l9") };
                        await client16.GetAsync("http://192.168.0.99/?l2,?l3,?l4,?l5,?l6,?l7,?l8,?l9");
                        break;

                    case "Desligar Tudo":
                        var client17 = new HttpClient { BaseAddress = new Uri("http://192.168.0.99/?d2,?d3,?d4,?d5,?d6,?d7,?d8,?d9") };
                        await client17.GetAsync("http://192.168.0.99/?d2,?d3,?d4,?d5,?d6,?d7,?d8,?d9");
                        break;


                    //string color = "";

                    //if (speechRecognitionResult.SemanticInterpretation.Properties.TryGetValue("colors", out recognizedVoiceCommandPhrases))
                    //{
                    //    color = recognizedVoiceCommandPhrases.First();
                    //}

                    //                        messageDialog.Content = "Change_Light_Color command. The passed PhraseList value is " + color;


                    default:
                        messageDialog.Content = "Unknown command";
                        break;
                }


                // dialog que abre final  //      await messageDialog.ShowAsync();
               
                Exit();
            }
        }

        //  {
        //
        //      if (e.Kind != ActivationKind.VoiceCommand) return;
        //      var cmd = e as VoiceCommandActivatedEventArgs;
        //      var result = cmd?.Result;


        //            var commander = result?.RulePath[0];

        //          var dialog = new MessageDialog("");

        //        switch (commander)
        //      {
        //        case "diga olá":
        //          dialog.Content = "Funcionou";
        //        break;
        //  }

        //  await dialog.ShowAsync();
        //  Debug.WriteLine("teste");
        // }
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
