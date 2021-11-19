using System;

namespace DreamTeam.Lighthouse.Core.Events
{
    /// <summary>
    /// Base class for game events
    /// </summary>
    public abstract class GameEvent
    {
        public Guid Id { get; set; }

        public EventStatus Status { get; set; }

        public int DelayInMiliSeconds { get; set; }

        protected GameEvent(int delayInMiliSeconds = 0)
        {
            Id = new Guid();
            Status = EventStatus.NotQueued;
            DelayInMiliSeconds = delayInMiliSeconds;
        }

        protected internal abstract bool IsReady();

        protected internal abstract void Run();

        protected internal abstract bool HasEnded();
    }
}
