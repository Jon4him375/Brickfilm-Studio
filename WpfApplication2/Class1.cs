using Splicer.Renderer;
using Splicer.Timeline;
using Splicer.WindowsMedia;
using Splicer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace WpfApplication2
{
    class Class1
    {
      

        // generates a little slide-show, with audio track and fades between images.




        // generates a little slide-show, with audio track and fades between images.

        public static IRenderer renderer;
        public static void Renderer()
        {


        }
      





        public static void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string outputFile = "FadeBetweenImages.wmv";



            using (ITimeline timeline = new DefaultTimeline())

            {

                IGroup group = timeline.AddVideoGroup(32, 160, 100);



                ITrack videoTrack = group.AddTrack();

                IClip clip1 = videoTrack.AddImage("Snapshot1.png", 0, 2); // play first image for a little while

                IClip clip2 = videoTrack.AddImage("Snapshot2.png", 0, 2); // and the next

                IClip clip3 = videoTrack.AddImage("Snapshot3.png", 0, 2); // and finally the last

                IClip clip4 = videoTrack.AddImage("Snapshot4.png", 0, 2); // and finally the last



                double halfDuration = 0.5;



                // fade out and back in

                group.AddTransition(clip2.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);

                group.AddTransition(clip2.Offset, halfDuration, StandardTransitions.CreateFade(), false);



                // again

                group.AddTransition(clip3.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);

                group.AddTransition(clip3.Offset, halfDuration, StandardTransitions.CreateFade(), false);



                // and again

                group.AddTransition(clip4.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);

                group.AddTransition(clip4.Offset, halfDuration, StandardTransitions.CreateFade(), false);



                // add some audio

                /*      ITrack audioTrack = timeline.AddAudioGroup().AddTrack();



                      IClip audio =

                         audioTrack.AddAudio("testinput.wav", 0, videoTrack.Duration);*/



                // create an audio envelope effect, this will:

                // fade the audio from 0% to 100% in 1 second.

                // play at full volume until 1 second before the end of the track

                // fade back out to 0% volume

                //   audioTrack.AddEffect(0, audio.Duration,

                //  StandardEffects.CreateAudioEnvelope(1.0, 1.0, 1.0, audio.Duration));


           //     renderer = new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.HighQualityVideo) { };

                WindowsMediaRenderer media = new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.HighQualityVideo);
                { renderer.Render(); };

                renderer.Render();


            }
        }
    }
}
