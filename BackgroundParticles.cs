using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class BackgroundParticles : StoryboardObjectGenerator
    {
        [Configurable]
        public String Path = "sb/particle.png";

        [Configurable]
        public int Start;

        [Configurable]
        public int End;
        
        [Configurable]
        public int Count;

        [Configurable]
        public int Lifetime;

        public override void Generate()
        {
            End = Math.Min(End, (int) AudioDuration);
            Start = Math.Min(Start, End);

            int duration = End - Start;

            StoryboardLayer layer = GetLayer("");

            for (int i = 0; i < Count; i++) {
                OsbSprite particle = layer.CreateSprite(Path, OsbOrigin.Centre, RandomPos() * 50);
                Vector2 direction = new Vector2(Random(-1, 1), Random(-1, 1));

                particle.StartLoopGroup(Start, duration / Lifetime);
                particle.Move(Start, End, particle.InitialPosition, Vector2.Multiply(direction, 100));
                particle.EndGroup();
            }
        }

        private Vector2 RandomPos() {
            return new Vector2(Random(0, 1), Random(0, 1));
        }
    }
}
