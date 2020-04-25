using System;
using UnityEngine;
using VrVektoren.Core;
using VrVektoren.Utilities;

namespace VrVektoren.Behaviours
{
    public class VectorBehaviour : MonoBehaviour
    {
        private Vector vector;
        private VectorPosition currentPosition;
        private VectorPosition targetPosition;
        private bool isPositionChanging;
        private bool isMoving;
        private bool isTurning;
        private bool isLenghtChanging;
        private double movementSpeed = 0.05;
        private double rotationSpeed = 2.5;
        private double lenghtChangingSpeed = 0.05;

        private Transform head;
        private Transform shaft;
        
        void Start()
        {
        }

        public void Initialize(Vector vector)
        {
            this.vector = vector;

            this.vector.PositionChanged += this.OnPositionChanged;

            var vectorTransform = transform.Find("Vector");
            this.head = vectorTransform.Find("Head");
            this.shaft = vectorTransform.Find("Shaft");

            transform.localScale = new Vector3(5, 5, 5);

            if (!this.vector.HasHead)
            {
                this.head.gameObject.SetActive(false);
            }

            GameObjectColorHelper.SetGameObjectColor(this.head.gameObject, this.vector.Color);
            GameObjectColorHelper.SetGameObjectColor(this.shaft.gameObject, this.vector.Color);

            this.currentPosition = this.vector.Position;
            this.SetPostion(this.vector.Position);
        }
                
        private void OnDestroy()
        {
            this.vector.PositionChanged -= this.OnPositionChanged;
        }
        
        void Update()
        {
            if (this.isPositionChanging)
            {
                var point = this.currentPosition.Point;
                if (this.isMoving)
                {
                    point = new Point(
                        this.Approximate(point.X, this.targetPosition.Point.X, this.movementSpeed),
                        this.Approximate(point.Y, this.targetPosition.Point.Y, this.movementSpeed),
                        this.Approximate(point.Z, this.targetPosition.Point.Z, this.movementSpeed));

                    this.SetPoint(point);

                    this.SetIsMoving();
                }

                var angle = this.currentPosition.Angle;
                if (this.isTurning)
                {
                    angle = new EulerAngle(
                        this.Approximate(angle.XAngle, this.targetPosition.Angle.XAngle, this.rotationSpeed),
                        this.Approximate(angle.YAngle, this.targetPosition.Angle.YAngle, this.rotationSpeed),
                        this.Approximate(angle.ZAngle, this.targetPosition.Angle.ZAngle, this.rotationSpeed));

                    this.SetAngle(angle);

                    this.SetIsTurning();
                }

                var lenght = this.currentPosition.Lenght;
                if (this.isLenghtChanging)
                {
                    lenght = this.Approximate(lenght, this.targetPosition.Lenght, this.lenghtChangingSpeed);

                    this.SetLenght(lenght);

                    this.SetIsLenghtChanging();
                }

                this.currentPosition = new VectorPosition(
                    this.currentPosition.IsVisible,
                    point,
                    angle,
                    lenght);

                this.SetIsPositionChanging();
            }
        }
        
        private void OnPositionChanged(object sender, EventArgs e)
        {
            this.targetPosition = this.vector.Position;

            if (this.currentPosition.IsVisible != this.targetPosition.IsVisible)
            {
                this.SetVisibility(this.targetPosition.IsVisible);

                this.currentPosition = new VectorPosition(
                    this.targetPosition.IsVisible,
                    this.currentPosition.Point,
                    this.currentPosition.Angle,
                    this.currentPosition.Lenght);
            }

            this.SetIsMoving();
            this.SetIsTurning();
            this.SetIsLenghtChanging();
            this.SetIsPositionChanging();
        }

        private void SetPostion(VectorPosition position)
        {
            this.SetVisibility(position.IsVisible);
            this.SetPoint(position.Point);
            this.SetAngle(position.Angle);
            this.SetLenght(position.Lenght);
        }

        private void SetVisibility(bool isVisible)
        {
            this.gameObject.SetActive(isVisible);
        }

        private void SetPoint(Point point)
        {
            transform.localPosition = new Vector3(
                (float)point.X,
                (float)point.Y,
                (float)point.Z);
        }

        private void SetAngle(EulerAngle angle)
        {
            transform.localRotation = Quaternion.Euler(
                (float)angle.XAngle,
                (float)angle.YAngle,
                (float)angle.ZAngle);
        }

        private void SetLenght(double lenght)
        {
            var totalLenght = lenght * 0.04;

            var headLenght = 0d;

            if (this.vector.HasHead)
            {
                this.head.localPosition = new Vector3(0, 0, (float)(totalLenght - 0.01));
                headLenght = 0.02;
            }

            var shaftLenght = totalLenght - headLenght;
            this.shaft.localScale = new Vector3(
                this.shaft.localScale.x,
                this.shaft.localScale.y,
                (float)(shaftLenght * 50));

            this.shaft.localPosition = new Vector3(0, 0, (float)(shaftLenght / 2));
        }
        
        private void SetIsMoving()
        {
            this.isMoving = this.currentPosition.Point.X != this.targetPosition.Point.X
                || this.currentPosition.Point.Y != this.targetPosition.Point.Y
                || this.currentPosition.Point.Z != this.targetPosition.Point.Z;
        }

        private void SetIsTurning()
        {
            this.isTurning = this.currentPosition.Angle.XAngle != this.targetPosition.Angle.XAngle
                  || this.currentPosition.Angle.YAngle != this.targetPosition.Angle.YAngle
                  || this.currentPosition.Angle.ZAngle != this.targetPosition.Angle.ZAngle;
        }

        private void SetIsLenghtChanging()
        {
            this.isLenghtChanging = this.currentPosition.Lenght != this.targetPosition.Lenght;
        }

        private void SetIsPositionChanging()
        {
            this.isPositionChanging = this.isMoving | this.isTurning | this.isLenghtChanging;
        }

        private double Approximate(double value, double target, double range)
        {
            if (value < target - range)
            {
                return value + range;
            }
            else if (value > target + range)
            {
                return value - range;
            }
            return target;
        }
    }
}
