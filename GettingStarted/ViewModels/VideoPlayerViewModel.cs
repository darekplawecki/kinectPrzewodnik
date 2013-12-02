using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Przewodnik.ViewModels
{
    class VideoPlayerViewModel : ViewModelBase
    {
        private State currentState = State.Stopped;

        private enum State
        {
            Playing,
            Paused,
            Stopped,
        }

        private State CurrentState
        {
            get
            {
                return this.currentState;
            }
            set
            {
                this.currentState = value;
                this.OnPropertyChanged("CanResume");
                this.OnPropertyChanged("CanPause");
                this.OnPropertyChanged("CanReplay");
            }
        }

        public bool CanResume
        {
            get { return State.Paused == this.CurrentState; }
        }

        public bool CanPause
        {
            get { return State.Playing == this.CurrentState; }
        }

        public bool CanReplay
        {
            get { return State.Stopped == this.CurrentState; }
        }

        public VideoPlayerViewModel()
            : base()
        {
            
        }

        public void setPlayingState()
        {
            this.CurrentState = State.Playing;
        }

        public void setPausedState()
        {
            this.CurrentState = State.Paused;
        }

        public void setStoppedState()
        {
            this.CurrentState = State.Stopped;
        }
    }
}
