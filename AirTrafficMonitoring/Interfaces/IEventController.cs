using System.Collections.Generic;

namespace AirTrafficMonitoring
{
  public interface IEventController
  {
      void seperationsDetected(List<SeperationEvent> newSeperationEvents);
  }
}