

#include "planet.h"

//=============================================================================
// default constructor
//=============================================================================
Planet::Planet() : Entity()
{
    spriteData.x    = planetNS::X;              // location on screen
    spriteData.y    = planetNS::Y;
    radius          = planetNS::COLLISION_RADIUS;
    mass            = planetNS::MASS;
    startFrame      = planetNS::START_FRAME;    // first frame of ship animation
    endFrame        = planetNS::END_FRAME;      // last frame of ship animation
    setCurrentFrame(startFrame);
}