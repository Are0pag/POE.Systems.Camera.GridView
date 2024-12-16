namespace Scripts.Systems.Camera.GridView
{
    public class SwapContextSettings
    {
        public float LeftMapSideX { get; protected set; }

        public float RightMapSideX { get; protected set; }

        public float UpperMapSideY { get; protected set; }

        public float LowerMapSideY { get; protected set; }

        public SwapContextSettings(float leftMapSideX, float rightMapSideX, float upperMapSideY, float lowerMapSideY) {
            LeftMapSideX = leftMapSideX;
            RightMapSideX = rightMapSideX;
            UpperMapSideY = upperMapSideY;
            LowerMapSideY = lowerMapSideY;
        }
    }
}