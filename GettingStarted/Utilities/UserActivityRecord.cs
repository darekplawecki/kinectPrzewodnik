using System;
using Microsoft.Kinect;

namespace Przewodnik.Utilities
{
    class UserActivityRecord
    {
        // Activity level, above which a user is considered to be in "active" state.
        private const double ActivityMetricThreshold = 0.1;

        private double activityLevel;

        public UserActivityRecord(SkeletonPoint position, int updateId, long timestamp)
        {
            this.ActivityLevel = 0.0;
            this.LastPosition = position;
            this.LastUpdateId = updateId;
            this.IsActive = false;
            this.StateTransitionTimestamp = timestamp;
        }

        public double ActivityLevel
        {
            get
            {
                return this.activityLevel;
            }

            private set
            {
                this.activityLevel = Math.Max(0.0, Math.Min(1.0, value));
            }
        }

        public int LastUpdateId { get; private set; }

        public bool IsActive { get; private set; }

        public long StateTransitionTimestamp { get; private set; }

        public SkeletonPoint LastPosition { get; private set; }

        public void Update(SkeletonPoint position, int updateId, long timestamp)
        {
            // Movement magnitude gets scaled by this amount in order to get the current activity metric
            const double DeltaScalingFactor = 10.0;

            // Controls how quickly new values of the metric displace old values. 1.0 means that new values
            // for metric immediately replace old values, while smaller decay amounts mean that old metric
            // values influence the metric for a longer amount of time (i.e.: decay more slowly).
            const double ActivityDecay = 0.1;

            var delta = new SkeletonPoint
            {
                X = position.X - this.LastPosition.X,
                Y = position.Y - this.LastPosition.Y,
                Z = position.Z - this.LastPosition.Z
            };

            double deltaLengthSquared = (delta.X * delta.X) + (delta.Y * delta.Y) + (delta.Z * delta.Z);
            double newMetric = DeltaScalingFactor * Math.Sqrt(deltaLengthSquared);

            this.ActivityLevel = ((1.0 - ActivityDecay) * this.ActivityLevel) + (ActivityDecay * newMetric);

            bool newIsActive = this.ActivityLevel >= ActivityMetricThreshold;

            if (newIsActive != this.IsActive)
            {
                this.IsActive = newIsActive;
                this.StateTransitionTimestamp = timestamp;
            }

            this.LastPosition = position;
            this.LastUpdateId = updateId;
        }
    }
}
