using System;

namespace DreamTeam.Lighthouse.Core.Events
{
    public class Animation2DEvent : GameEvent
    {
        protected internal override void Run()
        {
            Console.WriteLine($"{nameof(Animation2DEvent)} {Id} started running...");
        }

        protected internal override bool IsReady()
        {
            var someDependencyIsFullfilled = false;

            Console.WriteLine($"{nameof(Animation2DEvent)} {Id} is validating...");

            // Add your event logic here
            someDependencyIsFullfilled = true;

            return someDependencyIsFullfilled;
        }

        protected internal override bool HasEnded()
        {
            bool endConditionHasBeenMet = false;

            Console.WriteLine($"{nameof(Animation2DEvent)} {Id} is checking its duration...");

            // Add your event logic here
            endConditionHasBeenMet = true;

            Console.WriteLine($"{nameof(Animation2DEvent)} {Id} has ended...");

            return endConditionHasBeenMet;
        }
    }
}
