using Microsoft.Kinect;

namespace LightBuzz.Vitruvius.Gestures
{
    public class SwipeRightSegment1 : IGestureSegment
    {

         public GesturePartResult Update(Skeleton skeleton)
        {
            //si la mano izquierda está levantada
            if (skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.HipCenter].Position.Y)
            {
                //mano izquierda por debajo de la altura del hombro , pero por encima de la altura de la cadera
                if (skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.Head].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y)
                {
                    //Mano izquierda se mueve hacia la derecha
                    if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderLeft].Position.X)
                    {
                        return GesturePartResult.Succeeded;
                    }
                    return GesturePartResult.Undetermined;
                }
                return GesturePartResult.Failed;
            }
            return GesturePartResult.Failed;
        }
    }

    public class SwipeRightSegment2 : IGestureSegment
    {

        public GesturePartResult Update(Skeleton skeleton)
        {
            //Mano izquierda levantada
            if (skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.HipCenter].Position.Y)
            {
                //mano izquierda por debajo de la altura del hombro , pero por encima de la altura de la cadera
                if (skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.Head].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y)
                {
                    //mano izquierda movida
                    if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X && skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X)
                    {
                        return GesturePartResult.Succeeded;
                    }
                    return GesturePartResult.Undetermined;
                }
                return GesturePartResult.Failed;
            }
            return GesturePartResult.Failed;
        }
    }

    public class SwipeRightSegment3 : IGestureSegment
    {
        public GesturePartResult Update(Skeleton skeleton)
        {
            //Mano izquierda levantada
            if (skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.HipCenter].Position.Y)
            {
                //mano izquierda por debajo de la altura del hombro , pero por encima de la altura de la cadera
                if (skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.Head].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y)
                {
                    //mano movida
                    if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X)
                    {
                        return GesturePartResult.Succeeded;
                    }

                    return GesturePartResult.Undetermined;
                }

                return GesturePartResult.Failed;
            }

            return GesturePartResult.Failed;
        }
    }
}
