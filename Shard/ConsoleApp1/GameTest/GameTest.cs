using GameTest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Shard
{
    class GameTest : Game, InputListener
    {
        GameObject background;
        Music music;

        public override void initialize()
        {
            Bootstrap.getInput().addListener(this);
            createBackground();

            SetupMusic();

            Bootstrap.getSound().PlayMusic(music.FilePath);
        }

        public override void update()
        {
            music.PositionSeconds = Bootstrap.getSound().MusicPosition;

            //Debug.Log(Bootstrap.getSound().MusicPosition + " / " + Bootstrap.getSound().MusicLength);

            //Bootstrap.getDisplay().showText("FPS: " + Bootstrap.getSecondFPS() + " / " + Bootstrap.getFPS(), 10, 10, 12, 255, 255, 255, 255);
            //Bootstrap.getDisplay().showText($"Position: {Bootstrap.getSound().MusicPosition} / {Bootstrap.getSound().MusicLength}", 10, 30, 12, 255, 255, 255, 255);
            //Bootstrap.getDisplay().showText($"Beat: {(int)music.PositionBeats + (int)(music.PositionBeats * 100) / 25 % 4 * 25 * 0.01 }", 10, 50, 12, 255, 255, 255, 255);
        }

        public override int getTargetFrameRate()
        {
            return 75;

        }
        public void createBackground()
        {
            background = new GameObject();
            background.Transform.SpritePath = getAssetManager().getAssetPath ("rhythm_game_background.png");
            background.Transform.X = 0;
            background.Transform.Y = 0;
            background.Visible = true;
            background.Layer = 0;
            background.Transform.SetSize(
                Bootstrap.getDisplay().getWidth(),
                Bootstrap.getDisplay().getHeight());
        }

        public void handleInput(InputEvent ie)
        {
            switch (ie.Type)
            {
                case InputEventType.MouseDown:

                    break;
            }
        }

        private void SetupOldMusic()
        {
            int displayWidth = Bootstrap.getDisplay().getWidth();
            int displayHeight = Bootstrap.getDisplay().getHeight();
            Random random = new Random();

            music.StartCreating();

            music = new Music("Coldplay - Clocks", "clocks.wav", 131.0, 0.24);
            for (int i = 0; i < 600; i += 4)
            {
                music.AddNoteAndPause(1.5);
                music.AddNoteAndPause(1.5);
                music.AddNoteAndPause(1);
            }
        }

        private void SetupMusic()
        {
            int displayWidth = Bootstrap.getDisplay().getWidth();
            int displayHeight = Bootstrap.getDisplay().getHeight();
            Random random = new Random();

            music = new Music("Coldplay - Clocks", "clocks.wav", 131.0, 0.24);

            music.StartCreating();

            music.AddPause(16);
            music.AddNoteAndPause(4);
            music.AddNoteAndPause(4);
            music.AddNoteAndPause(4);
            music.AddNoteAndPause(4);

            for (int i = 0; i < 8; i++)
            {
                music.AddNoteAndPause(1.5, 500, 400);
                music.AddNoteAndPause(1.5, 600, 400);
                music.AddNoteAndPause(1.0, 700, 400);
            }

            // Refrain 1

            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.5);



            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.5);



            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.5);



            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(0.5);



            music.AddPause(1.0);     
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.5);



            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(0.5);



            music.AddPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.5);



            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(0.5);



            for (int i = 0; i < 16; i++)
            {
                music.AddNoteAndPause(1.5);
                music.AddNoteAndPause(1.5);
                music.AddNoteAndPause(1.0);
            }



            // Refrain 2

            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.0);


            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.5);



            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(0.5);



            music.AddPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.0);
            music.AddNoteAndPause(0.5);



            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(0.5);



            music.AddPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.5);



            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(0.5);



            music.AddPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(2.0);
            music.AddNoteAndPause(0.5);



            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);

            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(1.0);
            music.AddNoteAndPause(1.5);
            music.AddNoteAndPause(0.5);
            music.AddNoteAndPause(0.5);



            for (int i = 0; i < 16; i++)
            {
                music.AddNoteAndPause(1.5);
                music.AddNoteAndPause(1.5);
                music.AddNoteAndPause(1.0);
            }



            for (int i = 0; i < 16; i++)
            {
                music.AddNoteAndPause(0.5, 300, 300);
                music.AddNoteAndPause(0.5, 400, 300);
                music.AddNoteAndPause(0.5, 500, 300);
                music.AddNoteAndPause(0.5, 300, 300);
                music.AddNoteAndPause(0.5, 400, 300);
                music.AddNoteAndPause(0.5, 500, 300);
                music.AddNoteAndPause(0.5, 300, 300);
                music.AddNoteAndPause(0.5, 500, 300);
            }
        }
    }
}
