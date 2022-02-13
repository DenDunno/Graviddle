float2x2 rotationMatrix(float angle)
{
    float cosAngle = cos(angle);
    float sinAngle = sin(angle);
    float2x2 rot = float2x2(cosAngle, -sinAngle, sinAngle, cosAngle);
}