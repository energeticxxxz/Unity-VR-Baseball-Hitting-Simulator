[System.Serializable]
public struct PitchData
{
    public string name;
    
    //speed
    public float pitchSpeedMph;  // strength of the pitch in mph

    //direction
    public float thetaDegrees;    // horizontal
    public float phiDegrees;      // vertical

    //air drag
    public float dragCoefficient;

    //magnus force
    public float radius;
    public float airDensity;
    //public float magnusCoefficient;
    public float angularVelocityMagnitude;

    //magnus force direction
    public float horizontalSpin; //in degrees
    public float verticalSpin;   //in degrees
    

}
