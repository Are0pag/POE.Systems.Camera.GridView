namespace Scripts.Systems.Camera.GridView
{
    public class SwapContextSettings
    {
        public float LeftMapSideX { get; }

        public float RightMapSideX { get; }

        public float UpperMapSideY { get; }

        public float LowerMapSideY { get; }

        public SwapContextSettings(float leftMapSideX, float rightMapSideX, float upperMapSideY, float lowerMapSideY) {
            LeftMapSideX = leftMapSideX;
            RightMapSideX = rightMapSideX;
            UpperMapSideY = upperMapSideY;
            LowerMapSideY = lowerMapSideY;
        }
    }
}