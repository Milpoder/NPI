using LightBuzz.Vitruvius.Gestures;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;

namespace LightBuzz.Vitruvius
{
    /// <summary>
    /// Represents a gesture controller.
    /// </summary>
    public class GestureController
    {
        #region Members

        /// <summary>
        /// A list of all the gestures the controller is searching for.
        /// </summary>
        private List<Gesture> _gestures = new List<Gesture>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="GestureController"/>.
        /// </summary>
        public GestureController()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GestureController"/>.
        /// </summary>
        /// <param name="type">The gesture type to recognize. Set to GesureType.All for instantly adding all of the predefined gestures.</param>
        public GestureController(GestureType type)
        {
            if (type == GestureType.All)
            {
                foreach (GestureType t in Enum.GetValues(typeof(GestureType)))
                {
                    if (t != GestureType.All)
                    {
                        AddGesture(t);
                    }
                }
            }
            else
            {
                AddGesture(type);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when a gesture is recognized.
        /// </summary>
        public event EventHandler<GestureEventArgs> GestureRecognized;

        #endregion

        #region Methods

        /// <summary>
        /// Updates all gestures.
        /// </summary>
        /// <param name="skeleton">The skeleton data.</param>
        public void Update(Skeleton skeleton)
        {
            foreach (Gesture gesture in _gestures)
            {
                gesture.Update(skeleton);
            }
        }

        /// <summary>
        /// Adds the specified gesture for recognition.
        /// </summary>
        /// <param name="type">The predefined <see cref="GestureType" />.</param>
        public void AddGesture(GestureType type)
        {
            IGestureSegment[] segments = null;

            // DEVELOPERS: If you add a new predefined gesture with a new GestureType,
            // simply add the proper segments to the switch statement here.
            switch (type)
            {
                case GestureType.SwipeRight:
                    segments = new IGestureSegment[3];

                    segments[0] = new SwipeRightSegment1();
                    segments[1] = new SwipeRightSegment2();
                    segments[2] = new SwipeRightSegment3();
                    break;
                
                case GestureType.All:
                case GestureType.None:
                default:
                    break;
            }

            if (type != GestureType.None)
            {
                Gesture gesture = new Gesture(type, segments);
                gesture.GestureRecognized += OnGestureRecognized;

                _gestures.Add(gesture);
            }
        }

        /// <summary>
        /// Adds the specified gesture for recognition.
        /// </summary>
        /// <param name="name">The gesture name.</param>
        /// <param name="segments">The gesture segments.</param>
        public void AddGesture(string name, IGestureSegment[] segments)
        {
            Gesture gesture = new Gesture(name, segments);
            gesture.GestureRecognized += OnGestureRecognized;

            _gestures.Add(gesture);
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Handles the GestureRecognized event of the g control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KinectSkeltonTracker.GestureEventArgs"/> instance containing the event data.</param>
        private void OnGestureRecognized(object sender, GestureEventArgs e)
        {
            if (GestureRecognized != null)
            {
                GestureRecognized(this, e);
            }

            foreach (Gesture gesture in _gestures)
            {
                gesture.Reset();
            }
        }

        #endregion
    }
}
