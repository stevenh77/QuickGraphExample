using System.Collections.Generic;

namespace QuickGraphExample
{
    public class Station
    {
        private readonly List<TrainLine> trainLines = new List<TrainLine>();

        public string Name { get; set; }

        public IEnumerable<TrainLine> TrainLines
        {
            get { return trainLines; }
        }

        public void AddTrainLine(TrainLine trainLine)
        {
            trainLines.Add(trainLine);
        }

        public void RemoveTrainLine(TrainLine trainLine)
        {
            trainLines.Remove(trainLine);
            trainLine.RemoveStation(this);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
