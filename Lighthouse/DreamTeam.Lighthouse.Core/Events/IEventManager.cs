namespace DreamTeam.Lighthouse.Core.Events
{
    public interface IEventManager
    {
        public void AddEvent(GameEvent gameEvent, int delayInMiliSeconds = 0);

        public GameEvent CurrentEvent();

        public GameEvent NextEvent();

        public void ConstantRun();
    }
}
